using Ecom.DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.business.Abstract
{
    public interface ICategoryService
    {
        Task<ActionResult<bool>> AddAsync(CategoryDto model);
    }
}
