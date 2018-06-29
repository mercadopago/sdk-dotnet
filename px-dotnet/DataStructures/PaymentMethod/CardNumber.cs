using System;
namespace MercadoPago.DataStructures.PaymentMethod
{
    public struct CardNumber
    {
        public string Length { get; set; }

        public string Validation { get; set; }
    }
}
