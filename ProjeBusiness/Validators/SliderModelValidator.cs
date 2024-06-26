using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;
using FluentValidation;

namespace ProjeBusiness.Validators
{
    public class SliderModelValidator : AbstractValidator<Slider>
    {
        public SliderModelValidator()
        {
            RuleFor(x => x.SliderImage)
                            .NotEmpty().WithMessage("Bu alan boş olamaz.");
        }
    }
}