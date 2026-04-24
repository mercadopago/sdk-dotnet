using System.Collections.Generic;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents a refund record within an <see cref="OrderTransaction"/>, tracking partial or full
    /// refunds issued against a payment in the order.
    /// </summary>
    public class OrderRefundItem
    {
        /// <summary>
        /// Unique identifier assigned to this refund by MercadoPago.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identifier of the original <see cref="OrderPayment"/> transaction that was refunded.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// External reference identifier used to correlate this refund with a record in your own system.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// Amount refunded to the payer, expressed in the order currency. May be less than the original payment for partial refunds.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Current processing status of the refund (e.g., "approved", "pending", "rejected").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// List of <see cref="OrderItems"/> that were refunded. Used for item-level refund tracking.
        /// </summary>
        public IList<OrderItems> Items { get; set; }

        /// <summary>
        /// End-to-end identifier for PIX refund transfers, used for reconciliation with the Brazilian Central Bank.
        /// </summary>
        public string E2eId { get; set; }
    }
}
