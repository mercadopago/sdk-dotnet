using System.ComponentModel.DataAnnotations;
using System.Linq;
using MercadoPago;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Validation;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Validations
{
    [TestFixture]
    public class NestedValidationTest: ResourceBase
    {
        [Required]
        public Payer? Payer { get; set; }

        [Test]
        public void Validator_TestNestedRequiredObjectValidation()
        {
            var instance = new NestedValidationTest();
            var error = GetValidationError(instance, ValidationError.RequiredErrorCode);
            Assert.IsNotNull(error);

            instance.Payer = new Payer();
            error = GetValidationError(instance, ValidationError.RequiredErrorCode);
            Assert.IsNull(error);
        }

        [Test]
        public void Validator_TestNestedValidation()
        {
            var instance = new NestedValidationTest
            {
                Payer = new Payer
                {
                    Name = new string('x', 1000),
                }
            };

            var error = GetValidationError(instance, ValidationError.StringLengthErrorCode);
            Assert.IsNotNull(error);

            instance.Payer = new Payer {Name = "Name"};
            error = GetValidationError(instance, ValidationError.StringLengthErrorCode);
            Assert.IsNull(error);

            instance = new NestedValidationTest
            {
                Payer = new Payer
                {
                    Name = "Payer",
                    Address = new Address
                    {
                        StreetName = new string('x', 1000),
                    }
                }
            };

            error = GetValidationError(instance, ValidationError.StringLengthErrorCode);
            Assert.IsNotNull(error);
        }

        private ValidationError GetValidationError(object instance, int errorCode) =>
            Validator.GetValidationErrors(instance)
                     .FirstOrDefault(x => x.Code == errorCode);
    }
}