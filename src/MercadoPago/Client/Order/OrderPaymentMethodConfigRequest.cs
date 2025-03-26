using System.Collections.Generic;

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
