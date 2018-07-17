using MercadoPago;
using MercadoPago.Resources;
using NUnit.Framework;
using System; 
using System.Net;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture]
    public class CardTest
    {
        string AccessToken;
        string PublicKey;
        Customer LastCustomer;
        Card LastCard;

        [SetUp]
        public void Init()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            // HardCoding Credentials
            AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
            PublicKey = Environment.GetEnvironmentVariable("PUBLIC_KEY");
            // Make a Clean Test
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = AccessToken;
        }

        [Test()]
        public void Card_CreateShouldBeOk()
        { 
            Customer customer = new Customer()
            {
                Email = "temp.customer@gmail.com"
            };
            customer.Save();

            Card card = new Card()
            {
                CustomerId = customer.Id,
                Token = Helpers.CardHelper.SingleUseCardToken(PublicKey, "pending")
            };

            card.Save();

            LastCustomer = customer;
            LastCard = card;

            Assert.IsNotEmpty(card.Id); 

        }


        [Test()]
        public void Card_FindById_ShouldBeOk()
        {
            Card card = Card.FindById(LastCustomer.Id, LastCard.Id); 
            Console.WriteLine("CardId: {0}", card.Id);
            Assert.IsNotEmpty(card.Id);  
        }
        
        [Test()]
        public void Card_UpdateShouldBeOk()
        {
            string LastToken = LastCard.Token;
            LastCard.Token = Helpers.CardHelper.SingleUseCardToken(PublicKey, "not_founds"); 
            LastCard.Update();

            Assert.AreNotEqual(LastToken, LastCard.Token);
        }
          

        [Test()]
        public void RemoveCard()
        {
            LastCard.Delete();
            LastCustomer.Delete();
        }
    }
}
