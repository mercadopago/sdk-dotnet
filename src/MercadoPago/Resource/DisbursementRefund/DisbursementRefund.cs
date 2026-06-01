namespace MercadoPago.Resource.DisbursementRefund
{
    using System;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a refund on a disbursement within an advanced (split) payment,
    /// returned by the MercadoPago API. Use
    /// <see cref="Client.DisbursementRefund.DisbursementRefundClient"/> to list,
    /// create, and manage disbursement refunds.
    /// </summary>
    public class DisbursementRefund : IResource
    {
        /// <summary>
        /// Unique identifier of this disbursement refund.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Identifier of the advanced payment to which this refund belongs.
        /// </summary>
        public long? AdvancedPaymentId { get; set; }

        /// <summary>
        /// Identifier of the specific disbursement that was refunded.
        /// </summary>
        public long? DisbursementId { get; set; }

        /// <summary>
        /// Amount refunded to the buyer.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Current status of the refund.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Date and time when this refund was created (UTC).
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
