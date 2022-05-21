using Common.Utilities;
using Common.Utilities.Responses.Abstract;
using Common.Utilities.Responses.Concrete;
using Ecom.business.Abstract;
using Ecom.DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost]
        [Route("AddCategory")]
        public async Task<ActionResult<IResponse>> AddCategory(CategoryDto model)
        {
            try
            {
                var result = await _categoryService.AddAsync(model);

                if (result.Value == true)
                {
                    return new SuccessResponse(200, Messages.AddedSuccesfully);
                }
                else
                {
                    return HttpHelper.FailedContent("CategoryController/AddCategory");
                }
            }
            catch (Exception ex)
            {
                return HttpHelper.ExceptionContent(ex);
            }
        }

        [HttpPost]
        [Route("UpdateCategory")]
        public async Task<ActionResult<IResponse>> UpdateCategory(CategoryDto model)
        {
            try
            {
                var result = await _categoryService.UpdateAsync(model);

                if (result.Value == true)
                {
                    return new SuccessResponse(200, Messages.AddedSuccesfully);
                }
                else
                {
                    return HttpHelper.FailedContent("CategoryController/UpdateCategory");
                }

            }
            catch (Exception ex)
            {
                return HttpHelper.ExceptionContent(ex);
            }
        }


        [HttpPost]
        [Route("RemoveCategory/{id}")]
        public async Task<ActionResult<IResponse>> RemoveCategory(int id)
        {
            try
            {
                var result = await _categoryService.RemoveAsync(id);

                if (result.Value == true)
                {
                    return new SuccessResponse(200, Messages.AddedSuccesfully);
                }
                else
                {
                    return HttpHelper.FailedContent("CategoryController/RemoveCategory");
                }

            }
            catch (Exception ex)
            {
                return HttpHelper.ExceptionContent(ex);
            }
        }
    }
}
