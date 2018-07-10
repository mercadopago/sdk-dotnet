using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MercadoPago
{
    internal class CustomSerializationContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        { 

            var property = base.CreateProperty(member, memberSerialization);
            NamingStrategy = new SnakeCaseNamingStrategy();

            property.ShouldSerialize = propInstance => property.Writable;

            if (!property.Readable)
            {
                var prop = member as PropertyInfo;
                if (property != null)
                {
                    var hasPrivateGetter = prop.GetGetMethod(true) != null;
                    property.Readable = hasPrivateGetter;
                }
            }

            return property;
        }
    }
}
