namespace MercadoPago.Client.AdvancedPayment
{
    using System.Collections.Generic;

    /// <summary>
    /// Data to create a Advanced Payment.
    /// </summary>
    public class AdvancedPaymentCreateRequest : IdempotentRequest
    {
        /// <summary>
        /// Advanced payment description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID given by the merchant in their system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Payer information.
        /// </summary>
        public AdvancedPaymentPayerRequest Payer { get; set; }

        /// <summary>
        /// List of payments made by the payer.
        /// </summary>
        public IList<AdvancedPaymentSplitPaymentRequest> Payments { get; set; }

        /// <summary>
        /// List of payments that correspond to each seller.
        /// </summary>
        public IList<AdvancedPaymentDisbursementRequest> Disbursements { get; set; }

        /// <summary>
        /// Application ID.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// When set to true, the payment can only be approved or rejected.
        /// Otherwise, the payment may be pending.
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// Determines if the payment should be captured (<c>true</c>)
        /// or just reserved (<c>false</c>).
        /// </summary>
        public bool? Capture { get; set; }

        /// <summary>
        /// Data that could improve fraud analysis and conversion rates.
        /// Try to send as much information as possible.
        /// </summary>
        public AdvancedPaymentAdditionalInfoRequest AdditionalInfo { get; set; }

        /// <summary>
        /// Data that can be attached to the advanced payment to record additional
        /// attributes of the merchant.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }
    }
}
