using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public abstract class MPBase
    {
        public static bool WITHOUT_CACHE = false;
        public static bool WITH_CACHE = true;

        protected MPBase processMethod(Type clazz, string methodName, string param, bool useCache)
        {
            Dictionary<string, string> mapParams = null;
            mapParams.Add("param1", param);
            MPBase resource = processMethod(clazz, this, methodName, mapParams, useCache);
            fillResource(resource, this);
            return (MPBase)this;
        }

        protected static MPBase processMethod(object param1, MPBase param2, string name, Dictionary<string, string> parameters, bool useCache)
        {
            return null;
        }

        protected static void fillResource(MPBase resource, MPBase baseObj)
        {
        }

    }
}
