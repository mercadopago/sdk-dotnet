using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Net;

namespace MercadoPago
{
    public abstract class MPBase
    {
        public static bool WITHOUT_CACHE = false;
        public static bool WITH_CACHE = true;

        public string Method { get; set; }
        public string Url { get; set; }
        public string Instance { get; set; }

        public static MPBase processMethod(Type clazz, string methodName, bool useCache)
        {
            Dictionary<string, string> mapParams = new Dictionary<string, string>();
            return processMethod<MPBase>(clazz, null, methodName, null, useCache);
        }

        public static MPBase processMethod(Type clazz, string methodName, string param, bool useCache)
        {
            Dictionary<string, string> mapParams = new Dictionary<string, string>();
            mapParams.Add("param1", param);

            return processMethod<MPBase>(clazz, null, methodName, mapParams, useCache);
        }

        public MPBase processMethod<T>(string methodName, bool useCache) where T : MPBase
        {
            Dictionary<string, string> mapParams = null;
            T resource = processMethod<T>(this.GetType(), (T)this, methodName, mapParams, useCache);

            return (T)this;
        }       

        protected static T processMethod<T>(Type clazz, T resource, string methodName, Dictionary<string, string> parameters, bool useCache) where T : MPBase
        {
            if (resource == null) // later...
            {
                try
                {
                    resource = (T)Activator.CreateInstance(clazz);
                }
                catch (Exception ex)
                {
                    throw new MPException(ex.Message);
                }
            }


            var clazzMethod = getAnnotatedMethod(clazz, methodName);
            var apiData = getRestInformation(clazzMethod);

            resource.Method = apiData["method"].ToString();
            resource.Url = string.Format("{0}", parameters != null ? apiData["url"].ToString().Replace(":id", parameters["param1"]) : apiData["url"].ToString());
            resource.Instance = apiData["instance"].ToString();

            return resource;
        }

        private static MethodInfo getAnnotatedMethod(Type clazz, String methodName)
        {
            foreach (MethodInfo method in clazz.GetMethods())
            {
                if (method.Name == methodName && method.GetCustomAttributes(false).Length > 0)
                {
                    return method;
                }
            }

            throw new MPException("No annotated method found");
        }

        private static Dictionary<string, object> getRestInformation(MethodInfo element)
        {
            if (element.GetCustomAttributes(false).Length == 0)
            {
                throw new MPException("No rest method found");
            }

            Dictionary<string, object> hashAnnotation = new Dictionary<string, object>();
            foreach (Attribute annotation in element.GetCustomAttributes(false))
            {
                if (annotation is GETEndpoint)
                {
                    GETEndpoint get = (GETEndpoint)annotation;
                    if (string.IsNullOrEmpty(get.Path()))
                    {
                        throw new MPException("Path not found for GET method");
                    }

                    hashAnnotation = new Dictionary<string, object>();
                    hashAnnotation.Add("method", "GET");
                    hashAnnotation.Add("url", get.Path());
                    hashAnnotation.Add("instance", element.ReturnType.Name);
                }
                else if (annotation is POSTEndpoint)
                {
                    POSTEndpoint post = (POSTEndpoint)annotation;
                    if (string.IsNullOrEmpty(post.Path()))
                    {
                        throw new MPException("Path not found for POST method");
                    }

                    hashAnnotation = new Dictionary<string, object>();
                    hashAnnotation.Add("method", "POST");
                    hashAnnotation.Add("url", post.Path());
                    hashAnnotation.Add("instance", element.ReturnType.Name);
                }
                else if (annotation is PUTEndpoint)
                {
                    PUTEndpoint put = (PUTEndpoint)annotation;
                    if (string.IsNullOrEmpty(put.Path()))
                    {
                        throw new MPException("Path not found for PUT method");
                    }

                    hashAnnotation = new Dictionary<string, object>();
                    hashAnnotation.Add("method", "PUT");
                    hashAnnotation.Add("url", put.Path());
                    hashAnnotation.Add("instance", element.ReturnType.Name);
                }

                else {
                    throw new MPException("Not supported method found");
                }
            }

            return hashAnnotation;
        }
    }
}
