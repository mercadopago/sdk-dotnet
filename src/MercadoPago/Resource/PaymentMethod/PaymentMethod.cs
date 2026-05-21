namespace MercadoPago.Resource.PaymentMethod
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a payment method available in MercadoPago for the caller's
    /// country (e.g. Visa, Mastercard, Pix, OXXO). Returned as a list by the
    /// Payment Methods API. Use
    /// <see cref="Client.PaymentMethod.PaymentMethodClient"/> to retrieve the
    /// available payment methods.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/payment-methods/get">here</a>.
    /// </remarks>
    public class PaymentMethod : IResource
    {
        /// <summary>
        /// Unique payment method identifier (e.g. <c>visa</c>, <c>pix</c>,
        /// <c>bolbradesco</c>).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the payment method (e.g. "Visa", "Pix").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Payment type identifier that classifies this method (e.g.
        /// <c>credit_card</c>, <c>debit_card</c>, <c>ticket</c>,
        /// <c>bank_transfer</c>).
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Current availability status of the payment method (e.g.
        /// <c>active</c>, <c>deactive</c>, <c>temporally_deactive</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// HTTPS URL of the payment method logo, suitable for use on secure
        /// pages.
        /// </summary>
        public string SecureThumbnail { get; set; }

        /// <summary>
        /// URL of the payment method logo thumbnail.
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// Indicates whether the payment method supports deferred (two-step)
        /// capture (<c>supported</c>, <c>unsupported</c>, or
        /// <c>does_not_apply</c>).
        /// </summary>
        public string DeferredCapture { get; set; }

        /// <summary>
        /// List of validation settings for this payment method, including BIN
        /// patterns, card number length, and security code rules.
        /// </summary>
        public IList<PaymentMethodSettings> Settings { get; set; }

        /// <summary>
        /// List of additional payer information fields required by this
        /// payment method (e.g. <c>cardholder_name</c>,
        /// <c>cardholder_identification_number</c>).
        /// </summary>
        public IList<string> AdditionalInfoNeeded { get; set; }

        /// <summary>
        /// Minimum transaction amount allowed for this payment method.
        /// </summary>
        public decimal? MinAllowedAmount { get; set; }

        /// <summary>
        /// Maximum transaction amount allowed for this payment method.
        /// </summary>
        public decimal? MaxAllowedAmount { get; set; }

        /// <summary>
        /// Estimated time in minutes for the payment to be accredited after
        /// processing.
        /// </summary>
        public long? AccreditationTime { get; set; }

        /// <summary>
        /// Financial institutions that process this payment method (e.g.
        /// banks available for bank-transfer methods).
        /// </summary>
        public IList<PaymentMethodFinancialInstitutions> FinancialInstitutions { get; set; }

        /// <summary>
        /// Processing modes supported by this payment method (e.g.
        /// <c>aggregator</c>, <c>gateway</c>).
        /// </summary>
        public IList<string> ProcessingModes { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
