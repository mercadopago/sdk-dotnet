namespace MercadoPago.Resource.AdvancedPayment
{
    using System;
    using MercadoPago.Http;
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Represents a refund applied to a specific <see cref="AdvancedPaymentDisbursement"/>
    /// within an <see cref="AdvancedPayment"/>. Contains details about the refunded amount,
    /// status, and funding source of the refund.
    /// </summary>
    public class AdvancedPaymentDisbursementRefund : IResource
    {
        /// <summary>
        /// Unique identifier of the refund, assigned by MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Identifier of the original payment that was refunded.
        /// </summary>
        public long? PaymentId { get; set; }

        /// <summary>
        /// Amount that was refunded. For partial refunds, this may be less than the original payment amount.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Date and time when the refund was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Current status of the refund (e.g., approved, pending, or rejected).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Funding source from which the refund is drawn (e.g., collector or marketplace account).
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
