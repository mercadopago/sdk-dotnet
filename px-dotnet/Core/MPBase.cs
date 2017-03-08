using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Net;
using System.Diagnostics;

namespace MercadoPago
{
    public abstract class MPBase
    {
        public static bool WITHOUT_CACHE = false;
        public static bool WITH_CACHE = true;

        public string Method { get; set; }
        public string Url { get; set; }
        public string Instance { get; set; }

        public static MPBase processMethod(string methodName, bool useCache)
        {
            Type classType = GetTypeFromStack();
            Dictionary<string, string> mapParams = new Dictionary<string, string>();
            return processMethod<MPBase>(classType, null, methodName, null, useCache);
        }

        public static MPBase processMethod(string methodName, string param, bool useCache)
        {
            Type classType = GetTypeFromStack();
            Dictionary<string, string> mapParams = new Dictionary<string, string>();
            mapParams.Add("param1", param);

            return processMethod<MPBase>(classType, null, methodName, mapParams, useCache);
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
                if (annotation is BaseEndpoint)
                {
                    if (string.IsNullOrEmpty(((BaseEndpoint)annotation).Path))
                    {
                        throw new MPException(string.Format("Path not found for {0} method", ((BaseEndpoint)annotation).HttpMethod.ToString()));
                    }
                }
                else {
                    throw new MPException("Not supported method found");
                }

                hashAnnotation = new Dictionary<string, object>();
                hashAnnotation.Add("method", ((BaseEndpoint)annotation).HttpMethod.ToString());
                hashAnnotation.Add("url", ((BaseEndpoint)annotation).Path);
                hashAnnotation.Add("instance", element.ReturnType.Name);
            }

            return hashAnnotation;
        }

        #region Tracking Methods
        /// <summary>
        /// Get Type of a required class string name.
        /// </summary>
        /// <param name="typeName">Class name.</param>
        /// <returns>Type of required class.</returns>
        public static Type GetTypeFromStack()
        {
            MethodBase methodBase = new StackTrace().GetFrame(2).GetMethod();
            var className = methodBase.DeclaringType.FullName;
            var type = Type.GetType(className);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(className);
                if (type != null)
                    return type;
            }
            return null;
        }
        #endregion
    }
}
