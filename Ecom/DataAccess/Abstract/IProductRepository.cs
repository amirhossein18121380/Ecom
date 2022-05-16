using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DataAccess;
using DataModel.Models;

namespace DataAccess.Abstract
{
    public interface IProductRepository : IEntityRepositoryBase<Product>
    {
    }
}