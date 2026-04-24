namespace MercadoPago.Resource.Payment
{
    using System;
    using MercadoPago.Http;
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Represents a refund issued against a <see cref="Payment"/>.
    /// Contains the refund amount, status, and associated metadata.
    /// A payment can have multiple partial refunds.
    /// </summary>
    public class PaymentRefund : IResource
    {
        /// <summary>
        /// Unique identifier of this refund, assigned by MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Identifier of the original <see cref="Payment"/> that was refunded.
        /// </summary>
        public long? PaymentId { get; set; }

        /// <summary>
        /// Amount refunded in the payment's currency. For partial refunds,
        /// this is less than the original transaction amount.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Current status of the refund. Possible values: "approved"
        /// (refund completed) or other statuses indicating pending or failed refunds.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Refund mode indicating how the refund was processed.
        /// Possible values: "standard" (normal refund processing).
        /// </summary>
        public string RefundMode { get; set; }

        /// <summary>
        /// Date and time (ISO 8601) when the refund was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Unique sequence number assigned to this refund for traceability
        /// and reconciliation purposes.
        /// </summary>
        public string UniqueSequenceNumber { get; set; }

        /// <summary>
        /// Source of the funds used for the refund, indicating from which
        /// account the refund was paid.
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this refund request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
