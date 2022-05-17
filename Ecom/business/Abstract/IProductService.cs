using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utilities.Responses.Abstract;
using DataModel.Dtos;
using Ecom.DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Businesses.Abstract
{
    public interface IProductService
    {
        Task<ActionResult<bool>> AddAsync(AddProductDto model);
    }
}
