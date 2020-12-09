namespace MercadoPago.Resource.PaymentMethod
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Payment Method resource.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/payment_methods/resource/">here</a>.
    /// </remarks>
    public class PaymentMethod : IResource
    {
        /// <summary>
        /// Payment method ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Payment method name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Types of payment method.
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Payment method status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Logo to display in secure sites.
        /// </summary>
        public string SecureThumbnail { get; set; }

        /// <summary>
        /// Logo to show.
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// Whether the capture can be delayed or not.
        /// </summary>
        public string DeferredCapture { get; set; }

        /// <summary>
        /// Payment method settings.
        /// </summary>
        public IList<PaymentMethodSettings> Settings { get; set; }

        /// <summary>
        /// List of additional information that must be supplied by the payer.
        /// </summary>
        public IList<string> AdditionalInfoNeeded { get; set; }

        /// <summary>
        /// Minimum amount that can be processed with this payment method.
        /// </summary>
        public decimal? MinAllowedAmount { get; set; }

        /// <summary>
        /// Maximum amount that can be processed with this payment method.
        /// </summary>
        public decimal? MaxAllowedAmount { get; set; }

        /// <summary>
        /// How many time in minutes could happen until processing of the payment.
        /// </summary>
        public long? AccreditationTime { get; set; }

        /// <summary>
        /// Financial institution processing this payment method.
        /// </summary>
        public IList<PaymentMethodFinancialInstitutions> FinancialInstitutions { get; set; }

        /// <summary>
        /// Processing modes.
        /// </summary>
        public IList<string> ProcessingModes { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
