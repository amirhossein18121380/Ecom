using AutoMapper;
using Businesses.Abstract;
using Businesses.FluentValidation;
using Common.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataModel.Models;
using Ecom.Common.DataAccess;
using Ecom.Common.Utilities;
using Ecom.DataAccess.Abstract;
using Ecom.DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Businesses.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        private ITransac _transac;

        private IProductCategoryRepository _productCategoryRepository;
        private IMapper _mapper;
        public ProductManager(IProductRepository productRepository, IMapper mapper, IProductCategoryRepository productCategoryRepository, ITransac transac)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
            _transac = transac;
        }

        [ValidationAspect(typeof(AddProductValidator))]
        public async Task<ActionResult<bool>> AddAsync(AddProductDto model)
        {
            var product = _mapper.Map<Product>(model);

            byte[] gb = Guid.NewGuid().ToByteArray();
            int i = BitConverter.ToInt32(gb, 0);
            long lastunique = BitConverter.ToInt64(gb, 0);

            product.Name = model.Name;
            product.Price = model.Price;
            product.Code = lastunique;
            product.Description = model.Description;
            product.Createon = DateTime.Now;


            var res = await _productRepository.AddAsync(product);

            foreach (var productoptionvalue in model.Categories)
            {
                try
                {
                    _transac.BeginTransaction();
                    var prcat = new ProductCategory()
                    {
                        CategoryId = productoptionvalue.Id,
                        ProductId = res.Id
                    };

                    var rs = await _productCategoryRepository.AddAsync(prcat);

                    _transac.CommitTransaction();

                    if (rs == null || rs.Id == 0)
                    {
                        _transac.TransactionRoleBack();
                        return HttpHelper.FailedContent("not updated");
                    }
                }
                finally
                {
                    _transac.Dispose();
                }
            }

            //return new SuccessResponse(200, Messages.AddedSuccesfully);
            return true;
        }
    }
}
