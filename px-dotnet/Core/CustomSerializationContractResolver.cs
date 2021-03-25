using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Reflection;

namespace MercadoPago
{
    public class CustomSerializationContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        { 

            var property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = propInstance =>
            {
                if (property.PropertyType != typeof(string) &&
                    typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    IEnumerable enumerable = null;
                    if (member.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo propertyInfo = propInstance
                                .GetType()
                                .GetProperty(member.Name);
                        if (propertyInfo != null)
                        {
                            enumerable = propertyInfo.GetValue(propInstance, null) as IEnumerable;
                        }
                    }

                    return enumerable == null ||
                       enumerable.GetEnumerator().MoveNext();
                }

                return property.Writable;
            };

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
