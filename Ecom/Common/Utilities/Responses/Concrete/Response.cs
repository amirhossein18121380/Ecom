using System;
using System.Collections.Generic;
using System.Text;
using Common.Utilities.Responses.Abstract;

namespace Common.Utilities.Responses.Concrete
{
    public class Response : IResponse
    {
        public bool Success { get; }

        public int StatusCode { get; }

        public Response(bool success,int statuscode)
        {
            Success = success;
            StatusCode = statuscode;
        }

        public Response(bool success)
        {
            Success = success;
        }
    }
}
