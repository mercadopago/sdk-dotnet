namespace MercadoPago.Tests.Http
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MercadoPago.Http;
    using Moq;
    using Xunit;
    using HttpMethod = MercadoPago.Http.HttpMethod;

    public class DefaultHttpClientTest
    {
        [Fact]
        public async Task ExecuteRequestAsync_AllParameters_Success()
        {
            // Request
            var url = "http://localhost:8080/x";
            var method = HttpMethod.GET;
            var requestContent = "Test";
            var requestHeaders = new Dictionary<string, string>
            {
                ["X-Custom-Header"] = "123",
            };
            var request = new MercadoPagoRequest(url, method, requestHeaders, requestContent);

            // Response
            var responseStatusCode = HttpStatusCode.OK;
            var responseContent = "OK";
            var httpResponse = new HttpResponseMessage(responseStatusCode)
            {
                Content = new StringContent(responseContent),
            };
            httpResponse.Headers.Add("X-Custom-Response-Header", "456");

            // Mock
            var httpClientMock = new HttpClientMock();
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Get, httpResponse);

            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var retryStrategy = new DefaultRetryStrategy(0);
            MercadoPagoResponse response =
                await httpClient.SendAsync(request, retryStrategy, default);

            Assert.Equal((int)responseStatusCode, response.StatusCode);
            Assert.Equal(responseContent, response.Content);
        }

        [Fact]
        public async Task ExecuteRequestAsync_WithHttpResponseRetry_Success()
        {
            // Request
            var url = "http://localhost:8080/x";
            var method = HttpMethod.GET;
            var requestContent = "Test";
            var requestHeaders = new Dictionary<string, string>
            {
                ["X-Custom-Header"] = "123",
            };
            var request = new MercadoPagoRequest(url, method, requestHeaders, requestContent);

            // Response
            var responseStatusCode = HttpStatusCode.OK;
            var responseContent = "OK";
            var finalHttpResponse = new HttpResponseMessage(responseStatusCode)
            {
                Content = new StringContent(responseContent),
            };

            // Mock
            var httpClientMock = new HttpClientMock();
            httpClientMock.MockRequest(
                url,
                System.Net.Http.HttpMethod.Get,
                new HttpResponseMessage(HttpStatusCode.InternalServerError),
                finalHttpResponse);

            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var retryStrategy = new DefaultRetryStrategy(1);
            MercadoPagoResponse response =
                await httpClient.SendAsync(request, retryStrategy, default);

            Assert.Equal((int)responseStatusCode, response.StatusCode);
            Assert.Equal(responseContent, response.Content);
        }

        [Fact]
        public async Task ExecuteRequestAsync_WithHttpRequestExceptionRetry_Success()
        {
            // Request
            var url = "http://localhost:8080/x";
            var method = HttpMethod.GET;
            var requestContent = "Test";
            var requestHeaders = new Dictionary<string, string>
            {
                ["X-Custom-Header"] = "123",
            };
            var request = new MercadoPagoRequest(url, method, requestHeaders, requestContent);

            // Response
            var responseStatusCode = HttpStatusCode.OK;
            var responseContent = "OK";
            var httpResponse = new HttpResponseMessage(responseStatusCode)
            {
                Content = new StringContent(responseContent),
            };

            // Mock
            var httpClientMock = new HttpClientMock();
            httpClientMock.MockRequest(
                url,
                System.Net.Http.HttpMethod.Get,
                (setupReturns) =>
                    setupReturns
                        .ThrowsAsync(new HttpRequestException())
                        .ReturnsAsync(httpResponse));

            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var retryStrategy = new DefaultRetryStrategy(1);
            MercadoPagoResponse response =
                await httpClient.SendAsync(request, retryStrategy, default);

            Assert.Equal((int)responseStatusCode, response.StatusCode);
            Assert.Equal(responseContent, response.Content);
        }

        [Fact]
        public async Task ExecuteRequestAsync_WithOperationCanceledExceptionRetry_Success()
        {
            // Request
            var url = "http://localhost:8080/x";
            var method = HttpMethod.GET;
            var requestContent = "Test";
            var requestHeaders = new Dictionary<string, string>
            {
                ["X-Custom-Header"] = "123",
            };
            var request = new MercadoPagoRequest(url, method, requestHeaders, requestContent);

            // Response
            var responseStatusCode = HttpStatusCode.OK;
            var responseContent = "OK";
            var finalHttpResponse = new HttpResponseMessage(responseStatusCode)
            {
                Content = new StringContent(responseContent),
            };

            // Mock
            var httpClientMock = new HttpClientMock();
            httpClientMock.MockRequest(
                url,
                System.Net.Http.HttpMethod.Get,
                (setupReturns) =>
                    setupReturns
                        .ThrowsAsync(new OperationCanceledException())
                        .ReturnsAsync(finalHttpResponse));

            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var retryStrategy = new DefaultRetryStrategy(1);
            MercadoPagoResponse response =
                await httpClient.SendAsync(request, retryStrategy, default);

            Assert.Equal((int)responseStatusCode, response.StatusCode);
            Assert.Equal(responseContent, response.Content);
        }

        [Fact]
        public async Task ExecuteRequestAsync_ThrowsException_Fail()
        {
            // Request
            var url = "http://localhost:8080/x";
            var method = HttpMethod.GET;
            var requestContent = "Test";
            var requestHeaders = new Dictionary<string, string>
            {
                ["X-Custom-Header"] = "123",
            };
            var request = new MercadoPagoRequest(url, method, requestHeaders, requestContent);

            // Mock
            var httpClientMock = new HttpClientMock();
            httpClientMock.MockRequestError(
                url,
                System.Net.Http.HttpMethod.Get,
                new Exception());

            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var retryStrategy = new DefaultRetryStrategy(1);
            await Assert.ThrowsAsync<Exception>(() =>
                httpClient.SendAsync(request, retryStrategy, default));
        }
    }
}
