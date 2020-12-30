using System;
namespace MercadoPago.Resources
{
    /// <summary>
    /// This class will allow you to refund payments created through the Payments class.
    /// You can refund a payment within 180 days after it was approved.
    /// You must have sufficient funds in your account in order to successfully refund the payment amount. Otherwise, you will get a 400 Bad Request error.
    /// </summary>
    public class Refund : MPBase
    {
        #region Actions
        /// <summary>
        /// Saves a new refund.
        /// </summary>
        /// <returns>The saved refund.</returns>
        public Refund Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Saves a new refund.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The saved refund.</returns>
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

        /// <summary>
        /// Refund ID.
        /// </summary>
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

        /// <summary>
        /// Amount.
        /// </summary>
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

        /// <summary>
        /// Payment ID.
        /// </summary>
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

        /// <summary>
        /// Date of creation.
        /// </summary>
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
