using System.Collections.Generic;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Configuration that restricts or customizes the payment methods available to the payer
    /// during checkout, including exclusion lists and installment limits.
    /// </summary>
    /// <seealso cref="OrderConfigRequest"/>
    public class OrderPaymentMethodConfigRequest
    {
        /// <summary>
        /// List of payment method IDs that are not allowed for this order (e.g., "visa", "master").
        /// </summary>
        public List<string> NotAllowedIds { get; set; }

        /// <summary>
        /// List of payment method types that are not allowed (e.g., "credit_card", "ticket").
        /// </summary>
        public List<string> NotAllowedTypes { get; set; }

        /// <summary>
        /// Payment method ID to pre-select as the default in the checkout.
        /// </summary>
        public string DefaultId { get; set; }

        /// <summary>
        /// Maximum number of installments the payer can choose.
        /// </summary>
        public string MaxInstallments { get; set; }

        /// <summary>
        /// Default number of installments pre-selected in the checkout.
        /// </summary>
        public string DefaultInstallments { get; set; }
    }
}
