using Common.DataAccess;
using DataAccess.Concrete.Context;
using DataModel.Models;
using Ecom.DataAccess.Abstract;

namespace Ecom.DataAccess.Concrete.EntityFramework
{

    public class EfCategoryRepository : EntityRepositoryBase<Category, EcomContext>, ICategoryRepository
    {
        public EfCategoryRepository(EcomContext context) : base(context)
        {
        }
    }
}
