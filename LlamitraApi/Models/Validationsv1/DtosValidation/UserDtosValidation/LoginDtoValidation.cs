using FluentValidation;
using LlamitraApi.Models.Dtos.UserDtos;

namespace LlamitraApi.Models.Validations.DtosValidation.UserDtosValidation
{
    public class LoginDtoValidation : AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
            RuleFor(l => l.Mail).NotEmpty().WithMessage("El campo 'Mail' es obligatorio.");
            RuleFor(l => l.Mail).EmailAddress().WithMessage("El campo 'Mail' debe ser un correo electrónico válido.");

            RuleFor(m => m.Password).NotEmpty().WithMessage("El campo 'Password' es obligatorio.");
            RuleFor(m => m.Password).MinimumLength(8).WithMessage("El campo 'Password' debe tener al menos 8 caracteres.");
            RuleFor(m => m.Password).MaximumLength(20).WithMessage("El campo 'Password' no debe exceder los 20 caracteres.");
            RuleFor(m => m.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("El campo 'Password' debe contener al menos una letra mayúscula, una minúscula, un número y un carácter especial.");
        }
    }
}