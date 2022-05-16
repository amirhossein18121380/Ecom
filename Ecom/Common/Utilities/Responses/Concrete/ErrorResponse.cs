using System;
using System.Collections.Generic;
using System.Text;
using Common.Utilities.Responses.Abstract;

namespace Common.Utilities.Responses.Concrete
{
    public class ErrorResponse : IErrorResponse
    {
        public bool Success { get; } = false;
        public int StatusCode { get; }
        public List<string> Errors { get; private set; } = new List<string>();

        public ErrorResponse(int statuscode, List<string> errors)
        {
            StatusCode = statuscode;
            Errors = errors;
        }

        public ErrorResponse(int statuscode, string error)
        {
            StatusCode = statuscode;
            Errors.Add(error);
        }

        public ErrorResponse(string error)
        {
            Errors.Add(error);
        }
    }
}
