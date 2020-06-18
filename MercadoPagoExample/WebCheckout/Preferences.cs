using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoPago.Common;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Resources;

namespace MercadoPagoExample.WebCheckout
{
    public class WebCheckout : IExample
    {
        public string Name => "WebCheckout Example";

        public void Run()
        {

            MercadoPago.SDK.ClientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            MercadoPago.SDK.ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");

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

            Console.WriteLine(preference.Id);
            Console.WriteLine(preference.InitPoint);

            Console.ReadLine();



        }

    }
}
