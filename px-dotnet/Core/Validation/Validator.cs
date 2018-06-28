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
        public int Code { get; }
        public string Message { get; }

        public ValidationError(string message, int code = 0)
        {
            Code = code;
            Message = message;
        }
    }

    internal static class Validator
    {
        internal static IEnumerable<ValidationError> GetValidationErrors(object instance)
        {
            var properties = instance.GetType().GetProperties();

            var instanceErrors = 
                from property in properties
                from attr in property.GetCustomAttributes(typeof(ValidationAttribute), inherit: true)
                let validation = (ValidationAttribute)attr
                let propertyValue = property.GetValue(instance, BindingFlags.GetProperty, null, null, null)
                where !validation.IsValid(propertyValue)
                let errorMessage = GetErrorMessage(validation, property.Name)
                select new ValidationError(errorMessage);

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

        private static string GetErrorMessage(ValidationAttribute attribute, string propertyName)
        {
            switch (attribute)
            {
                case RangeAttribute _:
                    return $"Error on property {propertyName}. The value you are trying to assign is not in the specified range. ";
                case RequiredAttribute _:
                    return $"Error on property {propertyName}. There is no value for this required property. ";
                case RegularExpressionAttribute a:
                    return $"Error on property {propertyName}. The specified value is not valid. RegExp: {a.Pattern}.";
                case DataTypeAttribute _:
                    return $"Error on property {propertyName}. The value you are trying to assign has not the correct type. ";
                default:
                    return "";
            }
        }
    }
}
