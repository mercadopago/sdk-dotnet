using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public class MPAPIResponse
    {
        public string StringResponse { get; protected set; }

        public MPAPIResponse(string response)
        {
            this.StringResponse = response;
        }
    }
}
