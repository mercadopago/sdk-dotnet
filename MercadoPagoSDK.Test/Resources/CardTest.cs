using MercadoPago;
using MercadoPago.Resources;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture]
    public class CardTest : BaseResourceTest
    {
        MPRESTClient _client;

        [OneTimeSetUp]
        public void Init()
        {
            _client = new MPRESTClient();
        }

        [Test]
        public void CardCreateTest()
        {
            var card = NewCard();
            card.Save();
            Assert.IsNull(card.Errors);
            Assert.IsNotNull(card.Id);

            card.Delete();
            Assert.IsNull(card.Errors);
        }

        [Test]
        public void CardFindTest()
        {
            var card = NewCard();
            card.Save();
            Assert.IsNotNull(card.Id);

            var findCard = Card.FindById(card.CustomerId, card.Id);
            Assert.IsNotNull(findCard);
            Assert.IsNull(findCard.Errors);
            Assert.AreEqual(card.Id, findCard.Id);
        }

        private Card NewCard()
        {
            var payload = new JObject
            {
                { "card_number", "4074090000000004" },
                { "security_code", "123" },
                { "expiration_month", "11" },
                { "expiration_year", DateTime.Now.AddYears(5).Year.ToString() },
                { "cardholder", new JObject
                    {
                        { "name", "APRO" },
                        { "identification", new JObject
                            {
                                { "type", "CPF" },
                                { "Number", "19119119100" },
                            }
                        },
                    }
                },
            };
            var url = String.Format("https://api.mercadopago.com/v1/card_tokens?public_key={0}", PublicKey);
            var response = _client.ExecuteRequest(HttpMethod.POST, url, PayloadType.JSON, payload);
            var jsonResponse = JObject.Parse(response.StringResponse.ToString());
            var token = jsonResponse.GetValue("id").ToString();

            return new Card
            {
                CustomerId = "649457098-FybpOkG6zH8QRm",
                Token = token,
            };
        }
    }
}
