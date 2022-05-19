using AutoMapper;
using Common.Utilities;
using Common.Utilities.Responses.Abstract;
using Common.Utilities.Responses.Concrete;
using DataAccess.Abstract;
using DataModel.Dtos;
using DataModel.Models;
using Ecom.business.Abstract;
using Ecom.business.FluentValidation;
using Ecom.Common.DataAccess;
using Ecom.Common.Utilities;
using Ecom.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.business.Concrete
{
    public class SaleFactoryManager : ISaleFactoryService
    {
        private IProductRepository _productRepository;
        private ISaleFactorRepository _saleFactorRepository;
        private IProductSaleFactorRepository _productSaleFactorRepository;
        private IMapper _mapper;
        private ITransac _transac;
        public SaleFactoryManager(ISaleFactorRepository saleFactorRepository, IMapper mapper, IProductSaleFactorRepository productSaleFactorRepository,
            IProductRepository productRepository, ITransac transac)
        {
            _saleFactorRepository = saleFactorRepository;
            _mapper = mapper;
            _productSaleFactorRepository = productSaleFactorRepository;
            _productRepository = productRepository;
            _transac = transac;
        }

        [ValidationAspect(typeof(SaleFactorSaleFactorDtoValidation))]
        public async Task<ActionResult<bool>> AddAsync(SaleFactorDto model)
        {
            var saleFactor = _mapper.Map<SaleFactor>(model);

            decimal totalCost = 0;

            foreach (var item in model.ProductIds)
            {
                var ans = await _productRepository.GetByIdAsync(item);
                totalCost += ans.Price;
            }

            byte[] gb = Guid.NewGuid().ToByteArray();
            int i = BitConverter.ToInt32(gb, 0);
            long lastunique = BitConverter.ToInt64(gb, 0);

            saleFactor.TotalCost = totalCost;
            saleFactor.ReceiptNumber = lastunique;
            saleFactor.ReceiptDate = DateTime.Now;

            var res = await _saleFactorRepository.AddAsync(saleFactor);

            if (res == null)
            {
                return HttpHelper.FailedContent("something bad happened");
            }

            foreach (var productId in model.ProductIds)
            {
                try
                {
                    _transac.BeginTransaction();
                    var factor = new ProductSaleFactor() { SaleFactorId = res.Id, ProductId = productId };

                    var rs = await _productSaleFactorRepository.AddAsync(factor);

                    _transac.CommitTransaction();
                    if (rs == null || rs.Id == 0)
                    {
                        _transac.TransactionRoleBack();
                        return HttpHelper.FailedContent("something wrong with productReceiptRepository");
                        ///some extra logging things.......
                    }
                }
                finally
                {
                    _transac.Dispose();
                }
            }

            return true;
        }
    }
}
