using Common.DataAccess;
using DataAccess.Concrete.Context;
using DataModel.Models;
using Ecom.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Ecom.DataAccess.Concrete.EntityFramework
{
    public class EfProductCategoryRepository : EntityRepositoryBase<ProductCategory, EcomContext>, IProductCategoryRepository
    {
        public EfProductCategoryRepository(EcomContext context) : base(context)
        {
        }

        public async Task<ProductCategory> GetByCategoryIdAsync(long categoryid)
        {
            return await _context.ProductCategories.Include(x => x.categories).FirstOrDefaultAsync(x => x.CategoryId == categoryid);
        }
    }
}
