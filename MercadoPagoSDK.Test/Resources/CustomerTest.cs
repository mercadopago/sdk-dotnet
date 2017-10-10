using MercadoPago;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture()]
    public class CustomerTest
    {
        [Test()]
        public void Customer_CreateCustomerGetsCreatedCustomerInResponse()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            Customer newCustomer = new Customer
            {
                first_name = "Rafa",
                last_name = "Williner",
                address = new MercadoPago.Resources.DataStructures.Customer.DefaultAddress { street_name = "some street", zip_code = "2300" },
                phone = new MercadoPago.Resources.DataStructures.Customer.Phone { area_code = "03492", number = "432334" },
                description = "customer description",
                identification = new MercadoPago.Resources.DataStructures.Customer.Identification { type = "DNI", number = "29804555" }
            };

            Customer responseCustomer = newCustomer.Create();

            Assert.AreEqual(201, responseCustomer.GetLastApiResponse().StatusCode);
            Assert.AreEqual(newCustomer.first_name, responseCustomer.first_name);
            Assert.AreEqual(newCustomer.last_name, responseCustomer.last_name);
            Assert.AreEqual(newCustomer.phone.number, responseCustomer.phone.number);
            Assert.AreEqual(newCustomer.identification.number, responseCustomer.identification.number);
            Assert.AreEqual(newCustomer.address.street_name, responseCustomer.address.street_name);
            Assert.AreEqual(newCustomer.description, responseCustomer.description);
        }

        [Test()]
        public void Customer_CreateCustomerAndThenLoadGetsCreatedCustomer()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            Customer newCustomer = new Customer { first_name = "Juan", last_name = "Perez" };
            Customer responseCustomer = newCustomer.Create();

            Customer loadedCustomer1 = Customer.Load(responseCustomer.id);
            Customer loadedCustomer2 = Customer.Load(responseCustomer.id, false);

            Assert.AreEqual(200, loadedCustomer1.GetLastApiResponse().StatusCode);
            Assert.AreEqual(200, loadedCustomer2.GetLastApiResponse().StatusCode);
            Assert.AreEqual(loadedCustomer1.first_name, newCustomer.first_name);
            Assert.AreEqual(loadedCustomer1.last_name, newCustomer.last_name);
            Assert.AreEqual(loadedCustomer2.first_name, newCustomer.first_name);
            Assert.AreEqual(loadedCustomer2.last_name, newCustomer.last_name);
        }

        [Test()]
        public void Customer_CreateCustomerAndThenUpdateUpdatesCustomer()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            Customer newCustomer = new Customer { first_name = "Jorge", last_name = "Calciati" };
            Customer responseCustomer = newCustomer.Create();

            responseCustomer.last_name = "Calciati Rodriguez";
            responseCustomer.Update();

            Assert.AreEqual(200, responseCustomer.GetLastApiResponse().StatusCode);
            Assert.AreEqual("Calciati Rodriguez", responseCustomer.last_name);
        }

        [Test()]
        public void Customer_CreateCustomerAndThenDeleteDeletesCustomer()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            Customer newCustomer = new Customer { first_name = "Pedro", last_name = "Juarez" };
            Customer responseCustomer = newCustomer.Create();

            string id = responseCustomer.id;

            responseCustomer.Delete();

            Customer nonExistingCustomer = Customer.Load(responseCustomer.id, false);

            Assert.AreEqual(404, nonExistingCustomer.GetLastApiResponse().StatusCode);
        }

        [Test()]
        public void Customer_SearchCustomersReturnListOfCustomers()
        {
            SDK.CleanConfiguration();
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            List<Customer> customers = Customer.Search();

            Assert.IsTrue(customers.Any());
            Assert.IsNotNull(customers.First());
            Assert.IsTrue(customers.First() is Customer);
        }
    }
}
