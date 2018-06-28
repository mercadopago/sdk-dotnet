using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MercadoPago;
using MercadoPago.Validation;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Validations
{
    [TestFixture]
    public class ValidatorTest : MPBase
    {
        [RegularExpression(@"^(?:.*[a-z]){7,}$")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Range(5.0, 10.0)]
        public double TransactionAmount { get; set; }

        public ValidatorTest() { }

        public ValidatorTest(string name, string description, DateTime date, double transationAmount)
        {
            Name = name;
            Description = description;
            TransactionAmount = transationAmount;
        }

        private ValidationError GetValidationError(object instance, int errorCode) =>
            Validator.GetValidationErrors(instance)
                .FirstOrDefault(x => x.Code == errorCode);

        [Test]
        public void Validator_TestRequiredFieldValidation()
        {
            var instance = new ValidatorTest("abcdefghijklm", null, DateTime.Now, 8.0);

            var requiredError = GetValidationError(instance, ValidationError.RequiredErrorCode);
            Assert.IsNotNull(requiredError);

            instance.Description = string.Empty;
            requiredError = GetValidationError(instance, ValidationError.RequiredErrorCode);
            Assert.IsNotNull(requiredError);

            instance.Description = "Some Description";
            requiredError = GetValidationError(instance, ValidationError.RequiredErrorCode);
            Assert.IsNull(requiredError);
        }
    }
}
