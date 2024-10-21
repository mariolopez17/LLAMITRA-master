using FluentValidation;
using LlamitraApi.Models.Custom;

namespace LlamitraApi.Models.Validations.CustomValidation
{
    public class AuthorizacionRequestValidation : AbstractValidator<AuthorizacionRequest>
    {
        public AuthorizacionRequestValidation()
        {
            RuleFor(a => a.NombreUsuario)
            .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
            .MaximumLength(50).WithMessage("El nombre de usuario no puede superar los 50 caracteres.");

            RuleFor(b => b.Clave)
                .NotEmpty().WithMessage("La clave es obligatoria.")
                .MinimumLength(8).WithMessage("La clave debe tener al menos 8 caracteres.")
                .Matches(@"[A-Z]").WithMessage("La clave debe contener al menos una letra mayúscula.")
                .Matches(@"[a-z]").WithMessage("La clave debe contener al menos una letra minúscula.")
                .Matches(@"\d").WithMessage("La clave debe contener al menos un número.")
                .Matches(@"[!@#$%^&*(),.?""':{}|<>]").WithMessage("La clave debe contener al menos un carácter especial.");
        }

    }
}
