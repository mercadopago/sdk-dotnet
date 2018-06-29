using System;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.PaymentMethod
{
    public struct SecurityCode
    {
        public SecurityCodeMode Mode { get; set; }

        public int Length { get; set; }

        public SecurityCodeCardLocation CardLocation { get; set; }
    }
}
