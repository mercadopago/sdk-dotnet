using MercadoPago.Client.Point;
using MercadoPago.Config;

MercadoPagoConfig.AccessToken = "<YOUR_ACCESS_TOKEN>";

var client = new PointClient();
var deviceId = "<YOUR_DEVICE_ID>";

var request = new PointCreatePaymentIntentRequest
{
    Amount = 150.00m,
    Description = "Product purchase",
    Payment = new PointPaymentRequest
    {
        Installments = 1,
        Type = "credit_card"
    }
};

var intent = await client.CreateAsync(deviceId, request);
Console.WriteLine($"Payment intent ID: {intent.Id}");
Console.WriteLine($"State: {intent.State}");

// Poll the intent status
var status = await client.GetAsync(intent.Id);
Console.WriteLine($"Current state: {status.State}");
