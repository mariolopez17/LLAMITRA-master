using FluentValidation;
using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Models.Validations.DtosValidation.CourseDtosValidation

{
    public class EmailDtoValidation : AbstractValidator<EmailDTO>
    {
        public EmailDtoValidation()
        {

            RuleFor(e => e.Para).NotEmpty().WithMessage("El campo 'Para' es obligatorio.");
            RuleFor(e => e.Para).EmailAddress().WithMessage("El campo 'Para' debe ser un correo electrónico válido.");

            RuleFor(d => d.Asunto).NotEmpty().WithMessage("El campo 'Asunto' es obligatorio.");
            RuleFor(d => d.Asunto).MaximumLength(100).WithMessage("El campo 'Asunto' no debe exceder los 100 caracteres.");

            RuleFor(f => f.Contenido).NotEmpty().WithMessage("El campo 'Contenido' es obligatorio.");
            RuleFor(f => f.Contenido).MaximumLength(1000).WithMessage("El campo 'Contenido' no debe exceder los 1000 caracteres.");
        }

    }
}
