namespace MercadoPago.Resource.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Payment's data.
    /// </summary>
    public class PaymentData
    {
        /// <summary>
        /// Payment rules.
        /// </summary>
        public PaymentRules Rules { get; set; }

        /// <summary>
        /// Reference Id.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// External Reference Id.
        /// </summary>
        public string ExternalReferenceId { get; set; }

        /// <summary>
        /// External Resource Url.
        /// </summary>
        public string ExternalResourceUrl { get; set; }
    }
}
