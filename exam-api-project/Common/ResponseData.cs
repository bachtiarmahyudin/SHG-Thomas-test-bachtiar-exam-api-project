using System.Net;

namespace ExamAPI.Common
{
    public class ResponseData<T>
    {
        public HttpStatusCode code { get; set; }

        public string message { get; set; }

        public T data { get; set; }
    }
}