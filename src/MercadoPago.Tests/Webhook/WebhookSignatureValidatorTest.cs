namespace MercadoPago.Tests.Webhook
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using MercadoPago.Error;
    using MercadoPago.Webhook;
    using Xunit;

    public class WebhookSignatureValidatorTest
    {
        private const string Secret = "your_secret_key_here";
        private const string RequestId = "2066ca19-c6f1-498a-be75-1923005edd06";
        private const string DataIdRaw = "ORD01JQ4S4KY8HWQ6NA5PXB65B3D3";
        private const string DataIdLower = "ord01jq4s4ky8hwq6na5pxb65b3d3";

        private static string CurrentTs() =>
            DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(System.Globalization.CultureInfo.InvariantCulture);

        private static string ComputeHash(string dataId, string requestId, string ts, string secret)
        {
            var parts = new System.Collections.Generic.List<string>(3);
            if (!string.IsNullOrWhiteSpace(dataId))
            {
                parts.Add($"id:{dataId.ToLowerInvariant()}");
            }

            if (!string.IsNullOrWhiteSpace(requestId))
            {
                parts.Add($"request-id:{requestId}");
            }

            parts.Add($"ts:{ts}");
            var manifest = string.Join(";", parts) + ";";

            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(manifest));
            var sb = new StringBuilder(hashBytes.Length * 2);
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("x2", System.Globalization.CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }

        private static string BuildHeader(string hash, string ts, string version = "v1") =>
            $"ts={ts},{version}={hash}";

        // --- Canonical case 1: happy path with lowercase dataId ---
        [Fact]
        public void Validate_HappyPathWithLowercaseDataId_DoesNotThrow()
        {
            var ts = CurrentTs();
            var hash = ComputeHash(DataIdLower, RequestId, ts, Secret);

            WebhookSignatureValidator.Validate(
                BuildHeader(hash, ts), RequestId, DataIdLower, Secret);
        }

        // --- Canonical case 2: dataId in uppercase — SDK must lowercase before HMAC ---
        [Fact]
        public void Validate_DataIdInUppercase_StillValidates()
        {
            var ts = CurrentTs();
            var hash = ComputeHash(DataIdLower, RequestId, ts, Secret);

            WebhookSignatureValidator.Validate(
                BuildHeader(hash, ts), RequestId, DataIdRaw, Secret);
        }

        // --- Canonical case 3: malformed header (no =) ---
        [Fact]
        public void Validate_MalformedHeader_ThrowsMalformedSignatureHeader()
        {
            var ex = Assert.Throws<InvalidWebhookSignatureException>(() =>
                WebhookSignatureValidator.Validate(
                    "this-is-garbage", RequestId, DataIdLower, Secret));
            Assert.Equal(SignatureFailureReason.MalformedSignatureHeader, ex.Reason);
            Assert.Equal(RequestId, ex.RequestId);
        }

        // --- Canonical case 4: missing header ---
        [Fact]
        public void Validate_MissingHeader_ThrowsMissingSignatureHeader()
        {
            var ex = Assert.Throws<InvalidWebhookSignatureException>(() =>
                WebhookSignatureValidator.Validate(
                    null, RequestId, DataIdLower, Secret));
            Assert.Equal(SignatureFailureReason.MissingSignatureHeader, ex.Reason);
        }

        // --- Canonical case 5: header has v1 but no ts ---
        [Fact]
        public void Validate_MissingTimestamp_ThrowsMissingTimestamp()
        {
            var ts = CurrentTs();
            var hash = ComputeHash(DataIdLower, RequestId, ts, Secret);

            var ex = Assert.Throws<InvalidWebhookSignatureException>(() =>
                WebhookSignatureValidator.Validate(
                    $"v1={hash}", RequestId, DataIdLower, Secret));
            Assert.Equal(SignatureFailureReason.MissingTimestamp, ex.Reason);
        }

        // --- Canonical case 6: header has ts but no v1 ---
        [Fact]
        public void Validate_MissingV1_ThrowsMissingHash()
        {
            var ts = CurrentTs();
            var ex = Assert.Throws<InvalidWebhookSignatureException>(() =>
                WebhookSignatureValidator.Validate(
                    $"ts={ts}", RequestId, DataIdLower, Secret));
            Assert.Equal(SignatureFailureReason.MissingHash, ex.Reason);
            Assert.Equal(ts, ex.Timestamp);
        }

        // --- Canonical case 7: tampered hash ---
        [Fact]
        public void Validate_TamperedHash_ThrowsSignatureMismatch()
        {
            var ts = CurrentTs();
            var hash = ComputeHash(DataIdLower, RequestId, ts, Secret);
            var tampered = hash[..^2] + (hash.EndsWith("00", StringComparison.Ordinal) ? "ff" : "00");

            var ex = Assert.Throws<InvalidWebhookSignatureException>(() =>
                WebhookSignatureValidator.Validate(
                    BuildHeader(tampered, ts), RequestId, DataIdLower, Secret));
            Assert.Equal(SignatureFailureReason.SignatureMismatch, ex.Reason);
        }

        // --- Canonical case 8: timestamp outside tolerance ---
        [Fact]
        public void Validate_TimestampOutsideTolerance_ThrowsTimestampOutOfTolerance()
        {
            var staleTs = (DateTimeOffset.UtcNow.AddMinutes(-30).ToUnixTimeMilliseconds())
                .ToString(System.Globalization.CultureInfo.InvariantCulture);
            var hash = ComputeHash(DataIdLower, RequestId, staleTs, Secret);

            var ex = Assert.Throws<InvalidWebhookSignatureException>(() =>
                WebhookSignatureValidator.Validate(
                    BuildHeader(hash, staleTs), RequestId, DataIdLower, Secret,
                    tolerance: TimeSpan.FromMinutes(5)));
            Assert.Equal(SignatureFailureReason.TimestampOutOfTolerance, ex.Reason);
        }

        [Fact]
        public void Validate_TimestampWithinTolerance_DoesNotThrow()
        {
            var ts = CurrentTs();
            var hash = ComputeHash(DataIdLower, RequestId, ts, Secret);

            WebhookSignatureValidator.Validate(
                BuildHeader(hash, ts), RequestId, DataIdLower, Secret,
                tolerance: TimeSpan.FromMinutes(5));
        }

        // --- Canonical case 9: data.id absent → manifest excludes id: ---
        [Fact]
        public void Validate_DataIdAbsent_ManifestExcludesIdPair()
        {
            var ts = CurrentTs();
            var hash = ComputeHash(null, RequestId, ts, Secret);

            WebhookSignatureValidator.Validate(
                BuildHeader(hash, ts), RequestId, null, Secret);
        }

        // --- Canonical case 10: x-request-id absent → manifest excludes request-id: ---
        [Fact]
        public void Validate_RequestIdAbsent_ManifestExcludesRequestIdPair()
        {
            var ts = CurrentTs();
            var hash = ComputeHash(DataIdLower, null, ts, Secret);

            WebhookSignatureValidator.Validate(
                BuildHeader(hash, ts), null, DataIdLower, Secret);
        }

        // --- Canonical case 11: both absent → manifest is ts: only ---
        [Fact]
        public void Validate_BothAbsent_ManifestIsTsOnly()
        {
            var ts = CurrentTs();
            var hash = ComputeHash(null, null, ts, Secret);

            WebhookSignatureValidator.Validate(
                BuildHeader(hash, ts), string.Empty, "  ", Secret);
        }

        // --- Canonical case 12: non-payment topic uses the same algorithm ---
        [Fact]
        public void Validate_NonPaymentTopic_UsesSameAlgorithm()
        {
            const string orderDataId = "ord01abc123";
            var ts = CurrentTs();
            var hash = ComputeHash(orderDataId, RequestId, ts, Secret);

            WebhookSignatureValidator.Validate(
                BuildHeader(hash, ts), RequestId, orderDataId, Secret);
        }

        // --- supportedVersions: forward compatibility ---
        [Fact]
        public void Validate_HeaderHasV1AndV2_OnlyV1Supported_UsesV1()
        {
            var ts = CurrentTs();
            var v1Hash = ComputeHash(DataIdLower, RequestId, ts, Secret);
            var header = $"ts={ts},v1={v1Hash},v2=aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            WebhookSignatureValidator.Validate(
                header, RequestId, DataIdLower, Secret);
        }

        [Fact]
        public void Validate_HeaderHasOnlyV2_OnlyV1Supported_ThrowsMissingHash()
        {
            var ts = CurrentTs();
            var header = $"ts={ts},v2=somehash";

            var ex = Assert.Throws<InvalidWebhookSignatureException>(() =>
                WebhookSignatureValidator.Validate(
                    header, RequestId, DataIdLower, Secret));
            Assert.Equal(SignatureFailureReason.MissingHash, ex.Reason);
        }

        // --- secret null guard ---
        [Fact]
        public void Validate_NullSecret_ThrowsArgumentNullException()
        {
            var ts = CurrentTs();
            Assert.Throws<ArgumentNullException>(() =>
                WebhookSignatureValidator.Validate(
                    $"ts={ts},v1=abc", RequestId, DataIdLower, null));
        }
    }
}
