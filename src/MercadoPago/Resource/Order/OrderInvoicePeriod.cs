// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Invoice Period class.
    /// </summary>
    public class OrderInvoicePeriod
    {
        /// <summary>
        /// Type of invoice.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Period of invoice.
        /// </summary>
        public int? Period { get; set; }
    }
}
