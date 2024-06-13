using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
namespace LlamitraApi.Models.Dtos.UserDtos
{
    public class UserPostDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\@]+$", ErrorMessage = "El Nombre solo debe contener letras.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El Nombre debe tener entre 1 y 20 caracteres como maximo.")]
        [JsonPropertyName("nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El Apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\@]+$", ErrorMessage = "El apellido solo debe contener letras.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El Apellido debe tener entre 1 y 20 caracteres como maximo.")]
        [JsonPropertyName("apellido")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El correo electronico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "El mail debe tener entre 1 y 40 caracteres como maximo.")]
        [JsonPropertyName("mail")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "El numero de acceso es obligatorio.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El numero de acceso solo debe contener números.")]
        [JsonPropertyName("numero_de_acceso")]
        [Range(0,4, ErrorMessage = "Tu numero de acceso no es de ningun usuario registrado")]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "El mail debe tener entre 1 y 30 caracteres como maximo.")]
        [PasswordValidation]
        [JsonPropertyName("contraseña")]
        public string Password { get; set; }
    }

    public class PasswordValidationAttribute : ValidationAttribute
    {
        public PasswordValidationAttribute()
        {
            ErrorMessage = "La contraseña debe tener al menos 8 caracteres, incluyendo una letra mayúscula, una letra minúscula, un número y un carácter especial.";
        }

        public override bool IsValid(object value)
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
}