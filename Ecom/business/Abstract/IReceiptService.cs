using Common.Utilities.Responses.Abstract;
using DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.business.Abstract
{
    public interface IReceiptService
    {
        Task<ActionResult<bool>> AddAsync(ReceiptDto model);
    }
}