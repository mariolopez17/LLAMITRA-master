using FluentValidation;
using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Models.Validations.DtosValidation.CourseDtosValidation
{
    public class PublicationPostDtoValidator : AbstractValidator<PublicationPostDto>
    {
        public PublicationPostDtoValidator()
        {
            RuleFor(c => c.Professor).NotEmpty().WithMessage("El nombre del profesores obligatorio ");
            RuleFor(c => c.Professor).MaximumLength(20).WithMessage("El nombre del profesor no puede superar los 20 caracteres.");
            RuleFor(c => c.Professor).Matches(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$").WithMessage("El nombre del profesor solo debe contener letras.");


            RuleFor(r => r.Price).NotNull().WithMessage("El precio es obligatorio, aunque sea 0.");
            RuleFor(r => r.Price).GreaterThanOrEqualTo(0).WithMessage("El precio debe ser un valor positivo.");
            RuleFor(r => r.Price).Custom((price, context) =>
            {
                if (decimal.Round(price, 2) != price)
                {
                    context.AddFailure("El precio solo debe contener números y no acepta más de 2 cifras decimales.");
                }
            });

            RuleFor(s => s.Title).NotEmpty().WithMessage("El Titulo es obligatorio");
            RuleFor(s => s.Title).MaximumLength(50).WithMessage("El título no puede superar los 50 caracteres ");

            RuleFor(a => a.Description).NotEmpty().WithMessage("La descripción es obligatoria ");
            RuleFor(a => a.Description).MaximumLength(400).WithMessage("La descripción no puede superar los 400 caracteres");
        }
    }
}