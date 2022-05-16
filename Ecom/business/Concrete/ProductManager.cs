using AutoMapper;
using Businesses.Abstract;
using Businesses.FluentValidation;
using Common.Utilities;
using Common.Utilities.Responses.Abstract;
using Common.Utilities.Responses.Concrete;
using DataAccess.Abstract;
using DataModel.Models;
using Ecom.Common.Utilities;
using Ecom.DataAccess.Abstract;
using Ecom.DataModel.Dtos;

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
        public async Task<IResponse> AddAsync(AddProductDto model)
        {
            var product = _mapper.Map<Product>(model);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Code = Guid.NewGuid(); 
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

                if (rs != null || rs.Id == 0)
                {
                    return null;
                    ///some extra logging things.......
                }
            }

            return new SuccessResponse(200, Messages.AddedSuccesfully);
        }
    }
}
