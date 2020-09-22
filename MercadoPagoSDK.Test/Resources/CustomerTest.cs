using MercadoPago;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using MercadoPago.DataStructures.Customer;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture]
    public class CustomerTest : BaseResourceTest
    {
        [Test]
        public void CustomerCreateTest()
        {
            Customer customer = NewCustomer();
            customer.Save();
            Assert.IsNotNull(customer.Id);

            customer.Delete();
            Assert.IsNull(customer.Errors);
        }

        [Test]
        public void UpdateCustomerTest()
        {
            Customer customer = NewCustomer();
            customer.Save();
            Assert.IsNotNull(customer.Id);

            customer.FirstName = "New";
            customer.Update();
            Assert.IsNull(customer.Errors);

            customer.Delete();
            Assert.IsNull(customer.Errors);
        }

        [Test]
        public void FindByIdCustomerTest()
        {
            Customer customer = NewCustomer();
            customer.Save();
            Assert.IsNotNull(customer.Id);

            var findCustomer = Customer.FindById(customer.Id);
            Assert.IsNotNull(findCustomer);
            Assert.AreEqual(customer.Id, findCustomer.Id);

            customer.Delete();
            Assert.IsNull(customer.Errors);
        }

        [Test]
        public void SearchCustomersTest()
        {
            Customer customer = NewCustomer();
            customer.Save();
            Assert.IsNotNull(customer.Id);

            var filter = new Dictionary<String, String>
            {
                { "email", customer.Email },
            };
            var customers = Customer.Search(filter);
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());

            customer.Delete();
            Assert.IsNull(customer.Errors);
        }

        private static Customer NewCustomer()
        {
            return new Customer()
            {
                FirstName = "Test",
                LastName = "Payer",
                Email = "test_payer_999977@testuser.com",
                LiveMode = false,
                Phone = new Phone
                {
                    AreaCode = "03492",
                    Number = "123456",
                },
                Description = "customer description",
                Identification = new Identification
                {
                    Type = "CPF",
                    Number = "19119119100",
                },
                Metadata = new Newtonsoft.Json.Linq.JObject
                {
                    { "test", "123" },
                },
            };
        }
    }
}
