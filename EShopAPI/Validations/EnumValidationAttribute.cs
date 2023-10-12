using System.ComponentModel.DataAnnotations;

namespace EShopAPI.Validations
{
    /// <summary>
    /// Enum類型驗證
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EnumValidationAttribute : ValidationAttribute
    {
        ///<inheritdoc/>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) 
            {
                return ValidationResult.Success;
            }

            var type = value.GetType();

            if (!(type.IsEnum && Enum.IsDefined(type, value)))
            {
                return new ValidationResult(ErrorMessage ?? $"{value} is not a valid value for type {type.Name}");
            }

            return ValidationResult.Success;
        }
    }
}
