using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;
using FluentValidation;

namespace ProjeBusiness.Validators
{
    public class Category3ModelValidator : AbstractValidator<Category3>
    {
        public Category3ModelValidator()
        {
            RuleFor(x => x.Category3Name)
                            .NotEmpty().WithMessage("İsim alanı boş olamaz.");

            RuleFor(x => x.Category3Url)
                            .NotEmpty().WithMessage("İsim alanı boş olamaz.");
        }
    }
}