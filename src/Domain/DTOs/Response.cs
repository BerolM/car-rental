using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class Response<TData>
    {
        public bool IsSuccess { get; private protected set; }
        public string Message { get; private protected set; }
        public TData Data { get; private protected set; }
        public static Response<TData> Success(string message = "",TData data=default(TData))
        {
            return new Response<TData>
            {
                IsSuccess = true,
                Message = message,
                Data=data
            };
        }
        public static Response<TData> Fail(string message)
        {
            return new Response<TData>
            {
                IsSuccess = false,
                Message = message,
            };

        }
    }

    public class Response : Response<object>
    {
        public static Response Success(string message = "")
        {
            return new Response
            {
                IsSuccess=true,
                Message=message
            };
        }
        public static new Response Fail(string message)
        {
            return new Response
            {
                IsSuccess = false,
                Message = message
            };

        }
    }
}
