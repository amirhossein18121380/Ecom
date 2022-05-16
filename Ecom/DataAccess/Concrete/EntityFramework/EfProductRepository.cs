using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataModel.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductRepository : EntityRepositoryBase<Product, EcomContext>, IProductRepository
    {
        public EfProductRepository(EcomContext context) : base(context)
        {
        }
    }
}
