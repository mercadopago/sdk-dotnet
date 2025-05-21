namespace MercadoPago.Client.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Parameters to create a payment.
    /// </summary>
    /// <remarks>
    /// Check the parameters
    /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments/post/">here</a>.
    /// </remarks>
    public class PaymentCreateRequest : IdempotentRequest
    {
        /// <summary>
        /// Payer information.
        /// </summary>
        public PaymentPayerRequest Payer { get; set; }

        /// <summary>
        /// When set to true, the payment can only be approved or rejected.
        /// Otherwise in_process status is added.
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// Order identifier.
        /// </summary>
        public PaymentOrderRequest Order { get; set; }

        /// <summary>
        /// ID given by the merchant in their system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Payment reason or item title.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data that can be attached to the payment to record additional
        /// attributes of the merchant.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Amount paid.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Net amount.
        /// </summary>
        public decimal? NetAmount { get; set; }

        /// <summary>
        /// Amount of the coupon discount.
        /// </summary>
        public decimal? CouponAmount { get; set; }

        /// <summary>
        /// Discount campaign ID.
        /// </summary>
        public int? CampaignId { get; set; }

        /// <summary>
        /// Discount campaign with a specific code.
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// Id of the scheme for the absorption of financing fee.
        /// </summary>
        public int? DifferentialPricingId { get; set; }

        /// <summary>
        /// Fee collected by a marketplace or MercadoPago Application.
        /// </summary>
        public decimal? ApplicationFee { get; set; }

        /// <summary>
        /// Determines if the payment should be captured (<c>true</c>)
        /// or just reserved (<c>false</c>).
        /// </summary>
        public bool? Capture { get; set; }

        /// <summary>
        /// Payment method chosen to do the payment.
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Payment method issuer
        /// </summary>
        public string IssuerId { get; set; }

        /// <summary>
        /// Card token ID.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// How will look the payment in the card bill (e.g.: MERCADOPAGO).
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Selected quantity of installments.
        /// </summary>
        public int? Installments { get; set; }

        /// <summary>
        /// URL where mercadopago will send notifications associated to changes in this payment.
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// URL where mercadopago does the final redirect (only for bank transfers).
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Processing mode to define if an specific merchannt id should be used.
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Merchant Id for complex payment cases.
        /// </summary>
        public string MerchantAccountId { get; set; }

        /// <summary>
        /// Date of expiration.
        /// </summary>
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Sponsor Identification.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// Payment method option id.
        /// </summary>
        public string PaymentMethodOptionId { get; set; }

        /// <summary>
        /// Marketplace.
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Transaction details.
        /// </summary>
        public PaymentTransactionDetailsRequest TransactionDetails { get; set; }

        /// <summary>
        /// Data that could improve fraud analysis and conversion rates.
        /// Try to send as much information as possible.
        /// </summary>
        public PaymentAdditionalInfoRequest AdditionalInfo { get; set; }

        /// <summary>
        /// Point Of Interaction.
        /// </summary>
        public PaymentPointOfInteractionRequest PointOfInteraction { get; set; }

        /// <summary>
        /// Taxes for payments.
        /// </summary>
        public IList<PaymentTaxRequest> Taxes { get; set; }

        /// <summary>
        /// Merchant services.
        /// </summary>
        public PaymentMerchantServicesRequest MerchantServices { get; set; }

        /// <summary>
        /// Rules.
        /// </summary>
        public PaymentMethodRequest PaymentMethod { get; set; }

        ///<summary>
        /// 3DS.
        ///</summary>
        public string ThreeDSecureMode { get; set; }

        ///<summary>
        /// Rules.
        ///</summary>
        public PaymentForwardDataRequest PaymentForwardDataRequest { get; set; }

        ///<summary>
        /// Forward data information.
        ///</summary>
        public PaymentForwardDataRequest ForwardData { get; set; }
    }
}

