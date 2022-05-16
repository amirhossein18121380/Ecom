using DataModel.Dtos;
using DataModel.Models;
using FluentValidation;

namespace Ecom.business.FluentValidation
{

    public class ReceipValidation : AbstractValidator<Receipt>
    {
        public ReceipValidation()
        {
            RuleFor(x => x.TotalCost).NotEmpty();
            RuleFor(x => x.ReceiptNumber).NotEmpty();
            RuleFor(x => x.ReceiptDate).NotEmpty();
        }
    }

    public class ReceipDtoValidation : AbstractValidator<ReceiptDto>
    {
        public ReceipDtoValidation()
        {
            RuleForEach(x => x.ProductsIds).NotEmpty();////we can do more
        }
    }
}
