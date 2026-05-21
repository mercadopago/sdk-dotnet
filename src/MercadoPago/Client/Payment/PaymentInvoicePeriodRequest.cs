namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Invoice period details for a recurring payment within <see cref="PaymentTransactionDataRequest"/>.
    /// Specifies the billing cycle duration and type for subscription-based payments.
    /// </summary>
    public class PaymentInvoicePeriodRequest
    {
        /// <summary>
        /// Number of time units in the billing cycle (e.g., 1 for monthly, 7 for weekly).
        /// </summary>
        public int? Period { get; set; }

        /// <summary>
        /// Type of billing period (e.g., "daily", "monthly", "yearly").
        /// </summary>
        public string Type { get; set; }
    }
}