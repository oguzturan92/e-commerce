using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;
using FluentValidation;

namespace ProjeBusiness.Validators
{
    public class BannerModelValidator : AbstractValidator<Banner>
    {
        public BannerModelValidator()
        {
            RuleFor(x => x.BannerImage)
                            .NotEmpty().WithMessage("Resim alanı boş olamaz.");
        }
    }
}