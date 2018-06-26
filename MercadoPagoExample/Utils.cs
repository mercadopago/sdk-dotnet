using System;

namespace MercadoPagoExample
{
    public static class Utils
    {
        public static string Prompt(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }
    }
}