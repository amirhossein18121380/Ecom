using System;
using System.Collections.Generic;
using System.Text;
using Common.Utilities.Responses.Abstract;

namespace Common.Utilities.Responses.Concrete
{
    public class SuccessResponse : ISuccessResponse
    {
        public bool Success { get; } = true;
        public string Message { get; }
        public int StatusCode { get; }


        public SuccessResponse()
        {

        }

        public SuccessResponse(int statuscode, string message)
        {
            StatusCode = statuscode;
            Message = message;
        }
    }
}
