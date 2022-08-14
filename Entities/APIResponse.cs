using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class APIResponse<T>
    {
        public APIResponseResult<T> result { get; set; }
        public APIResponseCodeEnum responseCode { get; set; }
    }

    public enum APIResponseCodeEnum
    {
        Success = 200,
        Created = 201,
        Accepted = 202,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        InternalServerError = 500
    }

    public class APIResponseResult<T>
    {
        public T data { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
    }

    public static class ErrorCode
    {
        public const string FailedCode = "Fld";
    }
}
