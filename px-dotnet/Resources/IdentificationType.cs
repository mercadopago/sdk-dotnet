using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MercadoPago.Resources
{
    public class IdentificationType : Resource<IdentificationType>
    {
        public static List<IdentificationType> GetAll(bool useCache = false) => GetList("/v1/identification_types", useCache);

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int MinLength { get; set; }

        public int MaxLength { get; set; }
    }
}