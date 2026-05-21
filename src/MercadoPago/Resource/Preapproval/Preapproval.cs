namespace MercadoPago.Resource.PreApproval
{
    using System;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a subscription (preapproval) returned by the MercadoPago
    /// Subscriptions API. A preapproval authorizes recurring charges against
    /// the payer's payment method according to the
    /// <see cref="AutoRecurring"/> schedule. Use
    /// <see cref="Client.Preapproval.PreapprovalClient"/> to create, update,
    /// retrieve, and search preapprovals.
    /// </summary>
    /// <remarks>
    /// For more information check the documentation
    /// <a href="https://www.mercadopago.com.br/developers/en/reference/online-payments/subscriptions/create-preapproval/post">here</a>
    /// </remarks>
    public class Preapproval : IResource
    {
        /// <summary>
        /// Unique identifier of this subscription (preapproval).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// MercadoPago user identifier of the payer (subscriber).
        /// </summary>
        public long? PayerId { get; set; }

        /// <summary>
        /// Email address of the payer (subscriber).
        /// </summary>
        public string PayerEmail { get; set; }

        /// <summary>
        /// URL to which the payer is redirected after completing or cancelling
        /// the subscription checkout.
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// MercadoPago user identifier of the seller (collector) who receives
        /// the recurring payments.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Identifier of the MercadoPago application that created this
        /// subscription.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Current lifecycle status of the subscription (e.g.
        /// <c>pending</c>, <c>authorized</c>, <c>paused</c>,
        /// <c>cancelled</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Short title or description of the subscription, visible to the
        /// payer during checkout and in notifications.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Free-text external reference used to correlate this subscription
        /// with entities in your own system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Date and time when this subscription was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last modification to this subscription.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// URL of the MercadoPago-hosted checkout page where the payer
        /// authorizes the subscription (production environment).
        /// </summary>
        public string InitPoint { get; set; }

        /// <summary>
        /// URL of the MercadoPago-hosted checkout page for the sandbox
        /// (testing) environment.
        /// </summary>
        public string SandboxInitPoint { get; set; }

        /// <summary>
        /// Identifier of the payment method used for the recurring charges
        /// (e.g. <c>visa</c>, <c>master</c>).
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Recurring billing configuration including frequency, currency, and
        /// amount for the subscription charges.
        /// </summary>
        public PreapprovalAutoRecurring AutoRecurring { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
