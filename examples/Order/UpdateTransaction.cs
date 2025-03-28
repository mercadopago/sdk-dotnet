using System;
using MercadoPago.Config;
using MercadoPago.Client.Common;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;
using System.Collections.Generic;

internal class UpdateOrderTransactionExample
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
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(order.Transactions, Newtonsoft.Json.Formatting.Indented));

        OrderPaymentRequest paymentRequest = new OrderPaymentRequest
        {
            PaymentMethod = new OrderPaymentMethodRequest
            {
                Installments = 3
            }
        };

        OrderUpdateTransaction updatedTransaction = client.UpdateTransaction(order.Id, order.Transactions.Payments[0].Id, paymentRequest);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(updatedTransaction, Newtonsoft.Json.Formatting.Indented));
    }
}
