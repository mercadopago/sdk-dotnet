using System;
namespace MercadoPago.DataStructures.Generic
{
    public struct BadParamsError : RecuperableError
    {
        public string Message { get; set; }

        public string Error { get; set; }

        public int Status { get; set; }

        public BadParamsCause[] Cause { get; set; }
    }
}
