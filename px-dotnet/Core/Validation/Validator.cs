using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using static MercadoPago.Validation.ValidationError;

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
        public const int OutOfRangeErrorCode   = 1001;
        public const int RequiredErrorCode     = 1002;
        public const int RegExpErrorCode       = 1003;
        public const int DataTypeErrorCode     = 1004;
        public const int StringLengthErrorCode = 1005;

        public int Code { get; }
        public string Message { get; }

        internal ValidationError(int code, string message)
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
                let validation = (ValidationAttribute) attr
                let propertyValue = property.GetValue(instance, BindingFlags.GetProperty, null, null, null)
                where !validation.IsValid(propertyValue)
                select GetValidationError(validation, property.Name);

            foreach (var e in instanceErrors)
                yield return e;

            if (instance is IEnumerable list)
            {
                var itemErrors =
                    from object item in list
                    from e in GetValidationErrors(item)
                    select e;

                foreach (var e in itemErrors)
                    yield return e;
            }
            else
            {
                var nestedErrors =
                    from property in properties
                    where property.PropertyType.IsSdkType()
                    let propertyValue = property.GetValue(instance, BindingFlags.GetProperty, null, null, null)
                    where propertyValue != null
                    from e in GetValidationErrors(propertyValue)
                    select e;

                foreach (var e in nestedErrors)
                    yield return e;
            }
        }

        public static ValidationResult GetValidationResult<T>(T instance) where T : ResourceBase
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var validationErrors = GetValidationErrors(instance);

            return new ValidationResult(validationErrors);
        }

        public static void Validate<T>(T instance) where T : ResourceBase
        {
            var result = GetValidationResult(instance);

            if (!result.IsOk)
            {
                var errorMessage = new StringBuilder($"There are errors in the object you're trying to create. Review them to continue: {Environment.NewLine}");

                foreach (var e in result.Errors)
                    errorMessage.AppendLine($" - {e.Message}{Environment.NewLine}");

                throw new Exception(errorMessage.ToString());
            }
        }

        private static ValidationError GetValidationError(ValidationAttribute attribute, string propertyName)
        {
            var msg = $"Error on property {propertyName}";

            switch (attribute)
            {
                case RangeAttribute r:
                    return new ValidationError(OutOfRangeErrorCode, $"{msg}. The value you are trying to assign is not in the specified range: {r.Minimum}-{r.Maximum}.");
                case RequiredAttribute _:
                    return new ValidationError(RequiredErrorCode, $"{msg}. There is no value for this required property.");
                case RegularExpressionAttribute a:
                    return new ValidationError(RegExpErrorCode, $"{msg}. The specified value is not valid. RegExp: {a.Pattern}.");
                case DataTypeAttribute _:
                    return new ValidationError(DataTypeErrorCode, $"{msg}. The value you are trying to assign has not the correct type.");
                case StringLengthAttribute _:
                    return new ValidationError(StringLengthErrorCode, $"{msg}. The length of the string exceeds the maximum allowed length.");
                default:
                    throw new InvalidOperationException($"Unknown Validation Attribute Type: {attribute.GetType().Name}");
            }
        }

        private static bool IsSdkType(this Type type) =>
            type.Assembly.FullName == typeof(ResourceBase).Assembly.FullName ||
            type.IsGenericType && type.GetGenericArguments().Any(IsSdkType);
    }
}
