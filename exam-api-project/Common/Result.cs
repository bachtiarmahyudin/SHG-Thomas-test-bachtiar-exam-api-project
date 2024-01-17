using ExamAPI.Extensions;
using System;

namespace ExamAPI.Common
{
    /// <summary>
    /// Class for Result containing the given value
    /// </summary>
    public class Result<T> : Result
    {
        /// <summary>
        /// Creates a success result containing the given value.
        /// </summary>
        public static Result<T> Success(T data)
        {
            return new Result<T> { IsSuccess = true, ErrorMessage = string.Empty, Data = data };
        }

        /// <summary>
        /// Create a failure result with the given error message.
        /// </summary>
        public new static Result<T> Fail(string message, bool isException = false)
        {
            return new Result<T> { IsSuccess = false, ErrorMessage = message, IsException = isException };
        }

        /// <summary>
        /// Create a failure result with the given exception.
        /// </summary>
        public new static Result<T> Fail(Exception ex)
        {
            return new Result<T> { IsSuccess = false, ErrorMessage = ex.GetInnerExceptionMessage(), IsException = true };
        }

        /// <summary>
        /// Property for the given value
        /// </summary>
        public T Data { get; set; }
    }

    /// <summary>
    /// Class for Result
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Constructor for Result
        /// </summary>
        public Result()
        {
            IsSuccess = false;
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// Create a success result.
        /// </summary>
        public static Result Success()
        {
            return new Result { IsSuccess = true, ErrorMessage = string.Empty };
        }

        /// <summary>
        /// Create a failure result with the given error message.
        /// </summary>
        public static Result Fail(string message, bool isException = false)
        {
            return new Result { IsSuccess = false, ErrorMessage = message, IsException = isException };
        }

        /// <summary>
        /// Create a failure result with the given exception.
        /// </summary>
        public static Result Fail(Exception ex)
        {
            return new Result { IsSuccess = false, ErrorMessage = ex.GetInnerExceptionMessage(), IsException = true };
        }

        /// <summary>
        /// property to check if the result is success or not
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// property that contains error message of the result
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// property that flag is exception of the result
        /// </summary>
        public bool IsException { get; set; }
    }
}