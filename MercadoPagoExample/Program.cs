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
            Console.Clear();
            Console.WriteLine("MercadoPago Examples");
            Console.WriteLine();
            Console.WriteLine("1. Pagos");
            Console.WriteLine("\t1.1. Pago con Checkout Web");
            Console.WriteLine("\t1.2. Pago via API");
            Console.WriteLine("\t1.3. Pago con Tarjetas Guardadas");
            Console.WriteLine("\t1.4. Búsqueda de Pagos");
            Console.WriteLine("\t1.5. Token de Acceso por instancia.");
            Console.WriteLine("5. Exit");

            var selection = Console.ReadLine();

            return decimal.TryParse(selection, out var result)
                ? result
                : 0;
        }

        public static void Main(string[] args)
        { 
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
                    case 1.4m:
                        PaymentSearchExample.Run();
                        break;
                    case 1.5m:
                        UserAccessTokenExample.Run();
                        break;
                    case 5m:
                        return;
                }
                Utils.Prompt("Presione Enter para volver al Menu: ");
            }
        }
    }
}
