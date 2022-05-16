using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utilities.Responses.Abstract
{
    public interface IErrorResponse : IResponse
    {
       List<string> Errors { get; }
    }
}
