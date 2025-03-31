using System;
using MercadoPago.Config;
using MercadoPago.Client.Common;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;
using System.Collections.Generic;

internal class ProcessOrderExample
{
    private static void Main(string[] args)
    {
        MercadoPagoConfig.AccessToken = "{{ACCESS_TOKEN}}";

        var request = new OrderCreateRequest
        {
            Type = "online",
            TotalAmount = "1000.00",
            ExternalReference = "ext_ref_1234",
            ProcessingMode = "manual",
            Transactions = new OrderTransactionRequest
            {
                Payments = new List<OrderPaymentRequest>
                {
                    new OrderPaymentRequest
                    {
                        Amount = "1000.00",
                        PaymentMethod = new OrderPaymentMethodRequest
                        {
                            Id = "master",
                            Type = "credit_card",
                            Token = "{{CARD_TOKEN}}",
                            Installments = 1,
                        }
                    }
                }
            },
            Payer = new OrderPayerRequest
            {
                Email = "{{PAYER_EMAIL}}",
            }
        };

        var client = new OrderClient();
        Order order = client.Create(request);
        Console.WriteLine("Created Order ID: " + order.Id);
        Console.WriteLine("Created Order status: " + order.Status);

        Order processedOrder = client.Process(order.Id);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(processedOrder, Newtonsoft.Json.Formatting.Indented));
    }
}
