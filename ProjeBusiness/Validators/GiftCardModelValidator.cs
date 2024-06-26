using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;
using FluentValidation;

namespace ProjeBusiness.Validators
{
    public class GiftCardModelValidator : AbstractValidator<GiftCard>
    {
        public GiftCardModelValidator()
        {
            // RuleFor(x => x.GiftCardTitle)
            //                 .NotEmpty().WithMessage("İsim alanı boş olamaz.");

            RuleFor(x => x.GiftCardMiktar)
                            .NotEqual(0)
                            .When(c => c.GiftCardOran < 1)
                            .WithMessage("Oran 0 olduğunda tutar 0 bırakılamaz.");

            RuleFor(x => x.GiftCardOran)
                            .NotEqual(0)
                            .When(c => c.GiftCardMiktar < 1)
                            .WithMessage("Tutar 0 olduğunda oran 0 bırakılamaz.");
        }
    }
}