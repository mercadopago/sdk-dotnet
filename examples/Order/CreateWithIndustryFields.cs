using System;
using MercadoPago.Config;
using MercadoPago.Client.Common;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;
using System.Collections.Generic;

internal class CreateOrderWithIndustryFieldsExample
{
    private static void Main(string[] args)
    {
        MercadoPagoConfig.AccessToken = "{{ACCESS_TOKEN}}";

        var item = new OrderItemsRequest
        {
            Title = "Trip to Destination",
            Description = "Trip to Destination - One way",
            PictureUrl = "https://example_url.com/",
            CategoryId = "travel",
            Quantity = 1,
            Type = "travel",
            UnitPrice = "1000.00",
            Warranty = true,
            EventDate = "2024-06-28T16:53:03.176-04:00"
        };

        var itemsList = new List<OrderItemsRequest> { item };

        var address = new OrderAddressRequest
        {
            StreetName = "R. Ângelo Piva",
            StreetNumber = "144",
            ZipCode = "06210110",
            Neighborhood = "Presidente Altino",
            City = "Osasco",
            State = "SP",
            Complement = "303"
        };

        var additionalInfo = new Dictionary<string, object>
        {
            { "payer.authentication_type", "MOBILE" },
            { "payer.registration_date", "2024-01-01T00:00:00" },
            { "payer.is_prime_user", true },
            { "payer.is_first_purchase_online", true },
            { "payer.last_purchase", "2024-01-01T00:00:00" },

            { "shipment.express", true },
            { "shipment.local_pickup", true },

            {
                "travel.passengers",
                new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>
                    {
                        { "first_name", "Jose" },
                        { "last_name", "Silva" },
                        {
                            "identification", new Dictionary<string, string>
                            {
                                { "type", "CPF" },
                                { "number", "12345678900" }
                            }
                        }
                    }
                }
            },

            {
                "travel.routes",
                new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>
                    {
                        { "departure", "GRU" },
                        { "destination", "CWB" },
                        { "departure_date_time", "2024-01-01T00:00:00.000-03:00" },
                        { "arrival_date_time", "2024-01-01T00:00:00.000-03:00" },
                        { "company", "Airline" }
                    }
                }
            },

            { "platform.seller.id", "123456" },
            { "platform.seller.name", "Example Seller" },
            { "platform.seller.email", "seller@example.com" },
            { "platform.seller.status", "Active" }
        };

        var request = new OrderCreateRequest
        {
            Type = "online",
            ExternalReference = "ext_ref_" + DateTime.Now.Ticks,
            ProcessingMode = "automatic",
            TotalAmount = "1000.00",
            Payer = new OrderPayerRequest
            {
                Email = "{{PAYER_EMAIL}}",
                EntityType = "individual",
                FirstName = "John",
                LastName = "Doe",
                Identification = new OrderIdentificationRequest
                {
                    Type = "CPF",
                    Number = "12345678900"
                },
                Phone = new OrderPhoneRequest
                {
                    AreaCode = "11",
                    Number = "123456789"
                },
                Address = address
            },
            Transactions = new OrderTransactionRequest
            {
                Payments = new List<OrderPaymentRequest>
                {
                    new OrderPaymentRequest
                    {
                        Amount = "1000.00",
                        PaymentMethod = new OrderPaymentMethodRequest
                        {
                            Id = "visa",
                            Type = "credit_card",
                            Token = "{{CARD_TOKEN}}",
                            Installments = 1
                        }
                    }
                }
            },
            Items = itemsList,
            AdditionalInfo = additionalInfo
        };

        var requestOptions = new RequestOptions();
        requestOptions.CustomHeaders.Add("x-idempotency-key", Guid.NewGuid().ToString());
        requestOptions.CustomHeaders.Add("X-Product-Id", "{{PRODUCT_ID}}");

        var client = new OrderClient();
        Order order = client.Create(request, requestOptions);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented));
    }
}