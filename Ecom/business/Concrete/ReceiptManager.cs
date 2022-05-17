using AutoMapper;
using Common.Utilities;
using Common.Utilities.Responses.Abstract;
using Common.Utilities.Responses.Concrete;
using DataAccess.Abstract;
using DataModel.Dtos;
using DataModel.Models;
using Ecom.business.Abstract;
using Ecom.business.FluentValidation;
using Ecom.Common.Utilities;
using Ecom.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.business.Concrete
{

    public class ReceiptManager : IReceiptService
    {
        private IProductRepository _productRepository;
        private IRecriptRepository _recriptRepository;
        private IProductReceiptRepository _productReceiptRepository;
        private IMapper _mapper;
        public ReceiptManager(IRecriptRepository recriptRepository, IMapper mapper, IProductReceiptRepository productReceiptRepository, IProductRepository productRepository)
        {
            _recriptRepository = recriptRepository;
            _mapper = mapper;
            _productReceiptRepository = productReceiptRepository;
            _productRepository = productRepository;
        }

        [ValidationAspect(typeof(ReceipDtoValidation))]
        public async Task<ActionResult<bool>> AddAsync(ReceiptDto model)
        {
            var receipt = _mapper.Map<Receipt>(model);

            decimal totalCost = 0;

            foreach (var item in model.ProductsIds)
            {
                var ans = await _productRepository.GetByIdAsync(item);
                totalCost += ans.Price;
            }

            byte[] gb = Guid.NewGuid().ToByteArray();
            int i = BitConverter.ToInt32(gb, 0);
            long lastunique = BitConverter.ToInt64(gb, 0);

            receipt.TotalCost = totalCost;
            receipt.ReceiptNumber = lastunique;
            receipt.ReceiptDate = DateTime.Now;

            var res = await _recriptRepository.AddAsync(receipt);

            if (res == null)
            {
                //return new ErrorResponse(400, "something bad happened");
                return HttpHelper.FailedContent("something bad happened");
            }


            foreach (var productid in model.ProductsIds)
            {
                var resriv = new ProductReceipt()
                {
                    ReceiptId = res.Id,
                    ProductId = productid
                };

                var rs = await _productReceiptRepository.AddAsync(resriv);

                if (rs == null || rs.Id == 0)
                {
                    return HttpHelper.FailedContent("something wrong with productReceiptRepository");
                    ///some extra logging things.......
                }
            }
            return true;
        }
    }
}
