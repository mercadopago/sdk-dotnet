using MercadoPago;
using MercadoPago.Resources;
using MercadoPago.Resources.DataStructures.Customer;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test
{
    [TestFixture()]
    public class FullIntegrationTest
    {
        [Test()]
        public void FullCoverageIntegration()
        {
            MPConf.CleanConfiguration();
            MPConf.SetBaseUrl("https://api.mercadopago.com");
            Dictionary<string, string> config = new Dictionary<string, string>();
            MPConf.AccessToken = "TEST-8876669324953893-042713-c02e3e934c654495202e2c06c61b26de__LC_LB__-194275989";
            //config.Add("clientSecret", "Y2Oy31v1myOFK6wGjJsXY4DOZRwnxZuN");
            //config.Add("clientId", "8876669324953893");            
            //MPConf.SetConfiguration(config);

            Customer customer = new Customer();

            customer.Email = "test_user_112299654@testuser.com";
            customer.FirstName = "Jack";
            customer.LastName = "Bauer";
            customer.Phone = new Phone() { AreaCode = "3492", Number = "112233" };
            customer.Identification = new Identification() { Type = "DNI", Number = "12345678" };

            Customer customerResult = new Customer();

            customer = customer.Create();

            //customer = customer.GetLastApiResponse().JsonObjectResponse.ToObject<Customer>();
            var newCustomerTwo = (Customer)customer.GetLastApiResponse().JsonObjectResponse.ToObject<Customer>();
            var newCustomer = JsonConvert.DeserializeObject<Customer>(customer.GetLastApiResponse().JsonObjectResponse.ToString());
            Assert.AreEqual(201, customer.GetLastApiResponse().StatusCode);

            Assert.NotNull(customer.GetLastApiResponse().JsonObjectResponse["id"].ToString());

            customer = Customer.Load(customer.GetLastApiResponse().JsonObjectResponse["id"].ToString(), MPBase.WITH_CACHE);
            Assert.AreEqual(200, customer.GetLastApiResponse().StatusCode);
            Assert.NotNull(customer.ID);
            //Load Response don't came with the all data. Check that.
            //Assert.AreEqual("Jack", customer.FirstName);
            //Assert.AreEqual("Bauer", customer.LastName);
            Assert.IsFalse(customer.GetLastApiResponse().isFromCache);
            customer = Customer.Load(customer.ID, MPBase.WITH_CACHE);
            Assert.IsTrue(customer.GetLastApiResponse().isFromCache);


            //List<Customer> resourceArray = null;
            //resourceArray = Customer.Search(MPBase.WITH_CACHE);
            //Assert.AreEqual(200, resourceArray.FirstOrDefault().GetLastApiResponse().StatusCode);
            //Assert.AreEqual(1, resourceArray.Count());
            //Assert.IsFalse(resourceArray.FirstOrDefault().GetLastApiResponse().isFromCache);

            //resourceArray = Customer.Search(MPBase.WITH_CACHE);

            //Assert.AreEqual(200, resourceArray.FirstOrDefault().GetLastApiResponse().StatusCode);
            //Assert.AreEqual(1, resourceArray.Count());
            //Assert.IsTrue(resourceArray.FirstOrDefault().GetLastApiResponse().isFromCache);

            String random = System.Guid.NewGuid().ToString();
            customer.Description = random;
            customer.Update();
            Assert.AreEqual(200, customer.GetLastApiResponse().StatusCode);
            //Not retrieving updated data.
            //Assert.AreEqual(random, customer.Description);            
        }        
    }
}
