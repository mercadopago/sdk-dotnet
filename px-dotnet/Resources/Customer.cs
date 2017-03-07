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

        /// <summary>
        /// Loads specified customer by ID.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="useCache">Cache configuration.</param>
        /// <returns>Searched customer.</returns>
        [GETEndpoint("/v1/customers/:id")]
        public static Customer load(string id, bool useCache)
        {
            return (Customer)Customer.processMethod(typeof(Customer), "load", "id", useCache);
        }
    }
}
