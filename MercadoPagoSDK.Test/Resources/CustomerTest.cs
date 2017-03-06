using MercadoPago;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test
{
    [TestFixture()]
    public class CustomerTest
    {
        [Test()]
        public void Customer_ShouldDoSomething()
        {
            Customer customer = new Customer();

            // create first, so Id is assigned. Now will fail.


            customer = Customer.load(customer.getId(), MPBase.WITH_CACHE);

        }
    }
}
