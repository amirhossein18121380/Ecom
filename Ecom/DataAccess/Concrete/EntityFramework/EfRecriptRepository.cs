using Common.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataModel.Models;
using Ecom.DataAccess.Abstract;

namespace Ecom.DataAccess.Concrete.EntityFramework
{
    public class EfRecriptRepository : EntityRepositoryBase<Receipt, EcomContext>, IRecriptRepository
    {
        public EfRecriptRepository(EcomContext context) : base(context)
        {
        }
    }
}
