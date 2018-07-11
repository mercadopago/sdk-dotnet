using System;
namespace MercadoPago.Resources
{
    public class Refund : Resource<Refund>
    {
        #region Actions
        /// <summary>
        /// Find a payment trought an unique identifier
        /// </summary>
        public Refund Save() => Post($"/v1/payments/{PaymentId}/refunds");

        #endregion

        #region Properties

        public void manualSetPaymentId(decimal id){
            this.PaymentId = id;
        }

        public decimal? Id { get; private set; }

        public decimal? Amount { get; set; }

        public decimal? PaymentId { get; private set; }

        public DateTime? DateCreated { get; private set; }

        public string Errors { get; set; }

        #endregion


    }
}
