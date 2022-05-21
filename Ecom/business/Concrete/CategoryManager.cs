using AutoMapper;
using Businesses.FluentValidation;
using Common.Utilities;
using DataAccess.Abstract;
using DataModel.Models;
using Ecom.business.Abstract;
using Ecom.Common.DataAccess;
using Ecom.Common.Utilities;
using Ecom.DataAccess.Abstract;
using Ecom.DataModel.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.business.Concrete
{

    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IProductCategoryRepository _productCategoryRepository;
        private IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, IProductCategoryRepository productCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _productCategoryRepository= productCategoryRepository;
        }

        [ValidationAspect(typeof(AddProductValidator))]
        public async Task<ActionResult<bool>> AddAsync(CategoryDto model)
        {
            var product = _mapper.Map<Category>(model);


            product.ParentId = model.ParentId;
            product.Title = model.Title;
            product.Createon = DateTime.Now;

            var res = await _categoryRepository.AddAsync(product);

            if (res == null)
            {
                return HttpHelper.FailedContent("category not added");
            }
    
            return true;
        }

        public async Task<ActionResult<bool>> UpdateAsync(CategoryDto model)
        {
            var product = _mapper.Map<Category>(model);

            var res = await _categoryRepository.GetByIdAsync(product.Id);
            if(res == null)
            {
                return HttpHelper.FailedContent("failed");
            }

            var sth = new Category()
            {
                Title = res.Title,
                ParentId = res.ParentId,
                Createon = DateTime.Now,
            };

            var result = _categoryRepository.UpdateAsync(res);

            if (result == null)
            {
                return HttpHelper.FailedContent("category not added");
            }

            return true;
        }


        public async Task<ActionResult<bool>> RemoveAsync(int id)
        {
            var exist = await _categoryRepository.GetByIdAsync(id);
            if (exist != null)
            {
                var category = await _productCategoryRepository.GetByCategoryIdAsync(exist.Id);
                if (category != null)
                {
                    return HttpHelper.FailedContent("fail");
                }
                var res = _productCategoryRepository.RemoveAsync(category);
                if(res != null)
                {
                    return HttpHelper.FailedContent("fail");
                }
                return true;
            }

            return HttpHelper.NotFoundContent("wrong");
        }
    }
}
