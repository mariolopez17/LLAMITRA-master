using FluentValidation;
using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Models.Validations
{
    public class PublicationPostDtoValidator : AbstractValidator<PublicationPostDto>
    {
        public PublicationPostDtoValidator()
        {
            RuleFor(c => c.Professor).NotNull();
        }
    }
}
