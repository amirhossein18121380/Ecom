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
        
        private IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
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
    
            return false;
        }
    }
}
