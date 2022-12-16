using System;
using System.Net;
using System.Runtime.Serialization;

namespace Take.Api.GitHub.Models.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Exception ExceptionObject { get; set; }

        protected BaseException() { }

        protected BaseException(string errorMessage) : base(errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        protected BaseException(string erroMessage, HttpStatusCode statusCode) : base(erroMessage)
        {
            ErrorMessage = erroMessage;
            StatusCode = statusCode;
        }

        protected BaseException(string errorMessage, HttpStatusCode statusCode, Exception exceptionObject)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
            ExceptionObject = exceptionObject;
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentException("info");
            }

            base.GetObjectData(info, context);
        }
    }
}
