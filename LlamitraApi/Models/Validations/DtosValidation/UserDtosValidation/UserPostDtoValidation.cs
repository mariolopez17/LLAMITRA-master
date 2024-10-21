using FluentValidation;
using LlamitraApi.Models.Dtos.UserDtos;

namespace LlamitraApi.Models.Validations.DtosValidation.UserDtosValidation
{
    public class UserPostDtoValidation : AbstractValidator<UserPostDto>
    {
        public UserPostDtoValidation()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("El campo 'Name' es obligatorio.");
            RuleFor(u => u.Name).MaximumLength(50).WithMessage("El Nombre no debe exceder los 50 caracteres.");
            RuleFor(u => u.Name).Matches(@"^[a-zA-Z]+$").WithMessage("El Nombre solo debe contener letras.");

            RuleFor(v => v.LastName).NotEmpty().WithMessage("El Apellido es obligatorio.");
            RuleFor(v => v.LastName).Matches(@"^[a-zA-Z]+$").WithMessage("El apellido solo debe contener letras.");
            RuleFor(v => v.LastName).MaximumLength(50).WithMessage("El Apellido no debe exceder los 50 caracteres.");

            RuleFor(z => z.Mail).NotEmpty().WithMessage("El correo electrónico es obligatorio.");
            RuleFor(z => z.Mail).EmailAddress().WithMessage("El correo electrónico no es válido.");
            RuleFor(z => z.Mail).Length(1, 40).WithMessage("El correo electrónico debe tener entre 1 y 40 caracteres como máximo.");

            RuleFor(x => x.IdRol).NotNull().WithMessage("El número de acceso es obligatorio.");
            RuleFor(x => x.IdRol).InclusiveBetween(0, 4).WithMessage("Tu número de acceso no es de ningún usuario registrado.");

            RuleFor(y => y.Password).NotEmpty().WithMessage("La contraseña es obligatoria.");
            RuleFor(y => y.Password).Length(1, 30).WithMessage("La contraseña debe tener entre 1 y 30 caracteres como máximo.");
            RuleFor(y => y.Password).MinimumLength(8).WithMessage("El campo 'Password' debe tener al menos 8 caracteres.");
            RuleFor(y => y.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("La contraseña debe contener al menos una letra mayúscula, una minúscula, un número y un carácter especial.");
        }
    }
}