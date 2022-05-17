using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.IdentityModel.Logging;

namespace Common.Utilities
{
    public static class HttpHelper
    {
        public static ContentResult ExceptionContent(Exception ex)
        {

            return new ContentResult {
                Content = "در عملیات درخواستی شما خطایی رخ داده",
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ContentType = "text/html"
            };
        }

        public static ContentResult AccessDeniedContent()
        {

            return new ContentResult {
                Content = "شما به این سرویس دسترسی ندارید",
                StatusCode = (int)HttpStatusCode.BadRequest,
                ContentType = "text/html"
            };
        }

        public static ContentResult InvalidContent()
        {

            return new ContentResult {
                Content = "اطلاعات ارسالی به سرور معتبر نمی باشند",
                StatusCode = (int)HttpStatusCode.BadRequest,
                ContentType = "text/html"
            };
        }

        public static ContentResult FailedContent(string msgContent)
        {
            return new ContentResult {
                Content = msgContent,
                StatusCode = (int)HttpStatusCode.BadRequest,
                ContentType = "text/html"
            };
        }

        public static ContentResult NotFoundContent(string contentMessage)
        {
            return new ContentResult {
                Content = contentMessage,
                StatusCode = (int)HttpStatusCode.NotFound,
                ContentType = "text/html"
            };
        }
    }
}
