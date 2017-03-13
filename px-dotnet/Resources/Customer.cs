using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public class Customer : MPBase
    {
        #region Variables
        private string id = null;

        public string getId()
        {
            return id;
        }
        #endregion

        #region Core Methods
        /// <summary>
        /// Loads specified customer by ID.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="useCache">Cache configuration.</param>
        /// <returns>Searched customer.</returns>
        [GETEndpoint("/v1/customers/:id")]
        public static Customer Load(string id, bool useCache)
        {
            return (Customer)ProcessMethod("load", "id", useCache);
        }
        #endregion
    }
}
