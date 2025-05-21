namespace MercadoPago.Resource.Payment
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;
    using Newtonsoft.Json;
    using MercadoPago.Client.Common;

    /// <summary>
    /// Payment resource.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/payments/resource/">here</a>.
    /// </remarks>
    public class Payment : IResource
    {
        /// <summary>
        /// Payment ID.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Approval date.
        /// </summary>
        public DateTime? DateApproved { get; set; }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Date of expiration.
        /// </summary>
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Release date.
        /// </summary>
        public DateTime? MoneyReleaseDate { get; set; }

        /// <summary>
        /// Operation type.
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// Payment method issuer.
        /// </summary>
        public string IssuerId { get; set; }

        /// <summary>
        /// Payment method chosen to do the payment.
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Payment type.
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Status detail.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Currency information.
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Payment reason or item title.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Live mode.
        /// </summary>
        public bool? LiveMode { get; set; }

        /// <summary>
        /// Sponsor Identification.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// Authorization code.
        /// </summary>
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Integrator identification.
        /// </summary>
        public string IntegratorId { get; set; }

        /// <summary>
        /// Platform identification.
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// Corporation identification.
        /// </summary>
        public string CorporationId { get; set; }

        /// <summary>
        /// Collector ID.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Payer information.
        /// </summary>
        public PaymentPayer Payer { get; set; }

        /// <summary>
        /// Data that can be attached to the payment to record additional
        /// attributes of the merchant.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Data that could improve fraud analysis and conversion rates.
        /// Try to send as much information as possible.
        /// </summary>
        public PaymentAdditionalInfo AdditionalInfo { get; set; }

        /// <summary>
        /// Order identifier
        /// </summary>
        public PaymentOrder Order { get; set; }

        /// <summary>
        /// ID given by the merchant in their system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Amount paid.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Total refunded amount.
        /// </summary>
        public decimal? TransactionAmountRefunded { get; set; }

        /// <summary>
        /// Amount of the coupon.
        /// </summary>
        public decimal? CouponAmount { get; set; }

        /// <summary>
        /// Id of the scheme for the absorption of financing fee.
        /// </summary>
        public int? DifferentialPricingId { get; set; }

        /// <summary>
        /// Selected quantity of installments
        /// </summary>
        public int? Installments { get; set; }

        /// <summary>
        /// Transaction details.
        /// </summary>
        public PaymentTransactionDetails TransactionDetails { get; set; }

        /// <summary>
        /// Fee details.
        /// </summary>
        public IList<PaymentFeeDetail> FeeDetails { get; set; }

        /// <summary>
        /// If the payment is captured (<c>true</c>)
        /// or just reserved (<c>false</c>).
        /// </summary>
        public bool? Captured { get; set; }

        /// <summary>
        /// When set to true, the payment can only be approved or rejected.
        /// Otherwise in_process status is added.
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// Gives more detailed information on the current state or rejection cause.
        /// </summary>
        public string CallForAuthorizeId { get; set; }

        /// <summary>
        /// How will look the payment in the card bill.
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Card used to pay.
        /// </summary>
        public PaymentCard Card { get; set; }

        /// <summary>
        /// URL where mercadopago will send notifications associated to changes in this payment.
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// URL where mercadopago does the final redirect (only for bank transfers).
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Processing mode to define if an specific merchant id should be used.
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Merchant Id for complex payment cases.
        /// </summary>
        public string MerchantAccountId { get; set; }

        /// <summary>
        /// Discount campaign ID.
        /// </summary>
        public int? CampaignId { get; set; }

        /// <summary>
        /// Discount campaign coupon code.
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// Payment net amount.
        /// </summary>
        public decimal? NetAmount { get; set; }

        /// <summary>
        /// Payment method option id.
        /// </summary>
        public string PaymentMethodOptionId { get; set; }

        /// <summary>
        /// Taxes for payments.
        /// </summary>
        public IList<PaymentTax> Taxes { get; set; }

        /// <summary>
        /// Refunds.
        /// </summary>
        public IList<PaymentRefund> Refunds { get; set; }

        /// <summary>
        /// Point of interaction.
        /// </summary>
        public PaymentPointOfInteraction PointOfInteraction { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }

        /// <summary>
        /// Payment method.
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// 3DS Info.
        ///</summary>
        [JsonProperty(PropertyName = "three_ds_info")]
        public PaymentThreeDSInfo ThreeDSInfo { get; set; }

        /// <summary>
        /// Internal data that can be attached to the payment to record additional
        /// attributes of the merchant.
        /// </summary>
        public IDictionary<string, object> InternalMetadata { get; set; }

        /// <summary>
        /// Forward data information.
        /// </summary>
        public NetworkTransactionData ForwardData { get; set; }

        /// <summary>
        /// Expanded data information.
        /// </summary>
        public PaymentExpandedData Expanded { get; set; }
    }
}
