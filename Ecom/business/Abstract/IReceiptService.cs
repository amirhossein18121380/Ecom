using Common.Utilities.Responses.Abstract;
using DataModel.Dtos;
using Ecom.DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.business.Abstract
{
    public interface IReceiptService
    {
        Task<ActionResult<bool>> AddAsync(ReceiptDto model);
        Task<ActionResult<bool>> AddReceiptAsync(AddReceiptDto model);
    }
}