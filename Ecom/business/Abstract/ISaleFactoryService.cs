using DataModel.Dtos;
using Ecom.DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.business.Abstract
{
    public interface ISaleFactoryService
    {
        Task<ActionResult<bool>> AddAsync(SaleFactorDto model);
        Task<ActionResult<bool>> AddSaleFactorAsync(AddSaleFactorDto model);
    }
}
