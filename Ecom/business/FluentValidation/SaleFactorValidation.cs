using Businesses.FluentValidation;
using DataModel.Dtos;
using DataModel.Models;
using FluentValidation;

namespace Ecom.business.FluentValidation
{

    public class SaleFactorSaleFactorDtoValidation : AbstractValidator<SaleFactorDto>
    {
        public SaleFactorSaleFactorDtoValidation()
        {
            RuleForEach(x => x.ProductIds).NotEmpty();////we can do more
        }
    }

    public class SaleFactorValidation : AbstractValidator<SaleFactor>
    {
        public SaleFactorValidation()
        {
            RuleFor(x => x.TotalCost).NotEmpty();
            RuleFor(x => x.ReceiptDate).NotEmpty();
            RuleFor(x => x.ReceiptNumber).NotEmpty();
        }
    }
}
