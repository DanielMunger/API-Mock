using System;

namespace API_4TELL.Controllers
{
    internal class HttpException : Exception
    {
        private int v1;
        private string v2;

        public HttpException()
        {
        }

        public HttpException(string message) : base(message)
        {
        }

        public HttpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public HttpException(int v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}