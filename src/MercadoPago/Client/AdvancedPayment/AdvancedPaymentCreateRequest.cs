namespace MercadoPago.Client.AdvancedPayment
{
    using System.Collections.Generic;

    /// <summary>
    /// Request payload for creating an advanced (split) payment that distributes funds
    /// across multiple receivers. This is the top-level DTO sent to the
    /// <see cref="AdvancedPaymentClient.Create"/> and <see cref="AdvancedPaymentClient.CreateAsync"/> methods.
    /// </summary>
    public class AdvancedPaymentCreateRequest : IdempotentRequest
    {
        /// <summary>
        /// Human-readable description of the advanced payment, shown to the payer during checkout.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Unique reference identifier assigned by the merchant in their own system for reconciliation.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Information about the buyer making the payment.
        /// </summary>
        /// <see cref="AdvancedPaymentPayerRequest"/>
        public AdvancedPaymentPayerRequest Payer { get; set; }

        /// <summary>
        /// List of split payments made by the payer, each representing a distinct payment method or card.
        /// </summary>
        /// <see cref="AdvancedPaymentSplitPaymentRequest"/>
        public IList<AdvancedPaymentSplitPaymentRequest> Payments { get; set; }

        /// <summary>
        /// List of disbursements specifying how funds are distributed to each seller or receiver.
        /// </summary>
        /// <see cref="AdvancedPaymentDisbursementRequest"/>
        public IList<AdvancedPaymentDisbursementRequest> Disbursements { get; set; }

        /// <summary>
        /// MercadoPago application identifier that originated this payment.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// When set to <c>true</c>, the payment can only be approved or rejected.
        /// When <c>false</c> or <c>null</c>, the payment may remain in a pending state.
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// Determines whether the payment should be immediately captured (<c>true</c>)
        /// or only authorized and reserved for later capture (<c>false</c>).
        /// </summary>
        public bool? Capture { get; set; }

        /// <summary>
        /// Supplementary data that improves fraud analysis and conversion rates.
        /// Send as much information as possible for best results.
        /// </summary>
        /// <see cref="AdvancedPaymentAdditionalInfoRequest"/>
        public AdvancedPaymentAdditionalInfoRequest AdditionalInfo { get; set; }

        /// <summary>
        /// Arbitrary key-value pairs attached to the advanced payment for storing
        /// custom merchant-specific attributes. Keys must be strings.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }
    }
}
