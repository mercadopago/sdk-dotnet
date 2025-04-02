using System;
using MercadoPago.Config;
using MercadoPago.Client.Common;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;
using System.Collections.Generic;

internal class CreateOrderTransactionExample
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
            Payer = new OrderPayerRequest
            {
                Email = "{{PAYER_EMAIL}}",
            }
        };

        var client = new OrderClient();
        Order order = client.Create(request);

        var transactionRequest = new OrderTransactionRequest
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
        };

        OrderTransaction transaction = client.CreateTransaction(order.Id, transactionRequest);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(transaction, Newtonsoft.Json.Formatting.Indented));
    }
}
