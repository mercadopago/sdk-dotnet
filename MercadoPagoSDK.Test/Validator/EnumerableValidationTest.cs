using System.Collections.Generic;
using System.Linq;
using MercadoPago;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Validation;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Validations
{
    [TestFixture]
    public class EnumerableValidationTest : ResourceBase
    {
        public List<Item> Items { get; set; }

        [Test]
        public void Validator_TestNestedListValidation()
        {
            var instance = new EnumerableValidationTest
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Id = new string('x', 1000)
                    }
                }
            };

            var error = GetValidationError(instance, ValidationError.StringLengthErrorCode);
            Assert.IsNotNull(error);

            instance.Items[0] = new Item{Id = "1234"};
            error = GetValidationError(instance, ValidationError.StringLengthErrorCode);
            Assert.IsNull(error);
        }

        private ValidationError GetValidationError(object instance, int errorCode) =>
            Validator.GetValidationErrors(instance)
                .FirstOrDefault(x => x.Code == errorCode);
    }
}