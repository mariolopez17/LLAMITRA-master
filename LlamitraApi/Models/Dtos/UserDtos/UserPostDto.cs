using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace LlamitraApi.Models.Dtos.UserDtos
{
    public class UserPostDto
    {
        [Required(ErrorMessage = "El nombre del usuario es obligatorio.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 20 caracteres.")]
        [NoNumbers(ErrorMessage = "El nombre no puede contener números.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "El Apellido del usuario es obligatorio.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El Apellido debe tener entre 1 y 20 caracteres.")]
        [NoNumbers(ErrorMessage = "El Apellido no puede contener números.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "El correo electronico es requerido.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string? Mail { get; set; }
        [Required(ErrorMessage = "El idRol es obligatorio.")]
        [NoLetters(ErrorMessage = "El idRol no puede contener letras.")]
        //[StringLength(20, MinimumLength = 1, ErrorMessage = "El Apellido debe tener entre 1 y 20 caracteres.")]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio.")]
        [PasswordValidation]
        public string? Password { get; set; }
    }

    public class PasswordValidationAttribute : ValidationAttribute
    {
        public PasswordValidationAttribute()
        {
            ErrorMessage = "La contraseña debe tener al menos 8 caracteres, incluyendo una letra mayúscula, una letra minúscula, un número y un carácter especial.";
        }

        public override bool IsValid(object? value)
        {
            if (value is null) return true;

            if (value is not string Password) return false;

            var hasMinimumLength = new Regex(@".{8,}");
            var hasUpperCaseLetter = new Regex(@"[A-Z]");
            var hasLowerCaseLetter = new Regex(@"[a-z]");
            var hasDigit = new Regex(@"\d");
            var hasSpecialCharacter = new Regex(@"[!@#$%^&*(),.?""':{}|<>]");

            var isValid = hasMinimumLength.IsMatch(Password) &&
                          hasUpperCaseLetter.IsMatch(Password) &&
                          hasLowerCaseLetter.IsMatch(Password) &&
                          hasDigit.IsMatch(Password) &&
                          hasSpecialCharacter.IsMatch(Password);

            return isValid;
        }
    }
    public class NoNumbersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString() ?? string.Empty;
                if (stringValue.Any(char.IsDigit))
                {
                    return new ValidationResult("El campo no puede contener números.");
                }
            }
            return ValidationResult.Success!;
        }
    }
    public class NoLettersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString() ?? string.Empty;
                if (stringValue.Any(char.IsLetter))
                {
                    return new ValidationResult(ErrorMessage ?? "El campo no puede contener letras.");
                }
            }
            return ValidationResult.Success!;
        }
    }
}