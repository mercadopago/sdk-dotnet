using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MercadoPago;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Validation;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Validations
{
    [TestFixture]
    public class ValidationTest : ResourceBase
    {
        [RegularExpression(@"^(?:.*[a-z]){7,}$")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Range(5.0, 10.0)]
        public double TransactionAmount { get; set; }

        public ValidationTest() { }

        public ValidationTest(string name, string description, double transationAmount)
        {
            Name = name;
            Description = description;
            TransactionAmount = transationAmount;
        }

        private ValidationError GetValidationError(object instance, int errorCode) =>
            Validator.GetValidationErrors(instance)
                     .FirstOrDefault(x => x.Code == errorCode);

        [Test]
        public void Validator_TestOutOfRangeValidation()
        {
            var instance = new ValidationTest("abcdefghijklm", "description", 1.0);
            var error = GetValidationError(instance, ValidationError.OutOfRangeErrorCode);
            Assert.IsNotNull(error);
            
            instance.TransactionAmount = 20.0;
            error = GetValidationError(instance, ValidationError.OutOfRangeErrorCode);
            Assert.IsNotNull(error);

            instance.TransactionAmount = 8.75;
            error = GetValidationError(instance, ValidationError.OutOfRangeErrorCode);
            Assert.IsNull(error);
        }

        [Test]
        public void Validator_TestRequiredFieldValidation()
        {
            var instance = new ValidationTest("abcdefghijklm", null, 8.0);

            var error = GetValidationError(instance, ValidationError.RequiredErrorCode);
            Assert.IsNotNull(error);

            instance.Description = string.Empty;
            error = GetValidationError(instance, ValidationError.RequiredErrorCode);
            Assert.IsNotNull(error);

            instance.Description = "Some Description";
            error = GetValidationError(instance, ValidationError.RequiredErrorCode);
            Assert.IsNull(error);
        }

        [Test]
        public void Validator_TestRegExpValidation()
        {
            var instance = new ValidationTest("xxx", "description", 8.0);

            var error = GetValidationError(instance, ValidationError.RegExpErrorCode);
            Assert.IsNotNull(error);

            instance.Name = "Satisfy RegExp";
            error = GetValidationError(instance, ValidationError.RegExpErrorCode);
            Assert.IsNull(error);
        }

        [Test]
        public void Validator_TestDataTypeValidation()
        {
            Assert.Warn("La validación del DataTypeAttribute no está implementada. DataTypeAttribute.IsValid() siempre devuelve true.");
        }

        [Test]
        public void Validator_TestStringLengthValidation()
        {
            var instance = new ValidationTest("abcdefghijklm", new string('x', 25), 8.0);

            var error = GetValidationError(instance, ValidationError.StringLengthErrorCode);
            Assert.IsNotNull(error);

            instance.Description = "short string";
            error = GetValidationError(instance, ValidationError.StringLengthErrorCode);
            Assert.IsNull(error);
        }
    }
}
