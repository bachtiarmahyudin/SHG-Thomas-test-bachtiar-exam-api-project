using System;

namespace ExamAPI.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetInnerExceptionMessage(this Exception ex)
        {
            if (ex != null)
            {
                return GetInnerException(ex).Message;
            }
            return string.Empty;
        }

        private static Exception GetInnerException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GetInnerException(ex.InnerException);
            }
            return ex;
        }
    }
}