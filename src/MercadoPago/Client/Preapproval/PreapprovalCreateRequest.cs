namespace MercadoPago.Client.Preapproval
{
    /// <summary>
    /// Request DTO for creating a new preapproval (subscription) in the MercadoPago
    /// Subscriptions API. Used with <see cref="PreapprovalClient.CreateAsync"/>
    /// and <see cref="PreapprovalClient.Create"/>.
    /// </summary>
    public class PreapprovalCreateRequest
    {
        /// <summary>
        /// Email address of the payer (subscriber). MercadoPago will send subscription
        /// notifications and payment receipts to this address.
        /// </summary>
        public string PayerEmail { get; set; }

        /// <summary>
        /// URL the subscriber is redirected to after approving or declining the subscription.
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// MercadoPago user ID of the seller (collector) who will receive the subscription payments.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Human-readable title or description displayed to the subscriber on the checkout
        /// and in billing notifications (e.g., <c>"Monthly Premium Plan"</c>).
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Integrator-defined reference that links this subscription to an entity in the
        /// integrator's system (e.g., an internal subscription or plan ID).
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Initial status of the subscription (e.g., <c>"pending"</c>, <c>"authorized"</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Automatic recurring billing configuration that defines the charge amount,
        /// currency, frequency, and date range. See <see cref="PreApprovalAutoRecurringCreateRequest"/>.
        /// </summary>
        public PreApprovalAutoRecurringCreateRequest AutoRecurring { get; set; }
    }
}
