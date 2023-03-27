using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MercadoPago.Client;
using MercadoPago.Client.AuthorizedPayment;
using MercadoPago.Http;
using MercadoPago.Resource;
using MercadoPago.Resource.AuthorizedPayment;
using Moq;
using Xunit;

namespace MercadoPago.Tests.Client.AuthorizedPayment
{
    public class AuthorizedPaymentClientUnitTest
    {
        private readonly AuthorizedPaymentClient client;
        private readonly Mock<IHttpClient> mock;
        public AuthorizedPaymentClientUnitTest()
        {
            mock = new Mock<IHttpClient>();
            client = new AuthorizedPaymentClient(mock.Object);
        }

        [Fact]
        public async Task GetAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/AuthorizedPaymentGetResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(It.IsAny<MercadoPagoRequest>(), It.IsAny<IRetryStrategy>(), It.IsAny<CancellationToken>()).Result).Returns(response);

            var result = await client.GetAsync(123);
            validateAuthorizedPayment(result);

            mock.Reset();
        }

        [Fact]
        public void Get_Success()
        {
            var json = File.ReadAllText("Client/Mock/AuthorizedPaymentGetResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(It.IsAny<MercadoPagoRequest>(), It.IsAny<IRetryStrategy>(), It.IsAny<CancellationToken>()).Result).Returns(response);

            var result = client.Get(123);
            validateAuthorizedPayment(result);

            mock.Reset();
        }

        [Fact]
        public async Task SearchAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/AuthorizedPaymentSearchResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(It.IsAny<MercadoPagoRequest>(), It.IsAny<IRetryStrategy>(), It.IsAny<CancellationToken>()).Result).Returns(response);

            var request = new SearchRequest();
            var result = await client.SearchAsync(request);

            mock.Reset();
        }

        [Fact]
        public void Search_Success()
        {
            var json = File.ReadAllText("Client/Mock/AuthorizedPaymentSearchResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            mock.Setup(httpClient => httpClient.SendAsync(It.IsAny<MercadoPagoRequest>(), It.IsAny<IRetryStrategy>(), It.IsAny<CancellationToken>()).Result).Returns(response);

            var request = new SearchRequest();
            var result = client.Search(request);
            validateAuthorizedPaymentSearch(result);

            mock.Reset();
        }

        private void validateAuthorizedPayment(MercadoPago.Resource.AuthorizedPayment.AuthorizedPayment authorizedPayment)
        {
            Assert.Equal(6114264375, authorizedPayment.Id);
            Assert.Equal("scheduled", authorizedPayment.Type);
            Assert.Equal("2022-01-01T11:12:25.8920000-04:00", authorizedPayment.DateCreated?.ToString("O"));
            Assert.Equal("2022-01-01T11:12:25.8920000-04:00", authorizedPayment.LastModified?.ToString("O"));
            Assert.Equal("2c938084726fca480172750000000000", authorizedPayment.PreapprovalId);
            Assert.Equal("Yoga classes", authorizedPayment.Reason);
            Assert.Equal("23546246234", authorizedPayment.ExternalReference);
            Assert.Equal("ARS", authorizedPayment.CurrencyId);
            Assert.Equal(10, authorizedPayment.TransactionAmount);
            Assert.Equal("2022-01-01T11:12:25.8920000-04:00", authorizedPayment.DebitDate?.ToString("o"));
            Assert.Equal(4, authorizedPayment.RetryAttempt);
            Assert.Equal("scheduled", authorizedPayment.Status);
            Assert.Equal("pending", authorizedPayment.Summarized);
            Assert.Equal(19951521071, authorizedPayment.Payment.Id);
            Assert.Equal("approved", authorizedPayment.Payment.Status);
            Assert.Equal("accredited", authorizedPayment.Payment.StatusDetail);
        }

        private void validateAuthorizedPaymentSearch(ResultsResourcesPage<MercadoPago.Resource.AuthorizedPayment.AuthorizedPayment> search)
        {
            validateAuthorizedPayment(search.Results[0]);
            Assert.Equal(0, search.Paging.Offset);
            Assert.Equal(20, search.Paging.Limit);
            Assert.Equal(100, search.Paging.Total);
        }
    }
}

