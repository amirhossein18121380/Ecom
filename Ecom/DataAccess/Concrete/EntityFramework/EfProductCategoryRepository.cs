using Common.DataAccess;
using DataAccess.Concrete.Context;
using DataModel.Models;
using Ecom.DataAccess.Abstract;

namespace Ecom.DataAccess.Concrete.EntityFramework
{
    public class EfProductCategoryRepository : EntityRepositoryBase<ProductCategory, EcomContext>, IProductCategoryRepository
    {
        public EfProductCategoryRepository(EcomContext context) : base(context)
        {
        }
    }
}
