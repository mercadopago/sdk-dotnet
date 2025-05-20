using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MercadoPago.Config;
using MercadoPago.Client.Preference;

internal class CreatePreferenceExample
{
    private static void Main(string[] args)
    {
        MercadoPagoConfig.AccessToken = "YOUR_ACCESS_TOKEN";

        var preferenceRequest = new PreferenceRequest
        {
            Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Title = "Dummy Item",
                        Quantity = 1,
                        UnitPrice = 10
                    }
                },
            NotificationUrl = "https://webhook.site/your-notification-url"
        };

        var client = new PreferenceClient();
        var preference = await client.CreateAsync(preferenceRequest);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(preference, Newtonsoft.Json.Formatting.Indented));
    }
}
