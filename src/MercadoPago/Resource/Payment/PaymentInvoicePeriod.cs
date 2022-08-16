namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Payment's invoice period.
    /// </summary>
    public class PaymentInvoicePeriod
    {
        /// <summary>
        /// Period.
        /// </summary>
        public int? Period { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public string Type { get; set; }
    }
}