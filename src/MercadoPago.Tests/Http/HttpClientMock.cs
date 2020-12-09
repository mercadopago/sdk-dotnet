namespace MercadoPago.Tests.Http
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Moq.Language;
    using Moq.Protected;
    using Newtonsoft.Json.Linq;

    public class HttpClientMock
    {
        private readonly Mock<HttpMessageHandler> handlerMock;

        public HttpClientMock()
        {
            handlerMock = new Mock<HttpMessageHandler>();
            HttpClient = new HttpClient(handlerMock.Object);
        }

        public HttpClient HttpClient { get; }

        public void Reset()
        {
            handlerMock.Reset();
        }

        public void VerifySended(HttpMethod httpMethod, Uri url, Times times)
        {
            handlerMock.Protected()
                .Verify(
                    "SendAsync",
                    times,
                    ItExpr.Is<HttpRequestMessage>(httpRequest =>
                        httpRequest.Method == httpMethod
                        && httpRequest.RequestUri.Equals(url)),
                    ItExpr.IsAny<CancellationToken>());
        }

        public void VerifySended(HttpMethod httpMethod, Uri url, string body, Times times)
        {
            handlerMock.Protected()
                .Verify(
                    "SendAsync",
                    times,
                    ItExpr.Is<HttpRequestMessage>(httpRequest =>
                        httpRequest.Method == httpMethod
                        && httpRequest.RequestUri.Equals(url)),
                    ItExpr.IsAny<CancellationToken>());
        }

        public void MockRequest(
            string url,
            HttpMethod method,
            HttpResponseMessage httpResponse)
        {
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(httpRequest =>
                        httpRequest.Method == method
                        && httpRequest.RequestUri.ToString().Equals(url)),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);
        }

        public void MockRequest(
            string url,
            HttpMethod method,
            params HttpResponseMessage[] httpResponses)
        {
            if (httpResponses.Length == 0)
            {
                throw new ArgumentException("At least one HTTP response must be provided.");
            }

            ISetupSequentialResult<Task<HttpResponseMessage>> setupSequence =
                handlerMock.Protected()
                .SetupSequence<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(httpRequest =>
                        httpRequest.Method == method
                        && httpRequest.RequestUri.ToString().Equals(url)),
                    ItExpr.IsAny<CancellationToken>());

            foreach (var httpResponse in httpResponses)
            {
                setupSequence.ReturnsAsync(httpResponse);
            }
        }

        public void MockRequest(
            string url,
            HttpMethod method,
            Action<ISetupSequentialResult<Task<HttpResponseMessage>>> setupReturns)
        {
            ISetupSequentialResult<Task<HttpResponseMessage>> setupSequence =
                handlerMock.Protected()
                .SetupSequence<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(httpRequest =>
                        httpRequest.Method == method
                        && httpRequest.RequestUri.ToString().Equals(url)),
                    ItExpr.IsAny<CancellationToken>());

            setupReturns(setupSequence);
        }

        public void MockRequestError(
            string url,
            HttpMethod method,
            Exception exception)
        {
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(httpRequest =>
                        httpRequest.Method == method
                        && httpRequest.RequestUri.ToString().Equals(url)),
                    ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(exception);
        }
    }
}
