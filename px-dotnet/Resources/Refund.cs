using System;
namespace MercadoPago.Resources
{
    public class Refund : MPBase
    {
        #region Actions
        /// <summary>
        /// Save a refund
        /// </summary>
        public Refund Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Save a refund
        /// </summary>
        [POSTEndpoint("/v1/payments/:payment_id/refunds")]
        public Refund Save(MPRequestOptions requestOptions)
        {
            return (Refund)ProcessMethod<Refund>("Save", WITHOUT_CACHE, requestOptions);
        }
        #endregion

        #region Properties
        private decimal? _id;
        private decimal? _amount;
        private decimal? _payment_id;
        private DateTime? _date_created;

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

        #endregion


    }
}
