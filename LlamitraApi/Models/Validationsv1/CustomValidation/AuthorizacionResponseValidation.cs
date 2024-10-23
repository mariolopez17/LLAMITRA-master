using FluentValidation;
using LlamitraApi.Models.Custom;

namespace LlamitraApi.Models.Validations.CustomValidation
{
    public class AuthorizacionResponseValidation : AbstractValidator<AuthorizacionResponse>
    {
        public AuthorizacionResponseValidation()
        {
            RuleFor(r => r.Token).NotEmpty().WithMessage("El token es obligatorio.");
        }
    }
}
