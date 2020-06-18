using System;
namespace MercadoPago.DataStructures.PaymentMethod
{
    public struct Bin
    {
        private string _pattern;
        private string _exclusion_pattern;
        private string _installments_pattern;


        /// <summary>
        /// Regular expression representing the accepted bins
        /// </summary>
        public string Pattern
        {
            get
            {
                return _pattern;
            }

            set
            {
                _pattern = value;
            }
        }

        /// <summary>
        /// Regular expression representing the excluded bins
        /// </summary>
        public string ExclusionPattern
        {
            get
            {
                return _exclusion_pattern;
            }

            set
            {
                _exclusion_pattern = value;
            }
        }

        /// <summary>
        /// Regular expression representing bins allowed to pay with more than one installment
        /// </summary>
        public string InstallmentsPattern
        {
            get
            {
                return _installments_pattern;
            }

            set
            {
                _installments_pattern = value;
            }
        }
    }
}
