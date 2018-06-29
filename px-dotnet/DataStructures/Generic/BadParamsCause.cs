using System;
namespace MercadoPago.DataStructures.Generic
{
    public struct BadParamsCause : RecuperableErrorCause
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string Data { get; set; }
    }
}
