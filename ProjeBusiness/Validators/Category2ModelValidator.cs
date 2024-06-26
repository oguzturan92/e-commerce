using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;
using FluentValidation;

namespace ProjeBusiness.Validators
{
    public class Category2ModelValidator : AbstractValidator<Category2>
    {
        public Category2ModelValidator()
        {
            RuleFor(x => x.Category2Name)
                            .NotEmpty().WithMessage("İsim alanı boş olamaz.");

            RuleFor(x => x.Category2Url)
                            .NotEmpty().WithMessage("İsim alanı boş olamaz.");

            RuleFor(x => x.Category2ListType)
                            .NotEqual("Urun")
                            .When(c => c.Category2Visibility == "Link")
                            .WithMessage("'Sadece Link İle Ulaşılsın' seçildiğinde, Listeleme Tipi olarak 'İçerik' seçilebilir.");
        }
    }
}