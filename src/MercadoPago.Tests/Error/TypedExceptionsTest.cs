namespace MercadoPago.Tests.Error
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Collections.Generic;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using Xunit;

    public class TypedExceptionsTest
    {
        // ── Hierarchy ──────────────────────────────────────────────────────────

        [Fact]
        public void AllSubtypesInheritFromMercadoPagoApiException()
        {
            var response = new MercadoPagoResponse(400, new Dictionary<string, string>(), "{}");
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPBadRequestException("", response));
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPAuthenticationException("", response));
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPPaymentException("", response));
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPForbiddenException("", response));
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPNotFoundException("", response));
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPIdempotencyException("", response));
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPValidationException("", response));
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPResourceLockedException("", response));
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPDependencyException("", response));
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPRateLimitException("", response));
            Assert.IsAssignableFrom<MercadoPagoApiException>(new MPServerException("", response));
        }

        [Fact]
        public void MPRateLimitExceptionStoresRetryAfter()
        {
            var response = new MercadoPagoResponse(429, new Dictionary<string, string>(), "{}");
            var ex = new MPRateLimitException("", response, retryAfter: 45);
            Assert.Equal(45, ex.RetryAfter);
        }

        [Fact]
        public void MPRateLimitExceptionNullRetryAfterByDefault()
        {
            var response = new MercadoPagoResponse(429, new Dictionary<string, string>(), "{}");
            var ex = new MPRateLimitException("", response);
            Assert.Null(ex.RetryAfter);
        }

        // ── Factory ────────────────────────────────────────────────────────────

        private static MercadoPagoResponse MakeResponse(int status, Dictionary<string, string> headers = null)
            => new MercadoPagoResponse(status, headers ?? new Dictionary<string, string>(), "{}");

        [Theory]
        [InlineData(400, typeof(MPBadRequestException))]
        [InlineData(401, typeof(MPAuthenticationException))]
        [InlineData(402, typeof(MPPaymentException))]
        [InlineData(403, typeof(MPForbiddenException))]
        [InlineData(404, typeof(MPNotFoundException))]
        [InlineData(409, typeof(MPIdempotencyException))]
        [InlineData(422, typeof(MPValidationException))]
        [InlineData(423, typeof(MPResourceLockedException))]
        [InlineData(424, typeof(MPDependencyException))]
        [InlineData(429, typeof(MPRateLimitException))]
        [InlineData(500, typeof(MPServerException))]
        [InlineData(503, typeof(MPServerException))]
        public void Factory_MapsStatus_ToCorrectSubtype(int status, Type expectedType)
        {
            var ex = MercadoPagoExceptionFactory.Build(MakeResponse(status));
            Assert.IsType(expectedType, ex);
        }

        [Fact]
        public void Factory_UnknownClientError_ReturnsMercadoPagoApiException()
        {
            var ex = MercadoPagoExceptionFactory.Build(MakeResponse(418));
            Assert.IsType<MercadoPagoApiException>(ex);
        }

        [Fact]
        public void Factory_429WithRetryAfterHeader_PopulatesRetryAfter()
        {
            var headers = new Dictionary<string, string> { ["Retry-After"] = "60" };
            var response = MakeResponse(429, headers);
            var ex = MercadoPagoExceptionFactory.Build(response) as MPRateLimitException;
            Assert.NotNull(ex);
            Assert.Equal(60, ex.RetryAfter);
        }

        // ── DefaultRetryStrategy now retries 429 ─────────────────────────────

        [Fact]
        public void DefaultRetryStrategy_Retries429()
        {
            var strategy = new DefaultRetryStrategy(3);
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/");
            var response = new HttpResponseMessage((HttpStatusCode)429);
            var result = strategy.ShouldRetry(request, response, hadRetryableError: false, numberRetries: 0);
            Assert.True(result.Retry);
        }

        [Fact]
        public void DefaultRetryStrategy_DoesNotRetry_4xxNon429()
        {
            var strategy = new DefaultRetryStrategy(3);
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/");
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest); // 400
            var result = strategy.ShouldRetry(request, response, hadRetryableError: false, numberRetries: 0);
            Assert.False(result.Retry);
        }
    }
}
