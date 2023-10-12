﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EShopAPI.Validations
{
    /// <summary>
    /// Number欄位驗證
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NumberValidationAttribute : ValidationAttribute
    {
        private readonly string _invaildStr =
            "[^a-zA-Z0-9-_]";

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

            Regex regex = new Regex(_invaildStr);

            if (regex.IsMatch(str))
            {
                return new ValidationResult(ErrorMessage ?? $"Name cannot contains invalid characters : {str}");
            }

            return ValidationResult.Success;
        }
    }
}
