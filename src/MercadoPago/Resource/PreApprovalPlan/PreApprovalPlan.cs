namespace MercadoPago.Resource.PreApprovalPlan
{
    using System;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a subscription plan template returned by the MercadoPago
    /// Subscriptions API. A plan defines the billing frequency, currency, and
    /// amount shared by all subscriptions attached to it. Use
    /// <see cref="Client.PreApprovalPlan.PreApprovalPlanClient"/> to create,
    /// update, retrieve, and search plans.
    /// </summary>
    /// <remarks>
    /// For more information check the documentation
    /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/subscriptions/create-preapproval-plan/post">here</a>.
    /// </remarks>
    public class PreApprovalPlan : IResource
    {
        /// <summary>
        /// Unique identifier of this subscription plan.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Short descriptive title of the plan, visible to subscribers during checkout.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Free-text external reference for correlating the plan with your own system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Current status of the plan (<c>active</c> or <c>cancelled</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// URL to which the payer is redirected after completing the subscription checkout.
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// MercadoPago user identifier of the seller (collector) who receives the charges.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Identifier of the MercadoPago application that created this plan.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Date and time when this plan was created (UTC).
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last modification to this plan (UTC).
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// URL of the MercadoPago-hosted checkout page for subscribing to this plan
        /// (production environment).
        /// </summary>
        public string InitPoint { get; set; }

        /// <summary>
        /// URL of the MercadoPago-hosted checkout page for the sandbox (testing) environment.
        /// </summary>
        public string SandboxInitPoint { get; set; }

        /// <summary>
        /// Recurring billing configuration for this plan, including frequency,
        /// currency, and amount.
        /// </summary>
        public PreApprovalPlanAutoRecurring AutoRecurring { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
