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
                if (result.Value == true)
                {
                    return new SuccessResponse(200, Messages.AddedSuccesfully);
                }
                else
                {
                    return HttpHelper.FailedContent("WantedController / AddProduct");
                }
            }
            catch (Exception ex)
            {
                return HttpHelper.ExceptionContent(ex);
            }
        }

        //[HttpPost]
        //[Route("RecordReceipt")]
        //public async Task<ActionResult<IResponse>> RecordReceipt([FromForm] ReceiptDto model)
        //{
        //    try
        //    {
        //        var result = await _receiptService.AddAsync(model);

        //        if (result.Value == true)
        //        {
        //            return new SuccessResponse(200, Messages.AddedSuccesfully);
        //        }
        //        else
        //        {
        //            return HttpHelper.FailedContent("WantedController/RecordReceipt");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return HttpHelper.ExceptionContent(ex);
        //    }
        //}

        //[HttpPost]
        //[Route("RecordSaleFactore")]
        //public async Task<ActionResult<IResponse>> RecordSaleFactore([FromForm] SaleFactorDto model)
        //{
        //    try
        //    {
        //        var result = await _saleFactoryService.AddAsync(model);

        //        if (result.Value == false) 
        //        {
        //            return HttpHelper.FailedContent("WantedController/RecordSaleFactore");
        //        }
        //        return new SuccessResponse(200, Messages.AddedSuccesfully);
        //    }
        //    catch (Exception ex)
        //    {
        //        return HttpHelper.ExceptionContent(ex);
        //    }
        //}


        [HttpPost]
        [Route("Receipt")]
        public async Task<ActionResult<IResponse>> Receipt(AddReceiptDto model)
        {
            try
            {
                var result = await _receiptService.AddReceiptAsync(model);

                if (result.Value == true)
                {
                    return new SuccessResponse(200, Messages.AddedSuccesfully);
                }
                else
                {
                    return HttpHelper.FailedContent("WantedController/RecordReceipt");
                }

            }
            catch (Exception ex)
            {
                return HttpHelper.ExceptionContent(ex);
            }
        }

        [HttpPost]
        [Route("SaleFactore")]
        public async Task<ActionResult<IResponse>> SaleFactore(AddSaleFactorDto model)
        {
            try
            {
                var result = await _saleFactoryService.AddSaleFactorAsync(model);

                if (result.Value == false)
                {
                    return HttpHelper.FailedContent("WantedController/SaleFactore");
                }
                return new SuccessResponse(200, Messages.AddedSuccesfully);
            }
            catch (Exception ex)
            {
                return HttpHelper.ExceptionContent(ex);
            }
        }
    }
}
