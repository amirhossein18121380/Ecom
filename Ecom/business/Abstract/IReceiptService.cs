using Common.Utilities.Responses.Abstract;
using DataModel.Dtos;

namespace Ecom.business.Abstract
{
    public interface IReceiptService
    {
        Task<IResponse> AddAsync(ReceiptDto model);
    }
}