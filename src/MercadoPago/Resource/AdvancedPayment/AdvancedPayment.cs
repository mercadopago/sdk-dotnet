namespace MercadoPago.Resource.AdvancedPayment
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents an Advanced Payment API response, which enables split payments
    /// between multiple sellers (disbursements) within a single transaction from the payer.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/advanced_payments/resource/">here</a>.
    /// </remarks>
    public class AdvancedPayment : IResource
    {
        /// <summary>
        /// Unique identifier of the advanced payment, assigned by MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Current status of the advanced payment.
        /// Possible values are defined in <see cref="AdvancedPaymentStatus"/>.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Description or reason for the advanced payment, typically used to explain the transaction purpose.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// External reference ID assigned by the merchant in their own system.
        /// Used to reconcile the advanced payment with the merchant's internal records.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Information about the payer who is making the advanced payment.
        /// </summary>
        public AdvancedPaymentPayer Payer { get; set; }

        /// <summary>
        /// List of split payments made by the payer. Each <see cref="AdvancedPaymentSplitPayment"/>
        /// represents one portion of the total transaction, including payment method details and amounts.
        /// </summary>
        public IList<AdvancedPaymentSplitPayment> Payments { get; set; }

        /// <summary>
        /// List of disbursements that distribute funds to each seller.
        /// Each <see cref="AdvancedPaymentDisbursement"/> specifies the receiver, amount,
        /// and fee configuration for one seller's portion of the payment.
        /// </summary>
        public IList<AdvancedPaymentDisbursement> Disbursements { get; set; }

        /// <summary>
        /// Identifier of the marketplace (application) that originated the advanced payment.
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// When set to <c>true</c>, the payment can only be approved or rejected.
        /// Otherwise, the payment may remain in a pending state.
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// Determines if the payment should be captured immediately (<c>true</c>)
        /// or only reserved/authorized (<c>false</c>). When <c>false</c>, a subsequent
        /// capture call is required to complete the charge.
        /// </summary>
        public bool? Capture { get; set; }

        /// <summary>
        /// Supplementary data that can improve fraud analysis and conversion rates.
        /// Includes item details, payer information, and shipping data.
        /// Send as much information as possible.
        /// </summary>
        public AdvancedPaymentAdditionalInfo AdditionalInfo { get; set; }

        /// <summary>
        /// Free-form key-value metadata that can be attached to the advanced payment
        /// to store additional merchant-defined attributes.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Date and time when the advanced payment was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last update to the advanced payment.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
