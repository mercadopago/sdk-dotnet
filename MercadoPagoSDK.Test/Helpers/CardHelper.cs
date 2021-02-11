using System;
using System.Collections.Generic;
using System.Linq;
using MercadoPago;
using Newtonsoft.Json.Linq;

namespace MercadoPagoSDK.Test.Helpers
{
    public static class CardHelper
    {
        public static string SingleUseCardToken(string Status)
        {
            JObject payload = JObject.Parse(CardDummyWithSpecificStatus(Status));

            MPRESTClient client = new MPRESTClient();
            String path = "https://api.mercadopago.com/v1/card_tokens";
            MPAPIResponse responseCardToken = client.ExecuteRequest(HttpMethod.POST, path, PayloadType.JSON, payload, null, 0, 1);
 
            JObject jsonResponse = JObject.Parse(responseCardToken.StringResponse.ToString());
            List<JToken> tokens = MPCoreUtils.FindTokens(jsonResponse, "id");
            return tokens.First().ToString();
        }

        public static string CardDummyWithSpecificStatus(string status)
        {

            Dictionary<String, String> CardsNameForStatus = new Dictionary<String, String>
            {
                {"approved", "APRO"},
                {"pending", "CONT"},
                {"call_for_auth", "CALL"},
                {"not_founds", "FUND"},
                {"expirated", "EXPI"},
                {"form_error", "FORM"},
                {"general_error", "OTHE"}
            };

            string StringPayload = "{ " +
                "\"card_number\": \"5031433215406351\", " +
                "\"security_code\": \"123\", " +
                "\"expiration_month\": \"7\", " +
                "\"expiration_year\": \"2030\", " +
                "\"cardholder\": " +
                    "{ " +
                        "\"name\": \"" + CardsNameForStatus[status] + "\", " +
                        "\"identification\": " +
                        "{ " +
                            "\"type\": \"CPF\", " +
                            "\"number\": \"37462770865\" " +
                        "} " +
                    "} " +
                "}";



            return StringPayload;

        }
    }
}
