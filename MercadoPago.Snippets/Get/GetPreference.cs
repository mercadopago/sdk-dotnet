using System;
using System.Threading.Tasks;
using MercadoPago.Client;
using MercadoPago.Client.Preference;

namespace MercadoPago.Snippets.Get
{
    public static class GetPreference
    {
        public static async Task GetAsync()
        {
            var requestOptions = new RequestOptions
            {
                AccessToken = "APP_USR-5942956653298084-080417-ee7cb22979c854623cb947ff7d0dc820-616118536",
            };

            var client = new PreferenceClient();
            var id = "616118536-48621c95-a532-46e0-8c5c-f994ba28caf8";
            var preference = await client.GetAsync(id, requestOptions);

            Console.WriteLine($"Preference retrieved.");
        }
    }
}
