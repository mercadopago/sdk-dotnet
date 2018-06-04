using System;
namespace MercadoPago.DataStructures.PaymentMethod
{
    public struct CardNumber
    {
        private string _length;
        private string _validation;

        public string Length
        {
            get
            {
                return _length;
            }

            set
            {
                _length = value;
            }
        }

        public string Validation
        {
            get
            {
                return _validation;
            }

            set
            {
                _validation = value;
            }
        }
    }
}
