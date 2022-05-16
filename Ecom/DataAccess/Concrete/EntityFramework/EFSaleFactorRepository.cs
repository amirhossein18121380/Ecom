using Common.DataAccess;
using DataAccess.Concrete.Context;
using DataModel.Models;
using Ecom.DataAccess.Abstract;

namespace Ecom.DataAccess.Concrete.EntityFramework
{
    public class EFSaleFactorRepository : EntityRepositoryBase<SaleFactor, EcomContext>, ISaleFactorRepository
    {
        public EFSaleFactorRepository(EcomContext context) : base(context)
        {
        }
    }
}
