using Microsoft.AspNetCore.Http;

namespace EventMaker.Infrastructure
{
    public class Result<T>
    {
        public T? Value { get; set; }
        public string? Message { get; set; }
        public bool Successed { get; set; }
        public int StatusCode { get; set; }

        internal Result(T value)
        {
            Value = value;
            Successed = true;
        }
        internal Result(string message)
        {
            Value = default(T);
            Message = message;
            Successed = false;
        }
        internal Result(string message, int statuscode)
        {
            Value = default(T);
            Message = message;
            Successed = false;
            StatusCode = statuscode;
        }
        public static Result<T> Success(T value)
        {
            return new Result<T>(value);
        }
        public static Result<T> Failure(string errormessage)
        {
            return new Result<T>(errormessage);
        }
        public static Result<T> Failure(string errormessage, int statuscode)
        {
            return new Result<T>(errormessage, statuscode);
        } 
     

    }
}
