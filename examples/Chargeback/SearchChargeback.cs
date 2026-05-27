using MercadoPago.Client;
using MercadoPago.Client.Chargeback;
using MercadoPago.Config;

MercadoPagoConfig.AccessToken = "<YOUR_ACCESS_TOKEN>";

var client = new ChargebackClient();

// Search chargebacks by payment ID
var searchRequest = new SearchRequest
{
    Filters = new System.Collections.Generic.Dictionary<string, object>
    {
        ["payment_id"] = "<PAYMENT_ID>"
    }
};

var results = await client.SearchAsync(searchRequest);
Console.WriteLine($"Total chargebacks: {results.Total}");

// Get a specific chargeback by ID
var chargeback = await client.GetAsync(123456789L);
Console.WriteLine($"Chargeback status: {chargeback.Status}");
Console.WriteLine($"Amount: {chargeback.Amount} {chargeback.CurrencyId}");
