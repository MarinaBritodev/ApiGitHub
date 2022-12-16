using System;
using System.Net;
using System.Runtime.Serialization;

namespace Take.Api.GitHub.Models.Exceptions
{
    [Serializable]
    public class RepositoryException : BaseException
    {
        public string UserRepository { get; set; }

        public RepositoryException(string errorMessage) : base(errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public RepositoryException(string errorMessage, HttpStatusCode statusCode) : base(errorMessage, statusCode) { }

        public RepositoryException(string errorMessage, HttpStatusCode statusCode, string userRepository) : base(errorMessage, statusCode)
        {
            UserRepository = userRepository;
        }

        public RepositoryException(string errorMessage, HttpStatusCode statusCode, string userRepository, Exception exceptionObject)
            : base(errorMessage, statusCode, exceptionObject)
        {
            UserRepository = userRepository;
        }

        protected RepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            base.GetObjectData(info, context);
        }
    }
}
