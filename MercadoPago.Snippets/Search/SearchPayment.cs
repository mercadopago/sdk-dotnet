using System;
using System.Threading.Tasks;
using MercadoPago.Client;
using MercadoPago.Client.Payment;

namespace MercadoPago.Snippets.Search
{
    public static class SearchPayment
    {
        public static async Task SearchAsync()
        {
            var request = new AdvancedSearchRequest
            {
                //Limit = 5,
                //Offset = 0,
                //Sort = "date_created",
                //Criteria = "desc",
                //Filters = new Dictionary<string, object>
                //{
                //    ["id"] = "10312601340",
                //},
            };
            
            var client = new PaymentClient();
            var result = await client.SearchAsync(request);

            Console.WriteLine();
        }
    }
}
