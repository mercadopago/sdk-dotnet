using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MercadoPago.Client.Common;
using MercadoPago.Client.Preference;

namespace MercadoPago.Snippets.CheckoutPro
{
    public static class AdvancedIntegration
    {
        public static async Task Create()
        {
            var request = new PreferenceRequest();

            var payer = new PreferencePayerRequest
            {
                Name = "Joao",
                Surname = "Silva",
                Email = "user@email.com",
                Phone = new PhoneRequest
                {
                    AreaCode = "11",
                    Number = "4444-4444",
                },

                Identification = new IdentificationRequest
                {
                    Type = "CPF",
                    Number = "19119119100",
                },

                Address = new AddressRequest
                {
                    StreetName = "Street",
                    StreetNumber = "123",
                    ZipCode = "06233200",
                },
            };
            request.Payer = payer;

            var item = new PreferenceItemRequest
            {
                Id = "1234",
                Title = "Lightweight Paper Table",
                Description = "Inspired by the classic foldable art of origami",
                CategoryId = "home",
                Quantity = 3,
                CurrencyId = "BRL",
                UnitPrice = 55.41m,
            };
            request.Items = new List<PreferenceItemRequest>();
            request.Items.Add(item);

            var backUrls = new PreferenceBackUrlsRequest
            {
                Success = "https://www.seu-site/success",
                Failure = "http://www.seu-site/failure",
                Pending = "http://www.seu-site/pendings",
            };
            request.BackUrls = backUrls;

            var client = new PreferenceClient();
            var preference = await client.CreateAsync(request);

            Console.WriteLine($"Preference ID: {preference.Id}");
        }
    }
}
