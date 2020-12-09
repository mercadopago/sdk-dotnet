namespace MercadoPago.Tests.Http
{
    using System;
    using System.Net;
    using System.Net.Http;
    using MercadoPago.Http;
    using Xunit;
    using HttpMethod = System.Net.Http.HttpMethod;

    public class DefaultRetryStrategyTest
    {
        [Fact]
        public void ShouldRetry_NotPostAndRetryableStatusCode_Retry()
        {
            var maxNumberRetries = 2;
            var retryStrategy = new DefaultRetryStrategy(maxNumberRetries);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/x");
            var httpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var hadRetryableError = false;
            var numberRetries = 0;

            RetryResponse retryResponse = retryStrategy.ShouldRetry(
                httpRequest, httpResponse, hadRetryableError, numberRetries);

            Assert.True(retryResponse.Retry);
            Assert.Equal(DefaultRetryStrategy.MinDelay.Ticks, retryResponse.Delay.Ticks);
        }

        [Fact]
        public void ShouldRetry_PostWithIdempotencyKeyAndRetryableStatusCode_Retry()
        {
            var maxNumberRetries = 2;
            var retryStrategy = new DefaultRetryStrategy(maxNumberRetries);
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/x");
            httpRequest.Headers.Add(Headers.IDEMPOTENCY_KEY, Guid.NewGuid().ToString());
            var httpResponse = new HttpResponseMessage(HttpStatusCode.Conflict);
            var hadRetryableError = false;
            var numberRetries = 1;

            RetryResponse retryResponse = retryStrategy.ShouldRetry(
                httpRequest, httpResponse, hadRetryableError, numberRetries);

            Assert.True(retryResponse.Retry);
            Assert.Equal(
                2 * DefaultRetryStrategy.MinDelay.Ticks,
                retryResponse.Delay.Ticks);
        }

        [Fact]
        public void ShouldRetry_RetryableRequestAndRetryableError_Retry()
        {
            var maxNumberRetries = 2;
            var retryStrategy = new DefaultRetryStrategy(maxNumberRetries);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/x");
            HttpResponseMessage httpResponse = null;
            var hadRetryableError = true;
            var numberRetry = 0;

            RetryResponse retryResponse = retryStrategy.ShouldRetry(
                httpRequest, httpResponse, hadRetryableError, numberRetry);

            Assert.True(retryResponse.Retry);
            Assert.Equal(DefaultRetryStrategy.MinDelay.Ticks, retryResponse.Delay.Ticks);
        }

        [Fact]
        public void ShouldRetry_MaxDelay_Retry()
        {
            var maxNumberRetries = 5;
            var retryStrategy = new DefaultRetryStrategy(maxNumberRetries);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/x");
            var httpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var hadRetryableError = false;
            var numberRetries = 4;

            RetryResponse retryResponse = retryStrategy.ShouldRetry(
                httpRequest, httpResponse, hadRetryableError, numberRetries);

            Assert.True(retryResponse.Retry);
            Assert.Equal(DefaultRetryStrategy.MaxDelay.Ticks, retryResponse.Delay.Ticks);
        }

        [Fact]
        public void ShouldRetry_RequestNull_NotRetry()
        {
            var maxNumberRetries = 2;
            var retryStrategy = new DefaultRetryStrategy(maxNumberRetries);
            HttpRequestMessage httpRequest = null;
            var httpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var hadRetryableError = false;
            var numberRetries = 0;

            RetryResponse retryResponse = retryStrategy.ShouldRetry(
                httpRequest, httpResponse, hadRetryableError, numberRetries);

            Assert.False(retryResponse.Retry);
            Assert.Equal(TimeSpan.Zero.Ticks, retryResponse.Delay.Ticks);
        }

        [Fact]
        public void ShouldRetry_PostWithoutIdempotencyKey_NotRetry()
        {
            var maxNumberRetries = 2;
            var retryStrategy = new DefaultRetryStrategy(maxNumberRetries);
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/x");
            var httpResponse = new HttpResponseMessage(HttpStatusCode.Conflict);
            var hadRetryableError = false;
            var numberRetries = 1;

            RetryResponse retryResponse = retryStrategy.ShouldRetry(
                httpRequest, httpResponse, hadRetryableError, numberRetries);

            Assert.False(retryResponse.Retry);
            Assert.Equal(TimeSpan.Zero.Ticks, retryResponse.Delay.Ticks);
        }

        [Fact]
        public void ShouldRetry_PostWithIdempotencyKeyEmpty_NotRetry()
        {
            var maxNumberRetries = 2;
            var retryStrategy = new DefaultRetryStrategy(maxNumberRetries);
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/x");
            httpRequest.Headers.Add(Headers.IDEMPOTENCY_KEY, string.Empty);
            var httpResponse = new HttpResponseMessage(HttpStatusCode.Conflict);
            var hadRetryableError = false;
            var numberRetries = 1;

            RetryResponse retryResponse = retryStrategy.ShouldRetry(
                httpRequest, httpResponse, hadRetryableError, numberRetries);

            Assert.False(retryResponse.Retry);
            Assert.Equal(TimeSpan.Zero.Ticks, retryResponse.Delay.Ticks);
        }

        [Fact]
        public void ShouldRetry_NumberRetries_NotRetry()
        {
            var maxNumberRetries = 2;
            var retryStrategy = new DefaultRetryStrategy(maxNumberRetries);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/x");
            var httpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var hadRetryableError = false;
            var numberRetries = 2;

            RetryResponse retryResponse = retryStrategy.ShouldRetry(
                httpRequest, httpResponse, hadRetryableError, numberRetries);

            Assert.False(retryResponse.Retry);
            Assert.Equal(TimeSpan.Zero.Ticks, retryResponse.Delay.Ticks);
        }

        [Fact]
        public void ShouldRetry_NoRetryableErrorAndNullResponse_NotRetry()
        {
            var maxNumberRetries = 2;
            var retryStrategy = new DefaultRetryStrategy(maxNumberRetries);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/x");
            HttpResponseMessage httpResponse = null;
            var hadRetryableError = false;
            var numberRetries = 0;

            RetryResponse retryResponse = retryStrategy.ShouldRetry(
                httpRequest, httpResponse, hadRetryableError, numberRetries);

            Assert.False(retryResponse.Retry);
            Assert.Equal(TimeSpan.Zero.Ticks, retryResponse.Delay.Ticks);
        }

        [Fact]
        public void ShouldRetry_NoRetryableErrorAndNotRetryableResponse_NotRetry()
        {
            var maxNumberRetries = 2;
            var retryStrategy = new DefaultRetryStrategy(maxNumberRetries);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/x");
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            var hadRetryableError = false;
            var numberRetries = 0;

            RetryResponse retryResponse = retryStrategy.ShouldRetry(
                httpRequest, httpResponse, hadRetryableError, numberRetries);

            Assert.False(retryResponse.Retry);
            Assert.Equal(TimeSpan.Zero.Ticks, retryResponse.Delay.Ticks);
        }
    }
}
