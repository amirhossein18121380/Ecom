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

        public WantedController(IProductService productService, IReceiptService receiptService, ISaleFactoryService saleFactoryService)
        {
            _productService = productService;
            _receiptService = receiptService;
            _saleFactoryService = saleFactoryService;
        }


        [HttpPost]
        [Route("AddProduct")]
        public async Task<IResponse> AddProduct([FromForm] AddProductDto model)
        {
            var result = await _productService.AddAsync(model);
            if (result.Success)
            {
                return new SuccessResponse(200, Messages.AddedSuccesfully);
            }
            else
            {
                return new ErrorResponse("WantedController/AddProduct");
            }
        }

        [HttpPost]
        [Route("RecordReceipt")]
        public async Task<IResponse> RecordReceipt([FromForm] ReceiptDto model)
        {
            var result =  await _receiptService.AddAsync(model);

            if (result.Success)
            {
                return new SuccessResponse(200, Messages.AddedSuccesfully);
            }
            else
            {
                return new ErrorResponse("WantedController/RecordReceipt");
            }
        }

        [HttpPost]
        [Route("RecordSaleFactore")]
        public async Task<IResponse> RecordSaleFactore([FromForm] SaleFactorDto model)
        {
            var result = await _saleFactoryService.AddAsync(model);
            if (result.Success)
            {
                return new SuccessResponse(200, Messages.AddedSuccesfully);
            }
            else
            {
                return new ErrorResponse("WantedController/RecordSaleFactore");
            }
        }
    }
}
