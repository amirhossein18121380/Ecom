using Common.Utilities.Responses.Abstract;
using DataModel.Dtos;

namespace Ecom.business.Abstract
{
    public interface ISaleFactoryService
    {
        Task<IResponse> AddAsync(SaleFactorDto model);
    }
}
