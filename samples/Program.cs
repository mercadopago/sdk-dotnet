using System;
using MercadoPago.Config;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Resource.Payment;

MercadoPagoConfig.AccessToken = "TEST-8773732272161169-051014-926630cdc45754768e5a6dbdcf4336a4-1121241909";

var request = new PaymentCreateRequest
{
    TransactionAmount = 105,
    Description = "Título do produto",
    PaymentMethodId = "pix",
    Payer = new PaymentPayerRequest
    {
        Email = "test_user_24634097@testuser.com",
        FirstName = "Test",
        LastName = "User",
        Identification = new IdentificationRequest
        {
            Type = "CPF",
            Number = "191191191-00",
        },
        Address = new PaymentPayerAddressRequest
        {
            ZipCode = "09993-000",
            StreetName = "Rua Guilherme de Almeida",
            StreetNumber = "40",
            Neighborhood = "Conceição",
            City = "Diadema",
            FederalUnit = "São Paulo"
        }
    },
};

var client = new PaymentClient();
Payment payment = await client.CreateAsync(request);

Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(payment));