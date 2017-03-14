using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public class MPAPIResponse
    {
        #region Variables
        public string StringResponse { get; protected set; }
        #endregion

        #region Contructors
        /// <summary>
        /// Constructor with paarameter.
        /// </summary>
        /// <param name="response">String containing the response of the api call.</param>
        public MPAPIResponse(string response)
        {
            this.StringResponse = response;
        }
        #endregion
    }
}
