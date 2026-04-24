namespace MercadoPago.Client.Preference
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Client.Common;

    /// <summary>
    /// Request payload for creating or updating a Checkout Pro preference that defines the
    /// payment experience for the buyer, including items, payer data, payment methods,
    /// shipping options, redirect URLs, and other checkout behavior.
    /// </summary>
    /// <remarks>
    /// Check the documentation
    /// <a href="https://www.mercadopago.com/developers/en/reference/preferences/_checkout_preferences/post/">here</a>
    /// and <a href="https://www.mercadopago.com/developers/en/reference/preferences/_checkout_preferences_id/put/">here</a>.
    /// </remarks>
    /// <seealso cref="PreferenceClient"/>
    public class PreferenceRequest
    {
        /// <summary>
        /// List of items the buyer will pay for. At least one item is required to create a preference.
        /// </summary>
        /// <seealso cref="PreferenceItemRequest"/>
        public IList<PreferenceItemRequest> Items { get; set; }

        /// <summary>
        /// Buyer information used to pre-fill checkout fields and improve fraud analysis.
        /// </summary>
        /// <seealso cref="PreferencePayerRequest"/>
        public PreferencePayerRequest Payer { get; set; }

        /// <summary>
        /// Configuration for allowed, excluded, and default payment methods and installment options.
        /// </summary>
        /// <seealso cref="PreferencePaymentMethodsRequest"/>
        public PreferencePaymentMethodsRequest PaymentMethods { get; set; }

        /// <summary>
        /// URLs where the buyer is redirected after completing, pending, or failing a payment.
        /// </summary>
        /// <seealso cref="PreferenceBackUrlsRequest"/>
        public PreferenceBackUrlsRequest BackUrls { get; set; }

        /// <summary>
        /// Shipping configuration including mode, dimensions, cost, free shipping methods, and receiver address.
        /// </summary>
        /// <seealso cref="PreferenceShipmentsRequest"/>
        public PreferenceShipmentsRequest Shipments { get; set; }

        /// <summary>
        /// Webhook URL where MercadoPago will send payment status notifications (IPN).
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// Text that will appear on the buyer's credit card statement (e.g., "MERCADOPAGO").
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// External reference that you can synchronize with your own payment system to reconcile orders.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// <c>true</c> if this preference expires, <c>false</c> otherwise.
        /// When enabled, use <see cref="ExpirationDateFrom"/> and <see cref="ExpirationDateTo"/> to define the active window.
        /// </summary>
        public bool? Expires { get; set; }

        /// <summary>
        /// Expiration date for cash payment methods (e.g., boleto, ticket). After this date
        /// the payment slip can no longer be used.
        /// </summary>
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Date from which the preference becomes active. Requires <see cref="Expires"/> to be <c>true</c>.
        /// </summary>
        public DateTime? ExpirationDateFrom { get; set; }

        /// <summary>
        /// Date after which the preference expires and can no longer accept payments.
        /// Requires <see cref="Expires"/> to be <c>true</c>.
        /// </summary>
        public DateTime? ExpirationDateTo { get; set; }

        /// <summary>
        /// Origin of the payment. Used for marketplace integrations. Default value: <c>NONE</c>.
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Fee amount charged by the marketplace application owner on each payment.
        /// </summary>
        public decimal? MarketplaceFee { get; set; }

        /// <summary>
        /// Purpose of the preference. Set to <c>"wallet_purchase"</c> to restrict payment
        /// to MercadoPago wallet users only, or <c>"onboarding_credits"</c> to offer
        /// MercadoPago credits as a payment option.
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// Additional information about the preference, such as an internal order note or context string.
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Auto-return behavior after payment. When set to <c>"approved"</c>, the buyer is
        /// redirected back to your site immediately after completing a successful purchase.
        /// Requires <see cref="BackUrls"/> to be configured.
        /// </summary>
        public string AutoReturn { get; set; }

        /// <summary>
        /// Operation type that identifies the kind of transaction (e.g., <c>"regular_payment"</c>).
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// Differential pricing configuration for this preference.
        /// </summary>
        public DifferentialPricingRequest DifferentialPricing { get; set; }

        /// <summary>
        /// MercadoPago user ID of the sponsor in a marketplace integration.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// Processing modes to use for this preference (e.g., <c>"aggregator"</c> or <c>"gateway"</c>).
        /// </summary>
        public IList<string> ProcessingModes { get; set; }

        /// <summary>
        /// When set to <c>true</c>, the payment can only be approved or rejected.
        /// Otherwise an <c>in_process</c> status is also possible.
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// List of taxes applied to this preference, such as VAT or IVA.
        /// </summary>
        /// <seealso cref="PreferenceTaxRequest"/>
        public IList<PreferenceTaxRequest> Taxes { get; set; }

        /// <summary>
        /// Tracking configurations (e.g., Google Ads, Facebook Pixel) executed during the
        /// buyer's interaction in the Checkout Pro flow.
        /// </summary>
        /// <seealso cref="PreferenceTrackRequest"/>
        public IList<PreferenceTrackRequest> Tracks { get; set; }

        /// <summary>
        /// Breakdown of amounts for the collector (seller) and the payer (buyer) in the transaction.
        /// </summary>
        /// <seealso cref="PreferenceAmountsRequest"/>
        public PreferenceAmountsRequest Amounts { get; set; }

        /// <summary>
        /// Counter-currency configuration for cross-border payments where the buyer pays in
        /// a different currency than the seller receives.
        /// </summary>
        /// <seealso cref="PreferenceCounterCurrencyRequest"/>
        public PreferenceCounterCurrencyRequest CounterCurrency { get; set; }

        /// <summary>
        /// Data that can be attached to the preference to record additional
        /// attributes of the merchant.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }
    }
}
