using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utilities.Responses.Abstract
{
    public interface IResponse
    {
         bool Success { get; }
         int StatusCode { get; }
    }
}