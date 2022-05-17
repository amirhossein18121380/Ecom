using Businesses.Abstract;
using Common.Utilities;
using Common.Utilities.Responses.Abstract;
using Common.Utilities.Responses.Concrete;
using DataModel.Dtos;
using Ecom.business.Abstract;
using Ecom.DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WantedController : ControllerBase
    {
        private IProductService _productService;
        private IReceiptService _receiptService;
        private ISaleFactoryService _saleFactoryService;
        private ICategoryService _categoryService;

        public WantedController(IProductService productService, IReceiptService receiptService, ISaleFactoryService saleFactoryService, ICategoryService categoryService)
        {
            _productService = productService;
            _receiptService = receiptService;
            _saleFactoryService = saleFactoryService;
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<IResponse>> AddProduct([FromForm] AddProductDto model)
        {
            try
            {
                var result = await _productService.AddAsync(model);
                if (result != null)
                {
                    return new SuccessResponse(200, Messages.AddedSuccesfully);
                }
                else
                {
                    //return new ErrorResponse("WantedController/AddProduct");
                    return HttpHelper.FailedContent("WantedController / AddProduct");
                }
            }
            catch (Exception ex)
            {
                return HttpHelper.ExceptionContent(ex);
            }
        }


        [HttpPost]
        [Route("RecordReceipt")]
        public async Task<ActionResult<IResponse>> RecordReceipt([FromForm] ReceiptDto model)
        {
            try
            {
                var result = await _receiptService.AddAsync(model);

                if (result != null)
                {
                    return new SuccessResponse(200, Messages.AddedSuccesfully);
                }
                else
                {
                    //return new ErrorResponse("WantedController/RecordReceipt");
                    return HttpHelper.FailedContent("WantedController/RecordReceipt");
                }

            }
            catch (Exception ex)
            {
                return HttpHelper.ExceptionContent(ex);
            }
        }

        [HttpPost]
        [Route("RecordSaleFactore")]
        public async Task<ActionResult<IResponse>> RecordSaleFactore([FromForm] SaleFactorDto model)
        {
            try
            {
                var result = await _saleFactoryService.AddAsync(model);

                if (result != null)
                {
                    return new SuccessResponse(200, Messages.AddedSuccesfully);
                }
                else
                {
                    //return new ErrorResponse("WantedController/RecordSaleFactore");
                    return HttpHelper.FailedContent("WantedController/RecordSaleFactore");
                }
            }
            catch (Exception ex)
            {
                return HttpHelper.ExceptionContent(ex);
            }
        }


        [HttpPost]
        [Route("AddCategory")]
        public async Task<ActionResult<IResponse>> AddCategory(CategoryDto model)
        {

            try
            {
                var result = await _categoryService.AddAsync(model);

                if (result != null)
                {
                    return new SuccessResponse(200, Messages.AddedSuccesfully);
                }
                else
                {
                    //return new ErrorResponse("WantedController/RecordSaleFactore");
                    return HttpHelper.FailedContent("WantedController/RecordSaleFactore");
                }
            }
            catch (Exception ex)
            {
                return HttpHelper.ExceptionContent(ex);
            }
        }
    }
}
