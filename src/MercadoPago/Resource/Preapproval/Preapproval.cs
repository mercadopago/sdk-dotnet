namespace MercadoPago.Resource.PreApproval
{
    using System;
    using MercadoPago.Http;

    /// <summary>
    /// Preapproval resource.
    /// </summary>
    /// <remarks>
    /// For more information check the documentation
    /// <a href="https://www.mercadopago.com.br/developers/en/reference/subscriptions/resource/">here</a>
    /// </remarks>
    public class Preapproval : IResource
    {
        /// <summary>
        /// Preapproval ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Payer ID.
        /// </summary>
        public long? PayerId { get; set; }

        /// <summary>
        /// Payer email.
        /// </summary>
        public string PayerEmail { get; set; }

        /// <summary>
        /// Return URL.
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// Seller ID.
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Application ID.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Preapproval status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Preapproval title.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Preapproval reference value.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Preapproval checkout link.
        /// </summary>
        public string InitPoint { get; set; }

        /// <summary>
        /// Preapproval sandbox checkout link.
        /// </summary>
        public string SandboxInitPoint { get; set; }

        /// <summary>
        /// Payment method ID.
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Recurring data.
        /// </summary>
        public PreapprovalAutoRecurring AutoRecurring { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
