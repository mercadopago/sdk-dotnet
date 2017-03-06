using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public class Customer : MPBase
    {
        private string id = null;

        public string getId()
        {
            return id;
        }

        [GETEndpoint("/v1/customers/:id")]
        public static Customer load(string id, bool useCache)
        {
            var customer = new Customer();
            return (Customer)customer.processMethod(typeof(Customer), "load", "id", useCache);
        }
    }
}
