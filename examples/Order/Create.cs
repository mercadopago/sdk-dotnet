using System;
using MercadoPago.Config;
using MercadoPago.Client.Common;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;
using System.Collections.Generic;

internal class CreateOrderExample
{
    private static void Main(string[] args)
    {
        MercadoPagoConfig.AccessToken = "{{ACCESS_TOKEN}}";

        var request = new OrderCreateRequest
        {
            Type = "online",
            TotalAmount = "1000.00",
            Currency = "BRL",
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
            },
            Shipment = new OrderShipmentRequest
            {
                Address = new OrderAddressRequest
                {
                    StreetName = "R. Ângelo Piva",
                    StreetNumber = "144",
                    ZipCode = "06210110",
                    City = "Osasco",
                    State = "SP",
                    Complement = "303"
                }
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
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented));
    }
}
