using System;
using MercadoPago.Config;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;
using System.Collections.Generic;

/// <summary>
/// Mercado Pago — Create Order with PSE (Pagos Seguros en Línea — Colombia).
///
/// <para>
/// PSE is Colombia's standard online bank-transfer payment method. The integrator initiates
/// the transaction with <c>PaymentMethod.Id = "pse"</c> and <c>Type = "bank_transfer"</c>,
/// and must specify the buyer's bank via <c>FinancialInstitution</c>.
/// </para>
///
/// <para>Required PSE-specific fields:</para>
/// <list type="bullet">
///   <item><c>PaymentMethod.Id = "pse"</c> (fixed)</item>
///   <item><c>PaymentMethod.Type = "bank_transfer"</c> (fixed)</item>
///   <item><c>PaymentMethod.FinancialInstitution</c> = PSE bank code (see table below)</item>
///   <item><c>Currency = "COP"</c> (Colombia only)</item>
///   <item><c>Payer.EntityType</c> = "individual" or "association"</item>
///   <item><c>Payer.Identification.Type</c> = "CC", "NIT", etc. (Colombian doc type)</item>
///   <item><c>AdditionalInfo["payer"]["ip_address"]</c> (required by risk engine)</item>
///   <item><c>Config.Online.CallbackUrl</c> (URL the bank redirects to after authorization)</item>
/// </list>
///
/// <para>Most-used PSE bank codes (full catalog via MP API):</para>
/// <code>
///   Bancolombia ........... 1007
///   Davivienda ............ 1051
///   Banco de Bogotá ....... 1001
///   BBVA Colombia ......... 1013
///   Banco Popular ......... 1002
///   Scotiabank Colpatria .. 1019
/// </code>
///
/// <para>Reference: https://www.mercadopago.com.co/developers/es/docs</para>
/// </summary>
internal class CreateOrderPSEExample
{
    private static void Main(string[] args)
    {
        MercadoPagoConfig.AccessToken = "{{ACCESS_TOKEN}}";

        var request = new OrderCreateRequest
        {
            Type = "online",
            ProcessingMode = "automatic",
            TotalAmount = "50000.00",
            Currency = "COP",
            ExternalReference = "ref_pse_12345",
            Transactions = new OrderTransactionRequest
            {
                Payments = new List<OrderPaymentRequest>
                {
                    new OrderPaymentRequest
                    {
                        Amount = "50000.00",
                        // PSE payment: id="pse", type="bank_transfer", financial_institution = bank code.
                        PaymentMethod = new OrderPaymentMethodRequest
                        {
                            Id = "pse",
                            Type = "bank_transfer",
                            FinancialInstitution = "1007", // Bancolombia
                        }
                    }
                }
            },
            // Payer: entity_type + Colombian identification (CC/NIT) required for PSE.
            Payer = new OrderPayerRequest
            {
                Email = "{{PAYER_EMAIL}}",
                FirstName = "{{FIRST_NAME}}",
                LastName = "{{LAST_NAME}}",
                EntityType = "individual",
                Identification = new OrderIdentificationRequest
                {
                    Type = "CC",
                    Number = "{{PAYER_DOC_NUMBER}}",
                }
            },
            // additional_info.payer.ip_address — required by MP's risk engine for PSE.
            // AdditionalInfo is intentionally an IDictionary<string, object> (deliberate SDK design).
            AdditionalInfo = new Dictionary<string, object>
            {
                ["payer"] = new Dictionary<string, object>
                {
                    ["ip_address"] = "{{CLIENT_IP}}",
                }
            },
            // callback_url — where the bank redirects the buyer after authorization.
            Config = new OrderConfigRequest
            {
                Online = new OrderOnlineConfigRequest
                {
                    CallbackUrl = "{{CALLBACK_URL}}",
                }
            }
        };

        var client = new OrderClient();
        Order order = client.Create(request);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented));
    }
}
