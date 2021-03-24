namespace MercadoPago.Resource.MerchantOrder
{
    using System;

    /// <summary>
    /// Payment information.
    /// </summary>
    public class MerchantOrderPayment
    {
        /// <summary>
        /// Payment ID.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Product cost.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Total amount paid.
        /// </summary>
        public decimal? TotalPaidAmount { get; set; }

        /// <summary>
        /// Shipping fee.
        /// </summary>
        public decimal? ShippingCost { get; set; }

        /// <summary>
        /// ID of the currency used in payment.
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Payment status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gives more detailed information on the current state or rejection cause.
        /// </summary>
        public string StatusDetails { get; set; }

        /// <summary>
        /// Operation type.
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// Approvation date.
        /// </summary>
        public DateTime? DateApproved { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Amount refunded in this payment.
        /// </summary>
        public decimal? AmountRefunded { get; set; }
    }
}
