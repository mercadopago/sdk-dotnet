using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MercadoPago.Validation
{
    /// <summary>
    ///Class that represents the validation results. 
    /// </summary>
    public class ValidationResult
    {
        public bool IsOk => !Errors.Any();

        public List<ValidationError> Errors { get; }

        public ValidationResult(IEnumerable<ValidationError> errors) => Errors = errors.ToList();
    }

    /// <summary>
    /// Class that represents the Error contained in the ValidationResult class
    /// </summary>
    public class ValidationError
    {
        public const int OutOfRangeErrorCode = 1001;
        public const int RequiredErrorCode   = 1002;
        public const int RegExpErrorCode     = 1003;
        public const int DataTypeErrorCode   = 1004;

        public int Code { get; }
        public string Message { get; }

        internal ValidationError(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public static ValidationError OutOfRangeError(string propertyName) =>
            new ValidationError(OutOfRangeErrorCode, $"Error on property {propertyName}. The value you are trying to assign is not in the specified range. ");

        public static ValidationError RequiredError(string propertyName) =>
            new ValidationError(RequiredErrorCode, $"Error on property {propertyName}. There is no value for this required property. ");

        public static ValidationError RegExpError(string propertyName, string pattern) =>
            new ValidationError(RegExpErrorCode, $"Error on property {propertyName}. The specified value is not valid. RegExp: {pattern}.");

        public static ValidationError DataTypeError(string propertyName) =>
            new ValidationError(DataTypeErrorCode, $"Error on property {propertyName}. The value you are trying to assign has not the correct type. ");
    }

    internal static class Validator
    {
        internal static IEnumerable<ValidationError> GetValidationErrors(object instance)
        {
            var properties = instance.GetType().GetProperties();

            var instanceErrors =
                from property in properties
                from attr in property.GetCustomAttributes(typeof(ValidationAttribute), inherit: true)
                let validation = (ValidationAttribute) attr
                let propertyValue = property.GetValue(instance, BindingFlags.GetProperty, null, null, null)
                where !validation.IsValid(propertyValue)
                select GetValidationError(validation, property.Name);

            foreach (var e in instanceErrors)
                yield return e;

            var nestedErrors =
                from property in properties
                where property.PropertyType.Assembly.FullName == typeof(MPBase).Assembly.FullName
                let propertyValue = property.GetValue(instance, BindingFlags.GetProperty, null, null, null)
                where propertyValue != null
                from e in GetValidationErrors(propertyValue)
                select e;

            foreach (var e in nestedErrors)
                yield return e;
        }

        public static ValidationResult GetValidationResult<T>(T instance) where T : MPBase
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var validationErrors = GetValidationErrors(instance);

            return new ValidationResult(validationErrors);
        }

        public static void Validate<T>(T instance) where T : MPBase
        {
            var result = GetValidationResult(instance);

            if (!result.IsOk)
            {
                var errorMessage = new StringBuilder("There are errors in the object you're trying to create. Review them to continue: ");

                foreach (var e in result.Errors)
                    errorMessage.AppendLine(e.Message);

                throw new Exception(errorMessage.ToString());
            }
        }

        private static ValidationError GetValidationError(ValidationAttribute attribute, string propertyName)
        {
            switch (attribute)
            {
                case RangeAttribute _: return ValidationError.OutOfRangeError(propertyName);
                case RequiredAttribute _: return ValidationError.RequiredError(propertyName);
                case RegularExpressionAttribute a: return ValidationError.RegExpError(propertyName, a.Pattern);
                case DataTypeAttribute _: return ValidationError.DataTypeError(propertyName);
                default:
                    throw new InvalidOperationException($"Unknown Validation Attribute Type: {attribute.GetType().Name}");
            }
        }
    }
}
