namespace MercadoPago.Webhook
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using MercadoPago.Error;

    /// <summary>
    /// Verifies the authenticity of an incoming MercadoPago webhook notification by
    /// recomputing the HMAC-SHA256 signature locally and comparing it against the value
    /// in the <c>x-signature</c> header.
    /// </summary>
    /// <remarks>
    /// This is a stateless, CPU-only utility. It performs no outbound HTTP calls and
    /// does not depend on <c>MercadoPagoConfig</c>; the integrator passes the secret
    /// signature explicitly on every call. The comparison is performed in constant time
    /// (via <see cref="CryptographicOperations.FixedTimeEquals"/>) to mitigate timing attacks.
    /// <para>
    /// On failure, the validator throws <see cref="InvalidWebhookSignatureException"/>
    /// with a specific <see cref="SignatureFailureReason"/>. The integrator should
    /// respond with HTTP 401 to MercadoPago in all failure cases, log the
    /// <see cref="InvalidWebhookSignatureException.RequestId"/> for correlation,
    /// and not expose the failure reason in the HTTP response body.
    /// </para>
    /// <para>
    /// QR Code notifications are <b>not signed</b> by MercadoPago — do not call this
    /// validator for those events; they will always fail signature verification.
    /// </para>
    /// </remarks>
    public static class WebhookSignatureValidator
    {
        private static readonly IReadOnlyList<string> DefaultSupportedVersions = new[] { "v1" };
        private static readonly Regex VersionKeyRegex = new Regex(@"^v\d+$", RegexOptions.Compiled);

        /// <summary>
        /// Validates the signature of a MercadoPago webhook notification.
        /// </summary>
        /// <param name="xSignature">
        /// The raw value of the <c>x-signature</c> request header. Expected to follow
        /// the format <c>ts=&lt;ms&gt;,v1=&lt;hex&gt;</c>.
        /// </param>
        /// <param name="xRequestId">
        /// The value of the <c>x-request-id</c> request header. Optional in the manifest:
        /// if <c>null</c>, empty, or whitespace, the <c>request-id:</c> pair is omitted
        /// before computing the HMAC.
        /// </param>
        /// <param name="dataId">
        /// The value of the <c>data.id</c> query string parameter. Optional in the manifest:
        /// if <c>null</c>, empty, or whitespace, the <c>id:</c> pair is omitted. When present,
        /// the value is lowercased before being included in the manifest.
        /// </param>
        /// <param name="secret">
        /// The secret signature configured for the application in Tus Integraciones.
        /// Used as the HMAC key.
        /// </param>
        /// <param name="tolerance">
        /// Optional maximum allowed drift between the timestamp in the header and
        /// <see cref="DateTimeOffset.UtcNow"/>. When <c>null</c>, no timestamp check
        /// is performed. Setting this to a small window (e.g. five minutes) mitigates
        /// replay attacks.
        /// </param>
        /// <param name="supportedVersions">
        /// Optional ordered list of signature versions the SDK will accept. Defaults
        /// to <c>{"v1"}</c>. The validator iterates through this list and uses the
        /// first version found in the header, allowing forward compatibility with future
        /// signature schemes (e.g. <c>v2</c>) without breaking older integrations.
        /// </param>
        /// <exception cref="InvalidWebhookSignatureException">
        /// Thrown when the signature is missing, malformed, or does not match the
        /// expected HMAC. Inspect <see cref="InvalidWebhookSignatureException.Reason"/>
        /// for the specific failure mode.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="secret"/> is <c>null</c>.
        /// </exception>
        public static void Validate(
            string xSignature,
            string xRequestId,
            string dataId,
            string secret,
            TimeSpan? tolerance = null,
            IReadOnlyCollection<string> supportedVersions = null)
        {
            if (secret == null)
            {
                throw new ArgumentNullException(nameof(secret));
            }

            var normalizedSignature = Normalize(xSignature);
            var normalizedRequestId = Normalize(xRequestId);
            var normalizedDataId = Normalize(dataId);
            var versions = supportedVersions ?? DefaultSupportedVersions;

            if (normalizedSignature == null)
            {
                throw new InvalidWebhookSignatureException(
                    SignatureFailureReason.MissingSignatureHeader,
                    normalizedRequestId);
            }

            var parsed = ParseSignatureHeader(normalizedSignature);

            if (parsed.Timestamp == null && parsed.Hashes.Count == 0)
            {
                throw new InvalidWebhookSignatureException(
                    SignatureFailureReason.MalformedSignatureHeader,
                    normalizedRequestId);
            }

            if (parsed.Timestamp == null)
            {
                throw new InvalidWebhookSignatureException(
                    SignatureFailureReason.MissingTimestamp,
                    normalizedRequestId);
            }

            if (!long.TryParse(parsed.Timestamp, NumberStyles.None, CultureInfo.InvariantCulture, out var timestampMs))
            {
                throw new InvalidWebhookSignatureException(
                    SignatureFailureReason.MalformedSignatureHeader,
                    normalizedRequestId,
                    parsed.Timestamp);
            }

            string receivedHash = null;
            foreach (var version in versions)
            {
                if (parsed.Hashes.TryGetValue(version, out var hash))
                {
                    receivedHash = hash;
                    break;
                }
            }

            if (receivedHash == null)
            {
                throw new InvalidWebhookSignatureException(
                    SignatureFailureReason.MissingHash,
                    normalizedRequestId,
                    parsed.Timestamp);
            }

            var manifest = BuildManifest(normalizedDataId, normalizedRequestId, parsed.Timestamp);
            var computedHash = ComputeHmacHex(secret, manifest);

            if (!ConstantTimeEquals(computedHash, receivedHash))
            {
                throw new InvalidWebhookSignatureException(
                    SignatureFailureReason.SignatureMismatch,
                    normalizedRequestId,
                    parsed.Timestamp);
            }

            if (tolerance.HasValue)
            {
                var driftMs = Math.Abs(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - timestampMs);
                if (driftMs > (long)tolerance.Value.TotalMilliseconds)
                {
                    throw new InvalidWebhookSignatureException(
                        SignatureFailureReason.TimestampOutOfTolerance,
                        normalizedRequestId,
                        parsed.Timestamp);
                }
            }
        }

        private static string Normalize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return value.Trim();
        }

        private static ParsedSignature ParseSignatureHeader(string header)
        {
            var hashes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string ts = null;

            foreach (var part in header.Split(','))
            {
                var eqIndex = part.IndexOf('=');
                if (eqIndex <= 0 || eqIndex == part.Length - 1)
                {
                    continue;
                }

                var key = part.Substring(0, eqIndex).Trim().ToLowerInvariant();
                var value = part.Substring(eqIndex + 1).Trim();

                if (key.Length == 0 || value.Length == 0)
                {
                    continue;
                }

                if (key == "ts")
                {
                    ts = value;
                }
                else if (VersionKeyRegex.IsMatch(key))
                {
                    hashes[key] = value;
                }
            }

            return new ParsedSignature(ts, hashes);
        }

        private static string BuildManifest(string dataId, string requestId, string timestamp)
        {
            var parts = new List<string>(3);
            if (dataId != null)
            {
                parts.Add($"id:{dataId.ToLowerInvariant()}");
            }

            if (requestId != null)
            {
                parts.Add($"request-id:{requestId}");
            }

            parts.Add($"ts:{timestamp}");
            return string.Join(";", parts) + ";";
        }

        private static string ComputeHmacHex(string secret, string message)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                return ToHexLower(hash);
            }
        }

        private static string ToHexLower(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }

        private static bool ConstantTimeEquals(string a, string b)
        {
            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            var bytesA = Encoding.UTF8.GetBytes(a);
            var bytesB = Encoding.UTF8.GetBytes(b);
            return CryptographicOperations.FixedTimeEquals(bytesA, bytesB);
        }

        private readonly struct ParsedSignature
        {
            public ParsedSignature(string timestamp, IReadOnlyDictionary<string, string> hashes)
            {
                Timestamp = timestamp;
                Hashes = hashes;
            }

            public string Timestamp { get; }

            public IReadOnlyDictionary<string, string> Hashes { get; }
        }
    }
}
