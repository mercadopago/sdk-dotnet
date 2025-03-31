using System.Collections.Generic;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Payment method configuration class.
    /// </summary>
    public class OrderPaymentMethodConfigRequest
    {
        /// <summary>
        /// Not allowed payment method IDs.
        /// </summary>
        public List<string> NotAllowedIds { get; set; }

        /// <summary>
        /// Not allowed payment method types.
        /// </summary>
        public List<string> NotAllowedTypes { get; set; }

        /// <summary>
        /// Default payment method ID.
        /// </summary>
        public string DefaultId { get; set; }

        /// <summary>
        /// Max installments.
        /// </summary>
        public string MaxInstallments { get; set; }

        /// <summary>
        ///  Default installments.
        /// </summary>
        public string DefaultInstallments { get; set; }
    }
}
