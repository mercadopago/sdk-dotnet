using System.Diagnostics;
using MercadoPago.Common;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Resources;

namespace MercadoPagoExample.Payments
{
    public static class UserAccessTokenExample
    {
        public static void Run()
        {
            // Create a preference object
            var preference = new Preference
            {
                UserAccessToken = "YOUR_ACCESS_TOKEN",
                Items =
                {
                    new Item
                    {
                        Id = "1234",
                        Title = "Small Silk Plate",
                        Quantity = 5,
                        CurrencyId = CurrencyId.ARS,
                        UnitPrice = 44.23m
                    }
                },
                Payer = new Payer
                {
                    Email = "augustus_mckenzie@gmail.com"
                }
            };

            // Save and posting preference
            preference.Save();

            Process.Start(preference.InitPoint);
        }
    }
}