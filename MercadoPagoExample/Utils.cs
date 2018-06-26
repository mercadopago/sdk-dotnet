using System;
using System.Configuration;
using MercadoPago;

namespace MercadoPagoExample
{
    public static class Utils
    {
        public static string Prompt(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }

        public static void LoadConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SDK.SetConfiguration(config);

            if (string.IsNullOrEmpty(SDK.AccessToken))
                SDK.AccessToken = Prompt("Ingrese Access Token: ");

            if (string.IsNullOrEmpty(SDK.ClientId))
                SDK.ClientId = Prompt("Ingrese Client Id: ");

            if (string.IsNullOrEmpty(SDK.ClientSecret))
                SDK.ClientSecret = Prompt("Ingrese Client Secret: ");

            if (string.IsNullOrEmpty(SDK.AppId))
                SDK.AppId = Prompt("Ingrese App Id: ");
        }
    }
}