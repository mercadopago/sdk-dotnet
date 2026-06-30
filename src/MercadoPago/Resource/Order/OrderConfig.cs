// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Order-level configuration returned by the API, grouping payment method rules and online checkout behavior.
    /// </summary>
    /// <seealso cref="Order"/>
    public class OrderConfig
    {
        /// <summary>
        /// Text shown on the payer's credit card statement.
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Default offline payment expiration duration in ISO 8601 duration format.
        /// </summary>
        public string DefaultPaymentDueDate { get; set; }

        /// <summary>
        /// Configuration specific to the online checkout flow.
        /// </summary>
        /// <seealso cref="OrderOnlineConfig"/>
        public OrderOnlineConfig Online { get; set; }

        /// <summary>
        /// Payment method constraints configured for this order.
        /// </summary>
        /// <seealso cref="OrderPaymentMethodConfig"/>
        public OrderPaymentMethodConfig PaymentMethod { get; set; }
    }
}
