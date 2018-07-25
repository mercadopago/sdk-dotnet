using MercadoPago.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MercadoPago.Core
{
    [Obsolete("Use " + nameof(Ipn) + " instead.")]
    public class MPIPN
    {        
        public partial class Topic
        {                                    
            public static String merchantOrder { get { return "MercadoPago.Resources.MerchantOrder"; } }
            public static String payment { get { return "MercadoPago.Resources.Payment"; } }                
        }

        public static Type GetType(string resourceClassName)
        {
            var type = Type.GetType(resourceClassName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(resourceClassName);
                if (type != null)
                    return type;
            }
            return null;
        }

        public static T Manage<T>(string topic, string id) where T : ResourceBase
        {
            
            if (string.IsNullOrEmpty(topic) || string.IsNullOrEmpty(id))
            {
                throw new MPException("Topic and Id can not be null in the IPN request.");
            }

            T resourceObject = null;
                        
            try 
            {
                Type classType = GetType(topic);
                if (!classType.IsSubclassOf(typeof(ResourceBase))) 
                {
                    throw new MPException(classType.Name + " does not extend from MPBase");
                }

                MethodInfo method = classType.GetMethod("Load", new[] { typeof(string) });

                object classInstance = Activator.CreateInstance(classType, null);
                object[] parametersArray = new object[] { id };

                resourceObject = (T)method.Invoke(classInstance, parametersArray);
            } 
            catch (Exception ex) 
            {
                throw new MPException(ex.Message);
            }

            return resourceObject;            
        }        
    }
}
