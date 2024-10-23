using FluentValidation;
using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Models.Validations.DtosValidation.CourseDtosValidation
{
    public class PublicationTypePostDtoValidation : AbstractValidator<PublicationTypePostDto>
    {
        public PublicationTypePostDtoValidation()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("El nombre es obligatorio ");
            RuleFor(a => a.Name).Matches(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$").WithMessage("El nombre del solo debe contener letras.");
            RuleFor(a => a.Name).MaximumLength(20).MinimumLength(1).WithMessage("El Nombre debe tener entre 1 y 20 caracteres como maximo.");
        }
    }
}
