using Common.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataModel.Models;
using Ecom.DataAccess.Abstract;

namespace Ecom.DataAccess.Concrete.EntityFramework
{
   

    public class EFProductReceiptRepository : EntityRepositoryBase<ProductReceipt, EcomContext>, IProductReceiptRepository
    {
        public EFProductReceiptRepository(EcomContext context) : base(context)
        {
        }
    }
}
