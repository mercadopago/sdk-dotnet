namespace MercadoPago.Resource.Payment
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;
    using Newtonsoft.Json;
    using MercadoPago.Client.Common;

    /// <summary>
    /// Represents a payment processed through the MercadoPago Payments API,
    /// containing status, amounts, payer details, and transaction metadata.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/payments/resource/">here</a>.
    /// </remarks>
    public class Payment : IResource
    {
        /// <summary>
        /// Unique payment identifier assigned by MercadoPago upon creation.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Date and time (ISO 8601) when the payment was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time (ISO 8601) when the payment was approved.
        /// This value is <c>null</c> until the payment reaches the "approved" status.
        /// </summary>
        public DateTime? DateApproved { get; set; }

        /// <summary>
        /// Date and time (ISO 8601) of the last status change or update to this payment.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Date and time (ISO 8601) after which the payment will be automatically expired
        /// if it has not been approved. Applies to pending or in-process payments.
        /// </summary>
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Date and time (ISO 8601) when the funds are released and available
        /// for withdrawal by the collector.
        /// </summary>
        public DateTime? MoneyReleaseDate { get; set; }

        /// <summary>
        /// Type of operation. Possible values: "regular_payment", "money_transfer",
        /// "recurring_payment", "account_fund", "payment_addition",
        /// "cellphone_recharge", "pos_payment".
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// Identifier of the issuer (bank or financial institution) of the payment method.
        /// </summary>
        public string IssuerId { get; set; }

        /// <summary>
        /// Identifier of the payment method chosen to process this payment
        /// (e.g., "visa", "master", "pix", "bolbradesco").
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Type of payment method. Possible values: "credit_card", "debit_card",
        /// "ticket", "bank_transfer", "atm", "prepaid_card", "digital_currency", "digital_wallet", "voucher_card",
        /// "crypto_transfer".
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Current payment status. Possible values: "pending", "approved",
        /// "authorized", "in_process", "in_mediation", "rejected", "cancelled",
        /// "refunded", "charged_back".
        /// </summary>
        /// <seealso cref="PaymentStatus"/>
        public string Status { get; set; }

        /// <summary>
        /// Detailed status information providing the reason behind the current
        /// <see cref="Status"/>. For example, "accredited", "pending_contingency",
        /// "cc_rejected_insufficient_amount", among others.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// ISO 4217 currency code of the payment amount (e.g., "ARS", "BRL", "MXN", "USD").
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Payment reason or item title. This text is displayed to the payer
        /// during the checkout flow and in receipts.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicates whether this payment was created in production (<c>true</c>)
        /// or sandbox (<c>false</c>) mode.
        /// </summary>
        public bool? LiveMode { get; set; }

        /// <summary>
        /// MercadoPago account ID of the sponsor (marketplace or platform)
        /// that facilitated this payment. Used in marketplace integrations.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// Authorization code returned by the card issuer upon approval.
        /// </summary>
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Identifier of the integrator (third-party developer) processing
        /// this payment, as registered in the MercadoPago partner program.
        /// </summary>
        public string IntegratorId { get; set; }

        /// <summary>
        /// Identifier of the platform (marketplace or e-commerce solution)
        /// through which this payment was created.
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// Identifier of the corporation that owns or manages the integrator
        /// application processing this payment.
        /// </summary>
        public string CorporationId { get; set; }

        /// <summary>
        /// MercadoPago account ID of the collector (seller) who receives this payment.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Information about the payer (buyer) who made this payment,
        /// including identification, email, and personal data.
        /// </summary>
        /// <seealso cref="PaymentPayer"/>
        public PaymentPayer Payer { get; set; }

        /// <summary>
        /// Custom key-value data attached to the payment by the merchant to record
        /// additional attributes. Up to 20 key-value pairs are allowed.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Additional information that can improve fraud analysis and conversion rates.
        /// Includes items purchased, payer details, and shipping data.
        /// Try to send as much information as possible.
        /// </summary>
        /// <seealso cref="PaymentAdditionalInfo"/>
        public PaymentAdditionalInfo AdditionalInfo { get; set; }

        /// <summary>
        /// Associated order information linking this payment to a purchase order.
        /// </summary>
        /// <seealso cref="PaymentOrder"/>
        public PaymentOrder Order { get; set; }

        /// <summary>
        /// External reference ID provided by the merchant in their own system.
        /// Useful for reconciliation between MercadoPago and the merchant's records.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Total amount charged for this payment, in the currency specified by
        /// <see cref="CurrencyId"/>. This is the base amount before fees.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Total amount that has been refunded to the payer for this payment.
        /// </summary>
        public decimal? TransactionAmountRefunded { get; set; }

        /// <summary>
        /// Discount coupon amount applied to this payment, reducing the
        /// effective cost for the payer.
        /// </summary>
        public decimal? CouponAmount { get; set; }

        /// <summary>
        /// Identifier of the differential pricing scheme that determines how
        /// financing fees are absorbed between payer and collector.
        /// </summary>
        public int? DifferentialPricingId { get; set; }

        /// <summary>
        /// Number of installments selected by the payer for this payment.
        /// A value of 1 indicates a single payment with no installment plan.
        /// </summary>
        public int? Installments { get; set; }

        /// <summary>
        /// Detailed breakdown of the transaction, including net received amount,
        /// total paid amount, installment amounts, and payment references.
        /// </summary>
        /// <seealso cref="PaymentTransactionDetails"/>
        public PaymentTransactionDetails TransactionDetails { get; set; }

        /// <summary>
        /// Breakdown of fees charged on this payment, including MercadoPago
        /// commissions and financing costs.
        /// </summary>
        /// <seealso cref="PaymentFeeDetail"/>
        public IList<PaymentFeeDetail> FeeDetails { get; set; }

        /// <summary>
        /// Indicates whether the payment has been captured (<c>true</c>)
        /// or is only authorized and reserved (<c>false</c>). Relevant for
        /// credit card payments with two-step capture flow.
        /// </summary>
        public bool? Captured { get; set; }

        /// <summary>
        /// When set to <c>true</c>, the payment can only be "approved" or "rejected".
        /// When <c>false</c>, the "in_process" status is also possible.
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// Identifier for the call-for-authorize flow, providing more detailed
        /// information about the current state or rejection cause for card payments
        /// that require additional authorization.
        /// </summary>
        public string CallForAuthorizeId { get; set; }

        /// <summary>
        /// Text that will appear on the payer's credit card statement.
        /// Maximum 22 characters.
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Information about the card used to pay, including first/last digits,
        /// expiration date, and cardholder data. Only present for card payments.
        /// </summary>
        /// <seealso cref="PaymentCard"/>
        public PaymentCard Card { get; set; }

        /// <summary>
        /// URL where MercadoPago will send webhook notifications (IPN)
        /// associated with status changes for this payment.
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// URL where MercadoPago performs the final redirect after the payer
        /// completes the payment process. Used primarily for bank transfers.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Processing mode that defines how the payment is handled.
        /// Possible values: "aggregator" (default) or "gateway".
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Merchant account identifier used in gateway processing mode
        /// for complex payment scenarios.
        /// </summary>
        public string MerchantAccountId { get; set; }

        /// <summary>
        /// Identifier of the discount campaign applied to this payment.
        /// </summary>
        public int? CampaignId { get; set; }

        /// <summary>
        /// Coupon code entered by the payer to apply a discount campaign
        /// to this payment.
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// Net amount received by the collector after deducting all fees
        /// from the <see cref="TransactionAmount"/>.
        /// </summary>
        public decimal? NetAmount { get; set; }

        /// <summary>
        /// Identifier of the selected payment method option when the
        /// payment method has multiple configurations or sub-options.
        /// </summary>
        public string PaymentMethodOptionId { get; set; }

        /// <summary>
        /// List of taxes applied to this payment, such as IVA or other
        /// country-specific taxes.
        /// </summary>
        /// <seealso cref="PaymentTax"/>
        public IList<PaymentTax> Taxes { get; set; }

        /// <summary>
        /// Breakdown of amounts for both the collector and the payer,
        /// including currency and net received values.
        /// </summary>
        /// <seealso cref="PaymentAmountsResponse"/>
        public PaymentAmountsResponse Amounts { get; set; }

        /// <summary>
        /// Counter-currency information for cross-border payments, including
        /// the exchange rate and converted amount.
        /// </summary>
        /// <seealso cref="PaymentCounterCurrencyResponse"/>
        public PaymentCounterCurrencyResponse CounterCurrency { get; set; }

        /// <summary>
        /// List of refunds associated with this payment. Each entry contains
        /// the refund amount, status, and creation date.
        /// </summary>
        /// <seealso cref="PaymentRefund"/>
        public IList<PaymentRefund> Refunds { get; set; }

        /// <summary>
        /// Information about where and how the payment interaction occurred,
        /// such as QR code, point of sale terminal, or online checkout.
        /// </summary>
        /// <seealso cref="PaymentPointOfInteraction"/>
        public PaymentPointOfInteraction PointOfInteraction { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }

        /// <summary>
        /// Detailed payment method information associated with this payment,
        /// including payment data and rules.
        /// </summary>
        /// <seealso cref="PaymentMethod"/>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// 3D Secure (3DS) authentication information for card payments
        /// that require additional cardholder verification.
        /// </summary>
        /// <seealso cref="PaymentThreeDSInfo"/>
        [JsonProperty(PropertyName = "three_ds_info")]
        public PaymentThreeDSInfo ThreeDSInfo { get; set; }

        /// <summary>
        /// Internal key-value metadata attached to the payment for recording
        /// additional merchant attributes. Reserved for internal use.
        /// </summary>
        public IDictionary<string, object> InternalMetadata { get; set; }

        /// <summary>
        /// Network transaction data forwarded from the payment processor,
        /// containing references used for recurring or subsequent transactions.
        /// </summary>
        public NetworkTransactionData ForwardData { get; set; }

        /// <summary>
        /// Expanded data containing additional gateway-level information
        /// for this payment, such as network transaction references.
        /// </summary>
        /// <seealso cref="PaymentExpandedData"/>
        public PaymentExpandedData Expanded { get; set; }
    }
}
