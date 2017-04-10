using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class FeeDetail
    {
        #region Properties

        public enum Type 
        {
            MercadoPagoFee,
            CouponFee,
            FinancingFee,
            ShippingFee,
            ApplicationFee,
            DiscountFee
        }

        private Type type;

        public enum FeePayer
        { 
            Collector,
            Payer
        }

        private FeePayer feePayer;
        private decimal amount;

        #endregion

        #region Accessors

        public Type FeeDetailType
        {
            get { return type; }
            set { type = value; }
        }

        public FeePayer Payer
        {
            get { return feePayer; }
            set { feePayer = value; }
        }    

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        #endregion
    }
}
