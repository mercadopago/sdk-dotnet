using System;
using MercadoPago.Config;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;
using System.Collections.Generic;

internal class GetOrderExample
{
    private static void Main(string[] args)
    {
        var token = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidOperationException("Defina a variável de ambiente ACCESS_TOKEN.");
        }
        MercadoPagoConfig.AccessToken = token;

        var request = new OrderCreateRequest
        {
            Type = "online",
            TotalAmount = "1000.00",
            ExternalReference = "ext_ref_1234",
            CaptureMode = "automatic_async",
            Transactions = new OrderTransactionRequest
            {
                Payments = new List<OrderPaymentRequest>
                {
                    new OrderPaymentRequest
                    {
                        Amount = "1000.00",
                        PaymentMethod = new OrderPaymentMethodRequest
                        {
                            Id = "boleto",
                            Type = "ticket"
                        }
                    }
                }
            },
            Payer = new OrderPayerRequest
            {
                Email = Environment.GetEnvironmentVariable("USER_EMAIL") ?? "{{PAYER_EMAIL}}",
            },
            AdditionalInfo = new Dictionary<string, object>
            {
                ["payer"] = new Dictionary<string, object>
                {
                    ["authentication_type"] = "senha",
                    ["registration_date"] = "2023-01-01T10:00:00Z",
                    ["is_prime_user"] = true,
                    ["is_first_purchase_online"] = false
                },
                ["shipment"] = new Dictionary<string, object>
                {
                    ["express"] = true
                },
                ["platform"] = new Dictionary<string, object>
                {
                    ["seller"] = new Dictionary<string, object>
                    {
                        ["id"] = "123456",
                        ["name"] = "Minha Loja",
                        ["email"] = "contato@minhaloja.com"
                    }
                }
            }
        };

        var client = new OrderClient();
        Order order = client.Create(request);
        Console.WriteLine("Created Order ID: " + order.Id);

        Order getOrder = client.Get(order.Id);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(getOrder, Newtonsoft.Json.Formatting.Indented));
    }
}
