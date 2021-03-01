using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MercadoPago.Client.Preference;

namespace MercadoPago.Snippets.CheckoutPro
{
    public static class SimpleIntegration
    {
        public static async Task Create()
        {
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Title = "Meu produto",
                        Quantity = 1,
                        CurrencyId = "BRL",
                        UnitPrice = 75.56m,
                    },
                },
            };
            var client = new PreferenceClient();
            var preference = await client.CreateAsync(request);

            Console.WriteLine($"Preference ID: {preference.Id}");
        }
    }
}
