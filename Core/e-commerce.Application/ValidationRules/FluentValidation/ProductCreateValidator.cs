using e_commerce.Application.Constants;
using e_commerce.Application.DTOs.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Application.ValidationRules.FluentValidation
{
    public class ProductCreateValidator: AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator()
        {
            RuleFor(x=>x.Name).MinimumLength(5).MaximumLength(150).NotEmpty().NotNull().WithMessage(Messages.ProductNameNotEmpty);
            RuleFor(x => x.Price).GreaterThan(0).WithMessage(Messages.ProductPriceGreaterThan).NotEmpty().NotNull().WithMessage(Messages.ProductPriceNotEmpty);
            RuleFor(x => x.Stock).GreaterThan(0).WithMessage(Messages.ProductStockGreaterThan).NotEmpty().NotNull().WithMessage(Messages.ProductStockNotEmpty);
        }
    }
}
