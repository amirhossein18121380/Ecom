using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utilities.Responses.Abstract;
using DataModel.Dtos;
using Ecom.DataModel.Dtos;

namespace Businesses.Abstract
{
    public interface IProductService
    {
        Task<IResponse> AddAsync(AddProductDto model);
    }
}
