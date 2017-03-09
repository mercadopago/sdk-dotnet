using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace MercadoPago
{
    public abstract class MPBase
    {
        #region Variables
        public static bool WITHOUT_CACHE = false;               
        public static bool WITH_CACHE = true;
        
        public string Method { get; set; }               
        public string Url { get; set; }
        public string Instance { get; set; }
        #endregion

        #region Core Methods
        /// <summary>
        /// Retrieve a MPBase resource based on a specfic method and configuration.
        /// </summary>
        /// <param name="methodName">Name of the method we are trying to call.</param>
        /// <param name="useCache">Cache configuration.</param>
        /// <returns>MPBase resource.</returns>
        public static MPBase processMethod(string methodName, bool useCache)
        {
            Type classType = GetTypeFromStack();
            Dictionary<string, string> mapParams = new Dictionary<string, string>();
            return processMethod<MPBase>(classType, null, methodName, null, useCache);
        }

        /// <summary>
        /// Retrieve a MPBase resource based on a specfic method, parameters and configuration.
        /// </summary>
        /// <param name="methodName">Name of the method we are trying to call.</param>
        /// <param name="param">Parameters to use in the retrieve process.</param>
        /// <param name="useCache">Cache configuration.</param>
        /// <returns>MPBase resource.</returns>
        public static MPBase processMethod(string methodName, string param, bool useCache)
        {
            Type classType = GetTypeFromStack();
            Dictionary<string, string> mapParams = new Dictionary<string, string>();
            mapParams.Add("param1", param);

            return processMethod<MPBase>(classType, null, methodName, mapParams, useCache);
        }

        /// <summary>
        /// Retrieve a MPBase resource based on a specific method and configuration.       
        /// </summary>
        /// <typeparam name="T">Object derived from MPBase abstract class.</typeparam>
        /// <param name="methodName">Name of the method we are trying to call.</param>
        /// <param name="useCache">Cache configuration</param>
        /// <returns>MPBase resource.</returns>
        public MPBase processMethod<T>(string methodName, bool useCache) where T : MPBase
        {
            Dictionary<string, string> mapParams = null;
            T resource = processMethod<T>(this.GetType(), (T)this, methodName, mapParams, useCache);

            return (T)this;
        }       

        /// <summary>
        /// Core implementation of processMethod. Retrieves a generic type. 
        /// </summary>
        /// <typeparam name="T">Generic type that will return.</typeparam>
        /// <param name="clazz">Type of Class we are using.</param>
        /// <param name="resource">Resource we will use and return in the implementation.</param>
        /// <param name="methodName">The name of the method  we are trying to call.</param>
        /// <param name="parameters">Parameters to use in the process.</param>
        /// <param name="useCache">Cache configuration.</param>
        /// <returns>Generic type object, containing information about retrieval process.</returns>
        protected static T processMethod<T>(Type clazz, T resource, string methodName, Dictionary<string, string> parameters, bool useCache) where T : MPBase
        {
            if (resource == null)
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

        /// <summary>
        /// Get the method we are searching on a specific class type.
        /// </summary>
        /// <param name="clazz">Type of class we are using.</param>
        /// <param name="methodName">Method we are trying to call.</param>
        /// <returns>Info about the method we are searching.</returns>
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

        /// <summary>
        /// Get rest information based on method info.
        /// </summary>
        /// <param name="element">MethodInfo containing information about the method we are trying to call.</param>
        /// <returns>Dictionary with custom information.</returns>
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
        #endregion

        #region Tracking Methods
        /// <summary>
        /// Get Type of a required class by it's string name.
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

        #region Core Utilities
        /// <summary>
        /// Generates a final Path based on parameters in Dictionary and resource properties.
        /// </summary>
        /// <typeparam name="T">MPBase resource.</typeparam>
        /// <param name="path">Path we are processing.</param>
        /// <param name="mapParams">Collection of parameters that we will use to process the final path.</param>
        /// <param name="resource">Resource containing parameters values to include in the final path.</param>
        /// <returns>Processed path to call the API.</returns>
        public static string ParsePath<T>(string path, Dictionary<string, string> mapParams, T resource) where T : MPBase
        {
            StringBuilder result = new StringBuilder();
            if (path.Contains(':'))
            {
                int paramIterator = 0;
                while (path.Contains(':'))
                {
                    result.Append(path.Substring(0, path.IndexOf(':')));
                    path = path.Substring(path.IndexOf(':') + 1);
                    string param = path;
                    if (path.Contains('/'))
                    {
                        param = path.Substring(0, path.IndexOf('/'));
                    }

                    string value = string.Empty;
                    if (paramIterator <= 2 &&
                            mapParams != null &&
                            !string.IsNullOrEmpty(mapParams[string.Format("param{0}", paramIterator.ToString())]))
                    {
                        value = mapParams[string.Format("param{0}", paramIterator.ToString())];
                    }
                    else if (mapParams != null &&
                         !string.IsNullOrEmpty(mapParams[param]))
                    {
                        value = mapParams[param];
                    }
                    else
                    {
                        if (resource != null)
                        {
                            JObject json = JObject.FromObject(resource);
                            var jValue = json.GetValue(param);

                            if (jValue != null)
                            {
                                value = jValue.ToString();
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new MPException("No argument supplied/found for method path");
                    }

                    result.Append(value);
                    if (path.Contains('/'))
                    {
                        path = path.Substring(path.IndexOf('/'));
                    }
                    else
                    {
                        path = string.Empty;
                    }
                }

                if (!string.IsNullOrEmpty(path))
                {
                    result.Append(path);
                }
            }
            else
            {
                result.Append(path);
            }

            return result.ToString();
        }
        #endregion
    }
}
