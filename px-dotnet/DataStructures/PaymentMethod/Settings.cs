using System;
namespace MercadoPago.DataStructures.PaymentMethod
{
    public struct Settings
    {
        public Bin Bin { get; set; }

        public CardNumber CardNumber { get; set; }

        public SecurityCode SecurityCode { get; set; }
    }
}
