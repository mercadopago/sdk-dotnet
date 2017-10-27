using System;

namespace MercadoPagoExample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("MercadoPago Examples");
            Console.WriteLine();
            Console.WriteLine("1. Pagos");
            Console.WriteLine("\t1.1. Pago con Checkout Web");
            Console.WriteLine("\t1.2. Pago via API");
            Console.WriteLine("\t1.3. Pago con Tarjetas Guardadas"); 
            Console.WriteLine("5. Exit");


            var selection = Console.ReadLine();


        }
    }
}
