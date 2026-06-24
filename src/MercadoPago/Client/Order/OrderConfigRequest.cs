// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Top-level configuration for a payment order, grouping payment method restrictions
    /// and online checkout behavior settings.
    /// </summary>
    /// <seealso cref="OrderCreateRequest"/>
    /// <seealso cref="OrderPaymentMethodConfigRequest"/>
    /// <seealso cref="OrderOnlineConfigRequest"/>
    public class OrderConfigRequest
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
        /// Payment method restrictions and defaults, such as excluded methods, maximum
        /// installments, and the default payment method.
        /// </summary>
        public OrderPaymentMethodConfigRequest PaymentMethod { get; set; }

        /// <summary>
        /// Configuration specific to the online checkout flow, including redirect URLs,
        /// differential pricing, and 3-D Secure settings.
        /// </summary>
        public OrderOnlineConfigRequest Online { get; set; }
    }
}
