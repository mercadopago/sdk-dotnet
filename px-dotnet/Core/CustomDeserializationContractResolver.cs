using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MercadoPago
{
    internal class CustomDeserializationContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            try
            {
                var property = base.CreateProperty(member, memberSerialization);
                NamingStrategy = new SnakeCaseNamingStrategy();
                if (!property.Writable)
                {
                    var prop = member as PropertyInfo;
                    if (property != null)
                    {
                        var hasPrivateSetter = prop.GetSetMethod(true) != null;
                        property.Writable = hasPrivateSetter;
                    }
                }

                return property;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
