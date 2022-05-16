
namespace Common.Utilities.Responses.Abstract
{
    public interface IDataResponse<T> : IResponse
    {
        T Data { get; }
        string Message { get; }
    }
}
