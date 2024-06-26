using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;
using FluentValidation;

namespace ProjeBusiness.Validators
{
    public class CategoryModelValidator : AbstractValidator<Category>
    {
        public CategoryModelValidator()
        {
            RuleFor(x => x.CategoryName)
                            .NotEmpty().WithMessage("İsim alanı boş olamaz.");

            RuleFor(x => x.CategoryUrl)
                            .NotEmpty().WithMessage("İsim alanı boş olamaz.");

            RuleFor(x => x.CategoryListType)
                            .NotEqual("Urun")
                            .When(c => c.CategoryVisibility == "Link")
                            .WithMessage("'Sadece Link İle Ulaşılsın' seçildiğinde, Listeleme Tipi olarak 'İçerik' seçilebilir.");
        }
    }
}