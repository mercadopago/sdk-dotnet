using MercadoPago;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using MercadoPago.DataStructures.Customer;

namespace MercadoPagoSDK.Test.Resources
{
    
    [TestFixture]
    public class CustomerTest
    {

        string AccessToken;
        
        Customer LastCustomer;

        [SetUp]
        public void Init()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            // HardCoding Credentials
            AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
            // Make a Clean Test
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = AccessToken;
        }

        [Test()]
        public void Customer_Create_ShouldBeOk()
        {
            Customer customer = new Customer()
            {
                FirstName = "Rafa",
                LastName = "Williner",
                Email = "Rafa.Williner@gmail.com",
                Address = new Address { 
                    StreetName = "some street", 
                    ZipCode = "2300" 
                },
                Phone = new Phone { 
                    AreaCode = "03492", 
                    Number = "432334" 
                },
                Description = "customer description",
                Identification = new Identification {
                    Type = "DNI", 
                    Number = "29804555"
                }
            };

            customer.Save(); 
            LastCustomer = customer;

            Assert.IsTrue(customer.Id != null, $"Failed: Customer could not be successfully created: {customer.Errors?.Message}");

            Console.WriteLine("id: {0}", customer.Id.ToString());
        }

        [Test()]
        public void Customer_FindById_ShouldBeOk()
        { 
            Customer customer = Customer.FindById(LastCustomer.Id);  
            Assert.AreEqual(customer.FirstName, LastCustomer.FirstName);   
        }

        [Test()]
        public void Customer_Update_ShouldBeOk()
        {
            LastCustomer.LastName = "Calciati Rodriguez";
            LastCustomer.Update();
 
            Assert.AreEqual(LastCustomer.LastName, "Calciati Rodriguez");
        }

        [Test()]
        public void Remove_Customer()
        {
            string LastId = LastCustomer.Id;

            try {
                LastCustomer.Delete();
                Assert.Pass();
            } 
            catch (ArgumentException _e)
            { 
                Assert.Fail();
            };
            
        }

        [Test()]
        public void Customer_SearchWithFilterGetListOfCustomers()
        {
            Thread.Sleep(1000);
            Dictionary<string, string> filters = new Dictionary<string, string>();
            filters.Add("email", "Rafa.Williner@gmail.com");
            List<Customer> customers = Customer.Search(filters);

            Assert.IsTrue(customers.Any());
            Assert.IsNotNull(customers.First());
            Assert.AreEqual(customers.First().Email, "Rafa.Williner@gmail.com");
        }
    }
}
