using FluentValidation;
using LlamitraApi.Models.Custom;

namespace LlamitraApi.Models.Validations.CustomValidation
{
    public class RefreshTokenRequestValidation : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenRequestValidation()
        {
            RuleFor(r => r.RefreshToken)
             .NotEmpty().WithMessage("debes colocar el nuevo token");
        }
    }
}