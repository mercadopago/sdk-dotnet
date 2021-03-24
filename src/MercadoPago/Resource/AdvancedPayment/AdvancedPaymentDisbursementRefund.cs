namespace MercadoPago.Resource.AdvancedPayment
{
    using System;
    using MercadoPago.Http;
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Disbursement refund.
    /// </summary>
    public class AdvancedPaymentDisbursementRefund : IResource
    {
        /// <summary>
        /// Refund Id.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Payment Id.
        /// </summary>
        public long? PaymentId { get; set; }

        /// <summary>
        /// Amount refunded.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Status of refund.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Source of the refund.
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
