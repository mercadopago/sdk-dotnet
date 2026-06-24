using System.Collections.Generic;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Interest-free installment configuration for an order.
    /// </summary>
    /// <seealso cref="OrderInstallmentsRequest"/>
    public class OrderInstallmentsInterestFreeRequest
    {
        /// <summary>
        /// Interest-free installment configuration type (e.g., "range", "list", or "none").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Installment values used by the configured type.
        /// </summary>
        public IList<int> Values { get; set; }
    }
}
