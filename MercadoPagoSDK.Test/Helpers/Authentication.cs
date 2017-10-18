using System;
using System.Collections.Generic;
using System.Linq;
using MercadoPago;
using Newtonsoft.Json.Linq;

namespace MercadoPagoSDK.Test.Helpers
{
    public class Authentication
    {
        public static string SingleUseCardToken(string PublicKey)
        {
            JObject payload = JObject.Parse("{ \"card_number\": \"4509953566233704\", \"security_code\": \"122\", \"expiration_month\": \"7\", \"expiration_year\": \"2030\", \"cardholder\": { \"name\": \"APRO\", \"identification\": { \"type\": \"DNI\", \"number\": \"12345678\" } } }");
            Console.Out.WriteLine(PublicKey);
            MPRESTClient client = new MPRESTClient();
            String path = "https://api.mercadopago.com/v1/card_tokens?public_key=" + PublicKey;
            MPAPIResponse responseCardToken = client.ExecuteRequestCore(HttpMethod.POST, path, PayloadType.JSON, payload, null, 0, 1);

            Console.Out.WriteLine("cardTokenResponse");
            Console.Out.WriteLine(responseCardToken);

            JObject jsonResponse = JObject.Parse(responseCardToken.StringResponse.ToString());
            List<JToken> tokens = MPCoreUtils.FindTokens(jsonResponse, "id");
            return tokens.First().ToString();
        }
    }
}
