namespace MercadoPago.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MercadoPago.Client;
    using MercadoPago.Config;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Http;
    using MercadoPago.Tests.Resource;
    using Xunit;

    public class MercadoPagoClientTest
    {
        [Fact]
        public void Constructor_Full_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new DummyClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new DummyClient(null, null);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public async Task SendAsync_WithBody_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";
            var request = new DummyRequest("hello");

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'name':'world'}"),
            };
            httpResponse.Headers.Add("X-Custom-Response-Header", "456");

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Post, httpResponse);

            DummyResource dummyResource =
                await client.SendAsync(path, MercadoPago.Http.HttpMethod.POST, request);

            Assert.NotNull(dummyResource);
            Assert.Equal("world", dummyResource.Name);
        }

        [Fact]
        public void Send_WithBody_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";
            var request = new DummyRequest("hello");

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'name':'world'}"),
            };
            httpResponse.Headers.Add("X-Custom-Response-Header", "456");

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Post, httpResponse);

            DummyResource dummyResource =
                client.Send(path, MercadoPago.Http.HttpMethod.POST, request);

            Assert.NotNull(dummyResource);
            Assert.Equal("world", dummyResource.Name);
        }

        [Fact]
        public async Task SendAsync_WithBodyIdempotent_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";
            var request = new DummyIdempotentRequest("hello");

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'name':'world'}"),
            };
            httpResponse.Headers.Add("X-Custom-Response-Header", "456");

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Post, httpResponse);

            DummyResource dummyResource =
                await client.SendAsync(path, MercadoPago.Http.HttpMethod.POST, request);

            Assert.NotNull(dummyResource);
            Assert.Equal("world", dummyResource.Name);
        }

        [Fact]
        public async Task SendAsync_WithoutBody_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'name':'world'}"),
            };
            httpResponse.Headers.Add("X-Custom-Response-Header", "456");

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Get, httpResponse);

            DummyResource dummyResource =
                await client.SendAsync(path, MercadoPago.Http.HttpMethod.GET, null);

            Assert.NotNull(dummyResource);
            Assert.Equal("world", dummyResource.Name);
        }

        [Fact]
        public void Send_WithoutBody_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'name':'world'}"),
            };
            httpResponse.Headers.Add("X-Custom-Response-Header", "456");

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Get, httpResponse);

            DummyResource dummyResource =
                client.Send(path, MercadoPago.Http.HttpMethod.GET, null);

            Assert.NotNull(dummyResource);
            Assert.Equal("world", dummyResource.Name);
        }

        [Fact]
        public async Task SendAsync_WithQueryString_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var url = $"{MercadoPagoConfig.BaseUrl}{path}?name=hello";
            var request = new DummyRequest("hello");

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'name':'world'}"),
            };
            httpResponse.Headers.Add("X-Custom-Response-Header", "456");

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Get, httpResponse);

            DummyResource dummyResource =
                await client.SendAsync(path, MercadoPago.Http.HttpMethod.GET, request);

            Assert.NotNull(dummyResource);
            Assert.Equal("world", dummyResource.Name);
        }

        [Fact]
        public async Task SendAsync_WithRequestOptions_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";
            var request = new DummyRequest("hello");

            var requestOptions = new RequestOptions
            {
                AccessToken = Guid.NewGuid().ToString(),
                RetryStrategy = new DefaultRetryStrategy(0),
            };
            requestOptions.CustomHeaders.Add("X-Custom-Header", "custom");
            requestOptions.CustomHeaders.Add(Headers.CONTENT_TYPE, "plain/text"); // should not add
            requestOptions.CustomHeaders.Add(Headers.AUTHORIZATION, "Basic user:123"); // should not add

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'name':'world'}"),
            };
            httpResponse.Headers.Add("X-Custom-Response-Header", "456");

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Put, httpResponse);

            DummyResource dummyResource =
                await client.SendAsync(path, MercadoPago.Http.HttpMethod.PUT, request, requestOptions);

            Assert.NotNull(dummyResource);
            Assert.Equal("world", dummyResource.Name);
        }

        [Fact]
        public async Task SendAsync_InvalidJsonResponse_Error()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";
            var request = new DummyRequest("hello");

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("invalid json"),
            };

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Post, httpResponse);

            try
            {
                await client.SendAsync(path, MercadoPago.Http.HttpMethod.POST, request);
            }
            catch (MercadoPagoApiException ex)
            {
                Assert.Contains("Invalid response from API.", ex.Message);
            }
        }

        [Fact]
        public async Task SendAsync_ErrorHttpStatusCode_Error()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";
            var request = new DummyRequest();

            var errorJson = @"{
                ""message"": ""name attribute can't be null"",
                ""error"": ""bad_request"",
                ""status"": 400,
                ""cause"": [
                    {
                        ""code"": 123,
                        ""description"": ""name attribute can't be null""
                    }
                ]
            }";
            var httpResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(errorJson),
            };

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Post, httpResponse);

            try
            {
                await client.SendAsync(path, MercadoPago.Http.HttpMethod.POST, request);
            }
            catch (MercadoPagoApiException ex)
            {
                Assert.Equal(400, ex.StatusCode);
                Assert.NotNull(ex.ApiError);
                Assert.Equal(400, ex.ApiError.Status);
                Assert.Equal("bad_request", ex.ApiError.Error);
                Assert.Equal("name attribute can't be null", ex.ApiError.Message);
                Assert.NotNull(ex.ApiError.Cause);
                Assert.True(ex.ApiError.Cause.Count == 1);
                Assert.Equal("123", ex.ApiError.Cause[0].Code);
            }
        }

        [Fact]
        public async Task ListAsync_Simple_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            string json = File.ReadAllText("Client/Mock/DummyListResponse.json");
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json),
            };

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Get, httpResponse);

            ResourcesList<DummyResource> list =
                await client.ListAsync(path, MercadoPago.Http.HttpMethod.GET, null);

            Assert.NotNull(list);
            Assert.True(list.Count == 10);
        }

        [Fact]
        public void List_Simple_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            string json = File.ReadAllText("Client/Mock/DummyListResponse.json");
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json),
            };

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Get, httpResponse);

            ResourcesList<DummyResource> list =
                client.List(path, MercadoPago.Http.HttpMethod.GET, null);

            Assert.NotNull(list);
            Assert.True(list.Count == 10);
        }

        [Fact]
        public async Task SearchAsync_Parameters_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var request = new SearchRequest
            {
                Limit = 10,
                Offset = 100,
                Filters = new Dictionary<string, object>
                {
                    ["key"] = "value",
                },
            };
            string json = File.ReadAllText("Client/Mock/DummySearchResponse.json");
            var url = $"{MercadoPagoConfig.BaseUrl}{path}?key=value&limit=10&offset=100";
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json),
            };

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Get, httpResponse);

            ResultsResourcesPage<DummyResource> resultsSearchPage
                = await client.SearchAsync(path, request);

            Assert.NotNull(resultsSearchPage);
            Assert.NotNull(resultsSearchPage.Paging);
            Assert.Equal(1000, resultsSearchPage.Paging.Total);
            Assert.Equal(10, resultsSearchPage.Paging.Limit);
            Assert.Equal(0, resultsSearchPage.Paging.Offset);
            Assert.NotNull(resultsSearchPage.Results);
            Assert.True(resultsSearchPage.Results.Count > 0);
        }

        [Fact]
        public async Task SearchAsync_WithoutParameters_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var request = new SearchRequest();
            string json = File.ReadAllText("Client/Mock/DummySearchResponse.json");
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json),
            };

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Get, httpResponse);

            ResultsResourcesPage<DummyResource> resultsSearchPage
                = await client.SearchAsync(path, request);

            Assert.NotNull(resultsSearchPage);
            Assert.NotNull(resultsSearchPage.Paging);
            Assert.Equal(1000, resultsSearchPage.Paging.Total);
            Assert.Equal(10, resultsSearchPage.Paging.Limit);
            Assert.Equal(0, resultsSearchPage.Paging.Offset);
            Assert.NotNull(resultsSearchPage.Results);
            Assert.True(resultsSearchPage.Results.Count > 0);
        }

        [Fact]
        public async Task SearchAsync_NullParameters_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            SearchRequest request = null;
            string json = File.ReadAllText("Client/Mock/DummySearchResponse.json");
            var url = $"{MercadoPagoConfig.BaseUrl}{path}";
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json),
            };

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Get, httpResponse);

            ResultsResourcesPage<DummyResource> resultsSearchPage
                = await client.SearchAsync(path, request);

            Assert.NotNull(resultsSearchPage);
            Assert.NotNull(resultsSearchPage.Paging);
            Assert.Equal(1000, resultsSearchPage.Paging.Total);
            Assert.Equal(10, resultsSearchPage.Paging.Limit);
            Assert.Equal(0, resultsSearchPage.Paging.Offset);
            Assert.NotNull(resultsSearchPage.Results);
            Assert.True(resultsSearchPage.Results.Count > 0);
        }

        [Fact]
        public void Search_Parameters_Success()
        {
            var httpClientMock = new HttpClientMock();
            var httpClient = new DefaultHttpClient(httpClientMock.HttpClient);
            var client = new DummyClient(httpClient, null);
            var path = "/x";
            var request = new SearchRequest
            {
                Limit = 10,
                Offset = 100,
                Filters = new Dictionary<string, object>
                {
                    ["key"] = "value",
                },
            };
            var url = $"{MercadoPagoConfig.BaseUrl}{path}?key=value&limit=10&offset=100";
            string json = File.ReadAllText("Client/Mock/DummySearchResponse.json");
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json),
            };

            // Mock
            httpClientMock.MockRequest(url, System.Net.Http.HttpMethod.Get, httpResponse);

            ResultsResourcesPage<DummyResource> resultsSearchPage
                = client.Search(path, request);

            Assert.NotNull(resultsSearchPage);
            Assert.NotNull(resultsSearchPage.Paging);
            Assert.Equal(1000, resultsSearchPage.Paging.Total);
            Assert.Equal(10, resultsSearchPage.Paging.Limit);
            Assert.Equal(0, resultsSearchPage.Paging.Offset);
            Assert.NotNull(resultsSearchPage.Results);
            Assert.True(resultsSearchPage.Results.Count > 0);
        }
    }
}
