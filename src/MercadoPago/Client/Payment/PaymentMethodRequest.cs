namespace MercadoPago.Client.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Payment method details for a <see cref="PaymentCreateRequest"/>.
    /// Specifies the payment method type and associated data such as rules for discounts,
    /// fines, interest, and 3DS authentication.
    /// </summary>
    public class PaymentMethodRequest
    {
        /// <summary>
        /// Payment method data including rules and authentication details.
        /// </summary>
        /// <seealso cref="PaymentDataRequest"/>
        public PaymentDataRequest Data { get; set; }

        /// <summary>
        /// Payment method type (e.g., "credit_card", "debit_card", "bank_transfer", "ticket").
        /// </summary>
        public string Type { get; set; }
    }
}