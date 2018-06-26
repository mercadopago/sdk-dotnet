using System;
using System.Configuration;
using System.Linq;
using MercadoPago;
using MercadoPagoExample.Payments;

namespace MercadoPagoExample
{
    public class MainClass
    {
        private static decimal ShowMenu()
        {
            Console.WriteLine("MercadoPago Examples");
            Console.WriteLine();
            Console.WriteLine("1. Pagos");
            Console.WriteLine("\t1.1. Pago con Checkout Web");
            Console.WriteLine("\t1.2. Pago via API");
            Console.WriteLine("\t1.3. Pago con Tarjetas Guardadas");
            Console.WriteLine("5. Exit");

            var selection = Console.ReadLine();

            return decimal.TryParse(selection, out var result)
                ? result
                : 0;
        }

        private static void LoadConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SDK.SetConfiguration(config);

            if (string.IsNullOrEmpty(SDK.AccessToken))
                SDK.AccessToken = Utils.Prompt("Ingrese Access Token: ");

            if (string.IsNullOrEmpty(SDK.ClientId))
                SDK.ClientId = Utils.Prompt("Ingrese Client Id: ");

            if (string.IsNullOrEmpty(SDK.ClientSecret))
                SDK.ClientSecret = Utils.Prompt("Ingrese Client Secret: ");

            if (string.IsNullOrEmpty(SDK.AppId))
                SDK.AppId = Utils.Prompt("Ingrese App Id: ");
        }

        public static void Main(string[] args)
        { 
            LoadConfig();

            while (true)
            {
                switch (ShowMenu())
                {
                    case 1.1m:
                        WebCheckoutExample.Run();
                        break;
                    case 1.2m:
                        ApiPaymentExample.Run();
                        break;
                    case 1.3m:
                        SavedCardsExample.Run();
                        break;
                    case 5m:
                        return;
                }
            }
        }
    }
}
