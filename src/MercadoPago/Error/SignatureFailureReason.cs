namespace MercadoPago.Error
{
    /// <summary>
    /// Enumerates the reasons why
    /// <see cref="MercadoPago.Webhook.WebhookSignatureValidator"/> may reject a
    /// MercadoPago webhook notification.
    /// </summary>
    /// <remarks>
    /// Each value maps to a specific failure mode in the signature verification flow.
    /// Integrators are encouraged to log this value alongside the
    /// <c>x-request-id</c> for correlation against the MercadoPago notifications dashboard.
    /// </remarks>
    public enum SignatureFailureReason
    {
        /// <summary>
        /// The <c>x-signature</c> header was <c>null</c>, empty, or whitespace.
        /// </summary>
        MissingSignatureHeader,

        /// <summary>
        /// The <c>x-signature</c> header did not match the expected
        /// <c>ts=...,vN=...</c> format and could not be parsed.
        /// </summary>
        MalformedSignatureHeader,

        /// <summary>
        /// The <c>x-signature</c> header parsed correctly but no <c>ts=</c> component
        /// was present.
        /// </summary>
        MissingTimestamp,

        /// <summary>
        /// The <c>x-signature</c> header did not include a hash for any of the
        /// versions listed in <c>supportedVersions</c>. This typically indicates that
        /// MercadoPago has migrated to a new signature version (e.g. <c>v2</c>) and the
        /// SDK needs to be upgraded.
        /// </summary>
        MissingHash,

        /// <summary>
        /// The HMAC computed locally did not match the hash provided in the header.
        /// Most often caused by an incorrect secret signature or by a forged request.
        /// </summary>
        SignatureMismatch,

        /// <summary>
        /// The header timestamp was outside the configured <c>tolerance</c> window
        /// against the current clock. May indicate clock drift on the integrator's
        /// server or a replay attack.
        /// </summary>
        TimestampOutOfTolerance,
    }
}
