namespace MercadoPago.Tests.Client.Helper
{
    using System.Collections.Generic;
    using MercadoPago.Client.Common;
    using MercadoPago.Resource.User;

    public static class IdentificationHelper
    {
        private static readonly IDictionary<string, string> SiteIdDocType = new Dictionary<string, string>
        {
            ["MLA"] = "DNI",
            ["MLB"] = "CPF",
            ["MLM"] = "RFC",
            ["MCO"] = "NIT",
            ["MLC"] = "RUT",
            ["MPE"] = "RUC",
            ["MLU"] = "CI",
        };

        private static readonly IDictionary<string, string> SiteIdDocNumber = new Dictionary<string, string>
        {
            ["MLA"] = "37106038",
            ["MLB"] = "37462770865",
            ["MLM"] = "TETT780407PZ1",
            ["MCO"] = "12576721410",
            ["MLC"] = "78007311",
            ["MPE"] = "12345678900",
            ["MLU"] = "6238067",
        };

        public static IdentificationRequest GetIdentification(User user)
        {
            return new IdentificationRequest
            {
                Type = SiteIdDocType[user.SiteId],
                Number = SiteIdDocNumber[user.SiteId],
            };
        }
    }
}
