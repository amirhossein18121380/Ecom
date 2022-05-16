using Common.DataAccess;
using DataAccess.Concrete.Context;
using DataModel.Models;
using Ecom.DataAccess.Abstract;

namespace Ecom.DataAccess.Concrete.EntityFramework
{
    public class EfProductSaleFactorRepository : EntityRepositoryBase<ProductSaleFactor, EcomContext>, IProductSaleFactorRepository
    {
        public EfProductSaleFactorRepository(EcomContext context) : base(context)
        {
        }
    }
}
