namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Payment method (card brand) associated with a
    /// <see cref="CustomerCard"/>. Provides brand identification and logo URLs.
    /// </summary>
    public class CustomerCardPaymentMethod
    {
        /// <summary>
        /// Payment method identifier (e.g. <c>visa</c>, <c>master</c>,
        /// <c>amex</c>).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the payment method (e.g. "Visa", "Mastercard").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Payment type identifier (e.g. <c>credit_card</c>,
        /// <c>debit_card</c>).
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// URL of the payment method logo thumbnail.
        /// </summary>
        public string Thumbnail { get; set; }


        /// <summary>
        /// HTTPS URL of the payment method logo, suitable for use on secure
        /// pages.
        /// </summary>
        public string SecureThumbnail { get; set; }
    }
}
