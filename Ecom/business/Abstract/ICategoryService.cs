using Ecom.DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.business.Abstract
{
    public interface ICategoryService
    {
        Task<ActionResult<bool>> AddAsync(CategoryDto model);
        Task<ActionResult<bool>> UpdateAsync(CategoryDto model);
        Task<ActionResult<bool>> RemoveAsync(int id);
    }
}
