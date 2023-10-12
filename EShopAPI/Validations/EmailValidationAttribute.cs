using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EShopAPI.Validations
{
    /// <summary>
    /// Email欄位驗證屬性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EmailValidationAttribute : ValidationAttribute
    {
        private readonly string _validStr =
            "^[a-zA-Z0-9-.]+@([a-zA-Z0-9-]+\\.)[a-z-A-Z0-9]{2,4}$";

        ///<inheritdoc/>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string)
            {
                return new ValidationResult(ErrorMessage ?? $"{value} is not a string");
            }

            if (string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(ErrorMessage ?? $"name cannot be null and empty string");
            }

            string str = value.ToString()!;

            Regex regex = new Regex(_validStr, RegexOptions.None, TimeSpan.FromMilliseconds(100)); 

            if (!regex.IsMatch(str))
            {
                return new ValidationResult(ErrorMessage ?? $"Name cannot contains invalid characters : {str}");
            }

            return ValidationResult.Success;
        }
    }
}
