using AutoMapper;
using Businesses.Abstract;
using Businesses.FluentValidation;
using Common.Utilities;
using DataAccess.Abstract;
using DataModel.Models;
using Ecom.Common.Utilities;
using Ecom.DataAccess.Abstract;
using Ecom.DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Businesses.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        private IProductCategoryRepository _productCategoryRepository;
        private IMapper _mapper;
        public ProductManager(IProductRepository productRepository, IMapper mapper, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
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
                var prcat = new ProductCategory()
                {
                    CategoryId = productoptionvalue.Id,
                    ProductId = res.Id
                };
                
                var rs = await _productCategoryRepository.AddAsync(prcat);

                if (rs == null || rs.Id == 0)
                {
                    return HttpHelper.FailedContent("not updated");
                }
            }

            //return new SuccessResponse(200, Messages.AddedSuccesfully);
            return true;
        }
    }
}
