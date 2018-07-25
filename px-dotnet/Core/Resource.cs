using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using MercadoPago.Core.Linq;
using MercadoPago.DataStructures.Generic;
using MercadoPago.Validation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MercadoPago
{
    public abstract class ResourceBase
    {
        public RecuperableError Errors { get; internal set; }

        internal MPAPIResponse LastApiResponse { get; set; }

        internal JObject LastKnownJson { get; set; }

        /// <summary>
        /// Can be used to provider per-instance or per-request Access Tokens for the MercadoPago API. 
        /// If left null/empty, then the SDK.AccessToken is used instead.
        /// </summary>
        [JsonIgnore]
        public string UserAccessToken { get; set; }

        internal JObject GetJsonSource() => LastApiResponse?.JsonObjectResponse;
    }

    public abstract class Resource<T>: ResourceBase where T: ResourceBase, new()
    {
        internal static MPAPIResponse Invoke(HttpMethod httpMethod, string path, PayloadType payloadType, JObject payload, string accessToken, Dictionary<string, string> queryParameters, bool useCache, int requestTimeout, int retries)
        {
            path = CreatePath(path, accessToken, queryParameters);

            //TODO: Esto es un concern de la capa HTTP, deberia estar en el MPRestClient.
            //TODO: Se mantiene por el momento por compatibilidad con la clase MPBase.
            var headers = new WebHeaderCollection
            {
                "HTTP.CONTENT_TYPE: application/json",
                "HTTP.USER_AGENT: MercadoPago .NET SDK v1.0.1"
            };

            string cacheKey = httpMethod.ToString() + "_" + path;
            MPAPIResponse response = null;

            if (useCache)
            {
                response = MPCache.GetFromCache(cacheKey);

                if (response != null)
                {
                    response.IsFromCache = true;
                }
            }

            if (response == null)
            {
                response = new MPRESTClient().ExecuteRequest(
                    httpMethod,
                    path,
                    payloadType,
                    payload,
                    headers,
                    requestTimeout,
                    retries);

                if (useCache)
                {
                    MPCache.AddToCache(cacheKey, response);
                }
                else
                {
                    MPCache.RemoveFromCache(cacheKey);
                }
            }

            return response;
        }

        internal static string CreatePath(string path, string accessToken, Dictionary<string, string> queryParameters)
        {
            if (string.IsNullOrEmpty(path))
                throw new MPException("Must specify a valid path.");

            var queryString =
                queryParameters != null
                    ? "&" + string.Join("&", queryParameters.Select(x => $"{x.Key}={x.Value}").ToArray())
                    : "";

            return $"{SDK.BaseUrl}{path}?access_token={accessToken ?? SDK.GetAccessToken()}{queryString}";
        }

        #region New approach

        internal static T Get(string path, bool useCache = false, int requestTimeout = 0, int retries = 1)
        {
            var resource = new T();
            var response = Invoke(HttpMethod.GET, path, PayloadType.NONE, null, null, null, useCache, requestTimeout, retries);

            ProcessResponse(resource, response, HttpMethod.GET);
            return resource;
        }

        internal static List<T> GetList(string path, bool useCache = false, Dictionary<string, string> queryParameters = null, int requestTimeOut = 0, int retries = 1) 
        {
            var response = Invoke(HttpMethod.GET, path, PayloadType.NONE, null, null, queryParameters, useCache, requestTimeOut, retries);

            if (response.StatusCode >= 200 && response.StatusCode < 300)
            {
                return response.ToList<T>();
            }

            var exception = new MPException
            {
                StatusCode = response.StatusCode,
                ErrorMessage = response.StringResponse
            };

            if (response.JsonObjectResponse != null)
                exception.Cause.Add(response.JsonObjectResponse.ToString());

            throw exception;
        }

        internal static IQueryable<T> CreateQuery(string path, bool useCache = false) =>
            new MpQueryable<T>(path, useCache);

        internal T Post(string path, bool useCache = false, int requestTimeout = 0, int retries = 1) 
            => Send(this as T, HttpMethod.POST, path, useCache, requestTimeout, retries);

        internal T Put(string path, bool useCache = false, int requestTimeOut = 0, int retries = 1) 
            => Send(this as T, HttpMethod.PUT, path, useCache, requestTimeOut, retries);

        internal T Delete(string path, bool useCache = false, int requestTimeOut = 0, int retries = 1)
        {
            Send(this as T, HttpMethod.DELETE, path, useCache, requestTimeOut, retries);
            return null;
        }

        internal static T Send(T resource, HttpMethod httpMethod, string path, bool useCache = false, int requestTimeout = 0, int retries = 1)
        {
            var postOrPut = httpMethod == HttpMethod.POST || httpMethod == HttpMethod.PUT;

            var payload = GetPayload(resource, httpMethod);

            if (postOrPut)
                Validator.Validate(resource);

            var response = Invoke(httpMethod, path, PayloadType.JSON, payload, resource.UserAccessToken, null, useCache, requestTimeout, retries);

            ProcessResponse(resource, response, httpMethod);
            return resource;
        }

        internal static JObject GetPayload(T resource, HttpMethod httpMethod)
        {
            switch (httpMethod)
            {
                case HttpMethod.POST:
                    return resource.Serialize();
                case HttpMethod.PUT:
                    JObject jactual = resource.Serialize();
                    JObject jold = resource.LastKnownJson;
                    return Serialization.GetDiffFromLastChange(jactual, jold);
                default:
                    return null;
            }
        }

        internal static void ProcessResponse(T resource, MPAPIResponse response, HttpMethod httpMethod)
        {
            if (response.StatusCode >= 200 && response.StatusCode < 300)
            {
                if (httpMethod != HttpMethod.DELETE)
                {
                    FillResourceWithResponseData(resource, response);
                }
            }
            else if (response.StatusCode >= 400 && response.StatusCode < 500)
            {
                BadParamsError badParamsError = MPCoreUtils.GetBadParamsError(response.StringResponse);
                resource.Errors = badParamsError;
            }
            else
            {
                var exception = new MPException
                {
                    StatusCode = response.StatusCode,
                    ErrorMessage = response.StringResponse
                };

                exception.Cause.Add(response.JsonObjectResponse.ToString());

                throw exception;
            }
        }

        internal static void FillResourceWithResponseData(T resource, MPAPIResponse response) 
        {
            if (response.JsonObjectResponse is JObject jsonObject)
            {
                var result = jsonObject.Deserialize<T>();
                CopyProperties(result, resource);
                resource.LastKnownJson = jsonObject;
                resource.LastApiResponse = response;
            }
        }

        private static void CopyProperties(T source, T destination)
        {
            var ignoreProperties =
                new[]
                {
                    nameof(LastKnownJson),
                    nameof(LastApiResponse),
                    nameof(Errors),
                    nameof(UserAccessToken)
                };

            var properties =
                from p in destination.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                where !ignoreProperties.Contains(p.Name)
                let v = p.GetValue(source, null)
                select new
                {
                    Property = p,
                    Value = v
                };

            foreach (var p in properties)
                p.Property.SetValue(destination, p.Value,null);
        }

        #endregion
    }
}