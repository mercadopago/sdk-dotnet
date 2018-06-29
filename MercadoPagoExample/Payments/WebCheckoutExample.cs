using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoPago.Common;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Resources;

namespace MercadoPagoExample.Payments
{
    public static class WebCheckoutExample
    {
        public static void Run()
        {
            Utils.LoadOrPromptClientCredentials();

            // Create a preference object
            var preference = new Preference
            {
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
