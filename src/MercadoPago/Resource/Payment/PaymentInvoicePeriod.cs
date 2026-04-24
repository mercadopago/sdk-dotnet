namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Invoice period information for subscription-based or recurring payments,
    /// defining the billing cycle length and type.
    /// Part of <see cref="PaymentTransactionData"/>.
    /// </summary>
    public class PaymentInvoicePeriod
    {
        /// <summary>
        /// Numeric value representing the billing cycle length
        /// (e.g., 1 for monthly, 3 for quarterly), interpreted together
        /// with the <see cref="Type"/>.
        /// </summary>
        public int? Period { get; set; }

        /// <summary>
        /// Unit of the billing period. Possible values include "monthly",
        /// "yearly", or other time-based units.
        /// </summary>
        public string Type { get; set; }
    }
}