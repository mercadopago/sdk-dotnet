using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public class MPAPIResponse
    {
        #region Properties
        public string StringResponse { get; protected set; }
        public int StatusCode { get; set; }
        #endregion

        #region Contructors
        /// <summary>
        /// Constructor with paarameter.
        /// </summary>
        /// <param name="response">String containing the response of the api call.</param>
        public MPAPIResponse(int statusCode, string response)
        {
            this.StatusCode = statusCode;
            this.StringResponse = response;
        }
        #endregion
    }
}
