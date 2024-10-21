using FluentValidation;
namespace LlamitraApi.Models.Validations
{
    public class HistorialRefreshTokenValidation : AbstractValidator<HistorialRefreshToken>
    {
        public HistorialRefreshTokenValidation()
        {
            RuleFor(h => h.IdUser).NotNull().WithMessage("El ID del usuario es obligatorio.");

            RuleFor(i => i.Token).NotEmpty().WithMessage("El token es obligatorio.");

            RuleFor(j => j.CreatedAt).NotNull().WithMessage("La fecha de creación es obligatoria.");

            RuleFor(k => k.ExpiratedAt).NotNull().WithMessage("La fecha de expiración es obligatoria.");

            RuleFor(l => l.IsActive).NotNull().WithMessage("El estado activo es obligatorio.");
        }
    }
}