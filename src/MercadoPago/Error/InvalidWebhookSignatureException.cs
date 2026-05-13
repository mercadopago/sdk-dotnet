namespace MercadoPago.Error
{
    using System;

    /// <summary>
    /// Exception thrown by <see cref="MercadoPago.Webhook.WebhookSignatureValidator"/>
    /// when a webhook notification cannot be confirmed as originating from MercadoPago.
    /// </summary>
    /// <remarks>
    /// The exception carries enough context to support structured logging without
    /// exposing internal details in the HTTP response. The <see cref="Reason"/>
    /// indicates why validation failed, while <see cref="RequestId"/> and
    /// <see cref="Timestamp"/> echo the inputs that were available at the point
    /// of failure (when applicable) to correlate against MercadoPago's
    /// notifications dashboard.
    /// </remarks>
    public class InvalidWebhookSignatureException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidWebhookSignatureException"/> class.
        /// </summary>
        /// <param name="reason">The specific failure mode that triggered the exception.</param>
        /// <param name="requestId">
        /// The <c>x-request-id</c> header value associated with the request, when available.
        /// May be <c>null</c> if the header was not provided.
        /// </param>
        /// <param name="timestamp">
        /// The <c>ts</c> value extracted from the <c>x-signature</c> header, when parsing
        /// reached that point. May be <c>null</c> if parsing failed earlier.
        /// </param>
        public InvalidWebhookSignatureException(
            SignatureFailureReason reason,
            string requestId = null,
            string timestamp = null)
            : base($"Invalid webhook signature: {reason}")
        {
            Reason = reason;
            RequestId = requestId;
            Timestamp = timestamp;
        }

        /// <summary>
        /// Gets the specific failure mode that triggered the exception.
        /// </summary>
        public SignatureFailureReason Reason { get; }

        /// <summary>
        /// Gets the <c>x-request-id</c> header value associated with the request, when available.
        /// </summary>
        public string RequestId { get; }

        /// <summary>
        /// Gets the <c>ts</c> value extracted from the <c>x-signature</c> header, when parsing
        /// reached that point.
        /// </summary>
        public string Timestamp { get; }
    }
}
