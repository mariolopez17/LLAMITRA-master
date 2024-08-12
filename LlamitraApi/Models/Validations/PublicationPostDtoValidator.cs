using FluentValidation;
using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Models.Validations
{
    public class PublicationPostDtoValidator : AbstractValidator<PublicationPostDto>
    {
        public PublicationPostDtoValidator()
        {
            RuleFor(c => c.Professor).NotNull();
            RuleFor(p => p.Professor).NotEmpty().WithMessage("El nombre del profesor es obligatorio.");
            RuleFor(f => f.Professor).Length(0, 20);
        }
    }
}
