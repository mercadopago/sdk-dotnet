using System;
using MercadoPago.Config;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Resource.Payment;

MercadoPagoConfig.AccessToken = "TEST-4214616493038936-080414-1f043cd9063dc514958e2449c6f16b3d-1121241909";

var request = new PaymentCreateRequest
{
    TransactionAmount = 10,
    Installments = 1,
    StatementDescriptor = "LOJA DO ELTIN",
    PaymentMethodId = "master",
    Token = "8c9ff3d38d546c1b30d3ce314b4189d0",
    Metadata = new Dictionary<string, object>
    {
        ["order_number"] = "order_1659729980",
    },
    Description = "PEDIDO NOVO - VIDEOGAME",
    Payer = new PaymentPayerRequest
    {
        FirstName = "Joao",
        LastName = "Silva",
        Email = "test_user_1659729980@testuser.com",
        Identification = new IdentificationRequest
        {
            Type = "CPF",
            Number = "19119119100"
        }
    },
    PointOfInteraction = new PaymentPointOfInteractionRequest
    {
        Type = "SUBSCRIPTIONS",
        TransactionData = new PaymentTransactionDataRequest
        {
            FirstTimeUse = false,
            SubscriptionSequence = new PaymentSubscriptionSequenceRequest
            {
                Number = 3,
                Total = 12
            },
            InvoicePeriod = new PaymentInvoicePeriodRequest
            {
                Period = 1,
                Type = "monthly"
            },
            PaymentReference = new PaymentPaymentReferenceRequest
            {
                Id = "1307737605"
            }
    },
}
};

var client = new PaymentClient();
Payment payment = await client.CreateAsync(request);

Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(payment));