using System;
using MercadoPago.Config;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;
using System.Collections.Generic;

internal class CreateOrder3DSExample
{
    private static void Main(string[] args)
    {
        MercadoPagoConfig.AccessToken = "{{ACCESS_TOKEN}}";

        var request = new OrderCreateRequest
        {
            Type = "online",
            ExternalReference = "3ds_test",
            ProcessingMode = "automatic",
            TotalAmount = "150.00",
            Config = new OrderConfigRequest
            {
                Online = new OrderOnlineConfigRequest
                {
                    TransactionSecurity = new OrderTransactionSecurityRequest
                    {
                        Validation = "on_fraud_risk",
                        LiabilityShift = "required"
                    }
                }
            },
            Payer = new OrderPayerRequest
            {
                Email = "{{PAYER_EMAIL}}",
                Identification = new OrderIdentificationRequest
                {
                    Type = "{{IDENTIFICATION_TYPE}}",
                    Number = "{{IDENTIFICATION_NUMBER}}"
                }
            },
            Transactions = new OrderTransactionRequest
            {
                Payments = new List<OrderPaymentRequest>
                {
                    new OrderPaymentRequest
                    {
                        Amount = "150.00",
                        PaymentMethod = new OrderPaymentMethodRequest
                        {
                            Id = "master",
                            Type = "credit_card",
                            Token = "{{CARD_TOKEN}}",
                            Installments = 1
                        }
                    }
                }
            }
        };

        var client = new OrderClient();
        Order order = client.Create(request);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented));

        if (order.Transactions?.Payments != null)
        {
            foreach (var payment in order.Transactions.Payments)
            {
                if (payment.Status == "action_required" &&
                    payment.StatusDetail == "pending_challenge" &&
                    payment.PaymentMethod?.TransactionSecurity?.Url != null)
                {
                    Console.WriteLine("\n3DS Challenge Required!");
                    Console.WriteLine($"Challenge URL: {payment.PaymentMethod.TransactionSecurity.Url}");
                    Console.WriteLine("Display this URL in an iframe to complete the 3DS challenge.");
                }
                else if (payment.Status == "processed")
                {
                    Console.WriteLine("\nPayment approved without challenge.");
                }
            }
        }
    }
}

