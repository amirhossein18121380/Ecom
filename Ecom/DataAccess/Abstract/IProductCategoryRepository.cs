using Common.DataAccess;
using DataModel.Models;

namespace Ecom.DataAccess.Abstract
{
    public interface IProductCategoryRepository : IEntityRepositoryBase<ProductCategory>
    {
        Task<ProductCategory> GetByCategoryIdAsync(long categoryid);
    }
}
