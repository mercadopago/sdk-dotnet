using System;
namespace MercadoPago.Resources
{
    public class Refund : MPBase
    {
        #region Actions
        /// <summary>
        /// Find a payment trought an unique identifier
        /// </summary>
        [POSTEndpoint("/v1/payments/:payment_id/refunds")]
        public Refund Save()
        {
            return (Refund)ProcessMethod<Refund>("Save", WITHOUT_CACHE);
        }
        #endregion

        #region Properties
        private decimal? _id;
        private decimal? _amount;
        private decimal? _payment_id;
        private DateTime? _date_created;
        private String _errors;

        #endregion

        #region Accessors

        public void manualSetPaymentId(decimal id){
            this.PaymentId = id;
        }

        public decimal? Id
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }

        public decimal? Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value;
            }
        }

        public decimal? PaymentId
        {
            get
            {
                return _payment_id;
            }

            private set
            {
                _payment_id = value;
            }
        }

        public DateTime? DateCreated
        {
            get
            {
                return _date_created;
            }

            private set
            {
                _date_created = value;
            }
        }

        public String Errors
        {
            get
            {
                return _errors;
            }

            set
            {
                _errors = value;
            }
        }
        #endregion


    }
}
