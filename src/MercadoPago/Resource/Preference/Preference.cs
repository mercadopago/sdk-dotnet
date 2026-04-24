namespace MercadoPago.Resource.Preference
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a Preference API response, which defines the checkout configuration
    /// for Checkout Pro. A preference includes the items to purchase, payer information,
    /// payment methods, shipping options, and redirect URLs.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/resource/">here</a>.
    /// </remarks>
    public class Preference : IResource
    {
        /// <summary>
        /// Unique identifier of the preference, assigned by MercadoPago.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// List of items to be purchased through this preference.
        /// Each <see cref="PreferenceItem"/> describes a product or service with its price and quantity.
        /// </summary>
        public IList<PreferenceItem> Items { get; set; }

        /// <summary>
        /// Information about the payer (buyer) for this checkout session.
        /// Used to pre-fill payer data and improve fraud analysis.
        /// </summary>
        public PreferencePayer Payer { get; set; }

        /// <summary>
        /// Payment method configuration that controls which methods are available,
        /// excluded, or set as default during the checkout flow.
        /// </summary>
        public PreferencePaymentMethods PaymentMethods { get; set; }

        /// <summary>
        /// Redirect URLs where the buyer is sent after the checkout flow completes.
        /// Separate URLs can be configured for success, pending, and failure outcomes.
        /// </summary>
        public PreferenceBackUrls BackUrls { get; set; }

        /// <summary>
        /// Shipping configuration for this preference, including mode, cost,
        /// free shipping options, and the receiver address.
        /// </summary>
        public PreferenceShipments Shipments { get; set; }

        /// <summary>
        /// Webhook URL where MercadoPago will send IPN (Instant Payment Notification) events
        /// about payment status changes for this preference.
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// Text that will appear on the payer's credit card statement (e.g., "MERCADOPAGO").
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// External reference ID that the merchant can use to synchronize this preference
        /// with their own payment or order management system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Indicates whether the preference has an expiration window.
        /// <c>true</c> if the preference can expire, <c>false</c> if it remains active indefinitely.
        /// </summary>
        public bool? Expires { get; set; }

        /// <summary>
        /// Expiration date for cash-based payment methods (e.g., boleto, OXXO).
        /// After this date, the payment slip can no longer be used.
        /// </summary>
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Date and time from which the preference becomes active and available for checkout.
        /// </summary>
        public DateTime? ExpirationDateFrom { get; set; }

        /// <summary>
        /// Date and time after which the preference expires and is no longer available for checkout.
        /// </summary>
        public DateTime? ExpirationDateTo { get; set; }

        /// <summary>
        /// MercadoPago user ID of the seller (collector) who will receive the payment.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Origin of the payment, identifying the marketplace or platform.
        /// Default value: <c>NONE</c> for direct integrations.
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Fee amount charged by the marketplace (application owner) on the transaction.
        /// Deducted from the seller's received amount.
        /// </summary>
        public decimal? MarketplaceFee { get; set; }

        /// <summary>
        /// Purpose of the preference, which determines the checkout behavior.
        /// Use <c>wallet_purchase</c> to restrict payment to the MercadoPago wallet only.
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// Free-text field for any additional information the merchant wants to attach to the preference.
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Controls automatic redirection after checkout. When set to <c>approved</c> or <c>all</c>,
        /// buyers are redirected back to the merchant site immediately after completing the purchase.
        /// </summary>
        public string AutoReturn { get; set; }

        /// <summary>
        /// Type of operation for this preference (e.g., <c>regular_payment</c>, <c>money_transfer</c>).
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// Differential pricing configuration that allows offering different prices to specific buyer segments.
        /// </summary>
        public PreferenceDifferentialPricing DifferentialPricing { get; set; }

        /// <summary>
        /// MercadoPago user ID of the sponsor (marketplace or platform) associated with this preference.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// List of processing modes to use for payments created from this preference.
        /// Common values: <c>aggregator</c>, <c>gateway</c>.
        /// </summary>
        public IList<string> ProcessingModes { get; set; }

        /// <summary>
        /// When set to <c>true</c>, the payment can only result in <c>approved</c> or <c>rejected</c>.
        /// When <c>false</c>, the <c>in_process</c> (pending review) status is also possible.
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// List of taxes applied to this preference.
        /// Each <see cref="PreferenceTax"/> specifies a tax type and its monetary value.
        /// </summary>
        public IList<PreferenceTax> Taxes { get; set; }

        /// <summary>
        /// List of tracking pixels or conversion tags executed during the buyer's interaction
        /// in the Checkout Pro flow (e.g., Google Ads, Facebook Pixel).
        /// </summary>
        public IList<PreferenceTrack> Tracks { get; set; }

        /// <summary>
        /// Computed amounts breakdown for this preference, showing totals for both the collector and payer.
        /// </summary>
        public PreferenceAmountsResponse Amounts { get; set; }

        /// <summary>
        /// Counter-currency information when the preference involves cross-currency transactions.
        /// </summary>
        public PreferenceCounterCurrencyResponse CounterCurrency { get; set; }

        /// <summary>
        /// Free-form key-value metadata that can be attached to the preference
        /// to store additional merchant-defined attributes.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Production checkout URL. Redirect the buyer to this URL to start the Checkout Pro flow.
        /// </summary>
        public string InitPoint { get; set; }

        /// <summary>
        /// Sandbox checkout URL for testing. Use this URL instead of <see cref="InitPoint"/>
        /// when testing in the MercadoPago sandbox environment.
        /// </summary>
        public string SandboxInitPoint { get; set; }

        /// <summary>
        /// Date and time when the preference was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
