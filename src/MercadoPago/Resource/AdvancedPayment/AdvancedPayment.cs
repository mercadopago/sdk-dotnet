namespace MercadoPago.Resource.AdvancedPayment
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Advanced Payment resource.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/advanced_payments/resource/">here</a>.
    /// </remarks>
    public class AdvancedPayment : IResource
    {
        /// <summary>
        /// Advanced payment ID.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Advanced payment status.
        /// </summary>
        public string Status { get; set; }

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
        public AdvancedPaymentPayer Payer { get; set; }

        /// <summary>
        /// List of payments made by the payer.
        /// </summary>
        public IList<AdvancedPaymentSplitPayment> Payments { get; set; }

        /// <summary>
        /// List of payments that correspond to each seller.
        /// </summary>
        public IList<AdvancedPaymentDisbursement> Disbursements { get; set; }

        /// <summary>
        /// Marketplace (Application).
        /// </summary>
        public string Marketplace { get; set; }

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
        public AdvancedPaymentAdditionalInfo AdditionalInfo { get; set; }

        /// <summary>
        /// Data that can be attached to the advanced payment to record additional
        /// attributes of the merchant.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Advanced payment date of creation.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Last time the advanced payment was updated.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
