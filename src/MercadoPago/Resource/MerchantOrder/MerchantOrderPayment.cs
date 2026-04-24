namespace MercadoPago.Resource.MerchantOrder
{
    using System;

    /// <summary>
    /// Represents a payment associated with a <see cref="MerchantOrder"/>.
    /// Contains the payment amount, status, currency, and timing details for an individual
    /// payment attempt or completed transaction within the order.
    /// </summary>
    public class MerchantOrderPayment
    {
        /// <summary>
        /// Unique identifier of the payment, assigned by MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Base transaction amount charged for products or services, excluding shipping and fees.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Total amount paid by the buyer, including shipping cost and any additional fees.
        /// </summary>
        public decimal? TotalPaidAmount { get; set; }

        /// <summary>
        /// Shipping cost included in this payment, in the payment currency.
        /// </summary>
        public decimal? ShippingCost { get; set; }

        /// <summary>
        /// ISO 4217 currency code for this payment (e.g., <c>ARS</c>, <c>BRL</c>, <c>MXN</c>).
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Current status of the payment (e.g., <c>approved</c>, <c>pending</c>, <c>rejected</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Detailed reason for the current payment status, providing context about
        /// approvals, rejections, or pending states (e.g., <c>accredited</c>, <c>cc_rejected_other_reason</c>).
        /// </summary>
        public string StatusDetails { get; set; }

        /// <summary>
        /// Type of operation that originated this payment (e.g., <c>regular_payment</c>, <c>money_transfer</c>).
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// Date and time when the payment was approved. <c>null</c> if the payment has not been approved.
        /// </summary>
        public DateTime? DateApproved { get; set; }

        /// <summary>
        /// Date and time when the payment was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last modification to this payment record.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Total amount that has been refunded for this specific payment.
        /// </summary>
        public decimal? AmountRefunded { get; set; }
    }
}
