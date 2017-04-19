using MercadoPago.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MercadoPago.Core
{
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

        public static MPBase Manage(string topic, string id)
        {
            
            if (topic == null || id == null)
            {
                throw new MPException("Topic and Id can not be null in the IPN request.");
            }

            MPBase resourceObject = null;
            Type classType = null;
            
            try 
            {
                classType = GetType(topic);
                if (!classType.IsSubclassOf(typeof(MPBase))) 
                {
                    throw new MPException(classType.Name + " does not extend from MPBase");
                }

                MethodInfo method = classType.GetMethod("Load", new [] { typeof(string)});

                object classInstance = Activator.CreateInstance(classType, null);
                object[] parametersArray = new object[] { id };

                resourceObject = (MPBase) method.Invoke(classInstance, parametersArray);

            } 
            catch (Exception ex) 
            {
                throw new MPException(ex.Message);
            }
            return resourceObject;            
        }        
    }
}
