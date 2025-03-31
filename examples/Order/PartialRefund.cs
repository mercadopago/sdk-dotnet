using System;
using MercadoPago.Config;
using MercadoPago.Http;
using MercadoPago.Client;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;
using System.Collections.Generic;

internal class PartialRefundOrderExample
{
    private static void Main(string[] args)
    {
        MercadoPagoConfig.AccessToken = "{{ACCESS_TOKEN}}";

        var request = new OrderCreateRequest
        {
            Type = "online",
            TotalAmount = "1000.00",
            ExternalReference = "ext_ref_1234",
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

        var refundRequest = new OrderRefundPaymentRequest
        {
            Transactions = new List<OrderRefundTransactionRequest>
            {
                new OrderRefundTransactionRequest
                {
                    Id = order.Transactions.Payments[0].Id,
                    Amount = "200.00",
                }
            }
        };
        var requestOptions = new RequestOptions();
        requestOptions.CustomHeaders.Add(Headers.IDEMPOTENCY_KEY, "{{IDEMPOTENCY_KEY}}");

        Order refundedOrder = client.Refund(order.Id, refundRequest, requestOptions);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(refundedOrder, Newtonsoft.Json.Formatting.Indented));
    }
}
