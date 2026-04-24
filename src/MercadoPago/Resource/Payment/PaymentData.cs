namespace MercadoPago.Resource.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Data associated with the payment method, including rules for discounts,
    /// fines, and interest, as well as external reference identifiers.
    /// Contained within <see cref="PaymentMethod"/>.
    /// </summary>
    public class PaymentData
    {
        /// <summary>
        /// Payment rules that define discounts, fines, and interest
        /// applicable to this payment.
        /// </summary>
        /// <seealso cref="PaymentRules"/>
        public PaymentRules Rules { get; set; }

        /// <summary>
        /// Internal reference identifier for this payment data within MercadoPago.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// External reference identifier provided by the merchant's system
        /// to correlate this payment data with their records.
        /// </summary>
        public string ExternalReferenceId { get; set; }

        /// <summary>
        /// URL pointing to an external resource related to this payment,
        /// such as an invoice or order detail page.
        /// </summary>
        public string ExternalResourceUrl { get; set; }
    }
}
