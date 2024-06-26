using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjeEntity.Concrete;
using FluentValidation;

namespace ProjeBusiness.Validators
{
    public class ProductModelValidator : AbstractValidator<Product>
    {
        public ProductModelValidator()
        {
            RuleFor(x => x.ProductName)
                            .NotEmpty().WithMessage("İsim alanı boş olamaz.");

            RuleFor(x => x.ProductUrl)
                            .NotEmpty().WithMessage("Url alanı boş olamaz.");

            RuleFor(x => x.ProductShortName)
                            .NotEmpty().WithMessage("Özet alanı boş olamaz.");

            RuleFor(x => x.ProductImage)
                            .NotEmpty().WithMessage("Resim alanı boş olamaz.");

            RuleFor(x => x.ProductPrice)
                            .NotEmpty()
                            .GreaterThan(0).WithMessage("Fiyat, 0'dan büyük olmalıdır.");
        }
    }
}