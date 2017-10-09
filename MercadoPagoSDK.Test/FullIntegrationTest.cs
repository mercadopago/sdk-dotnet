using MercadoPago;
using MercadoPago.Resources;
using MercadoPago.Resources.DataStructures.Customer;
using MercadoPago.Resources.DataStructures.Payment;
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
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            Dictionary<string, string> config = new Dictionary<string, string>();
            SDK.AccessToken = "TEST-4205497482754834-092513-34a1c5f06438b3a488bad9420cfe84e5__LB_LD__-261220529";

            //Customer customer = new Customer();

            //customer.Email = "test_user_112299654@testuser.com";
            //customer.FirstName = "Jack";
            //customer.LastName = "Bauer";
            //customer.Phone = new MercadoPago.Resources.DataStructures.Customer.Phone() { AreaCode = "3492", Number = "112233" };
            //customer.Identification = new MercadoPago.Resources.DataStructures.Customer.Identification() { Type = "DNI", Number = "12345678" };

            //Customer customerResult = new Customer();

            //customer = customer.Create();

            //var newCustomerTwo = (Customer)customer.GetLastApiResponse().JsonObjectResponse.ToObject<Customer>();
            //var newCustomer = JsonConvert.DeserializeObject<Customer>(customer.GetLastApiResponse().JsonObjectResponse.ToString());
            //Assert.AreEqual(201, customer.GetLastApiResponse().StatusCode);

            //Assert.NotNull(customer.GetLastApiResponse().JsonObjectResponse["id"].ToString());

            //customer = Customer.Load(customer.GetLastApiResponse().JsonObjectResponse["id"].ToString(), MPBase.WITH_CACHE);
            //Assert.AreEqual(200, customer.GetLastApiResponse().StatusCode);
            //Assert.NotNull(customer.ID);
            ////Load Response don't came with the all data. Check that.
            ////Assert.AreEqual("Jack", customer.FirstName);
            ////Assert.AreEqual("Bauer", customer.LastName);
            //Assert.IsFalse(customer.GetLastApiResponse().isFromCache);
            //customer = Customer.Load(customer.ID, MPBase.WITH_CACHE);
            //Assert.IsTrue(customer.GetLastApiResponse().isFromCache);          

            ////Give a 401 error.
            ////List<Customer> resourceArray = null;
            ////resourceArray = Customer.Search(MPBase.WITH_CACHE);
            ////Assert.AreEqual(200, resourceArray.FirstOrDefault().GetLastApiResponse().StatusCode);
            ////Assert.AreEqual(1, resourceArray.Count());
            ////Assert.IsFalse(resourceArray.FirstOrDefault().GetLastApiResponse().isFromCache);

            ////resourceArray = Customer.Search(MPBase.WITH_CACHE);

            ////Assert.AreEqual(200, resourceArray.FirstOrDefault().GetLastApiResponse().StatusCode);
            ////Assert.AreEqual(1, resourceArray.Count());
            ////Assert.IsTrue(resourceArray.FirstOrDefault().GetLastApiResponse().isFromCache);

            //String random = System.Guid.NewGuid().ToString();
            //customer.Description = random;
            //customer.Update();
            //Assert.AreEqual(200, customer.GetLastApiResponse().StatusCode);
            ////Not retrieving updated data.
            ////Assert.AreEqual(random, customer.Description);            

            // test with payment

            //// test with payments 
            //Payer payer = new Payer();
            //payer.Email = "test_user_112299654@testuser.com";
            //Payment p = new Payment();
            //p.TransactionAmount = 123;
            //p.PaymentMethodId = "visa";
            //p.Description = "Payment test 123 pesos";
            //p.Token = SDK.AccessToken;
            //p.Installment = 1;
            //p.Payer = payer;
            //p.Create();

            // test with payments  MAXO
            //Payer payer = new Payer();
            //payer.email = "mlovera@kinexo.com";

            //Payment payment = new Payment();
            //payment.transaction_amount = 1M;
            //payment.token = "114758584839b359a157fb8302ecacad";
            //payment.description = "Pago de seguro";
            //payment.payment_method_id = "visa";
            //payment.installments = 1;
            //payment.payer = payer;

            //Payment response = payment.Create();


            //Assert.Equals(201, p.GetLastApiResponse().StatusCode);
            //Assert.NotNull(p.ID);
            //Assert.False(p.Captured);
        }        
    }
}
