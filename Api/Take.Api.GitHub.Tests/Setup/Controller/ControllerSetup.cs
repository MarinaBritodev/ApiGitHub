﻿
using System;
using System.Net.Http;

using Microsoft.AspNetCore.Http;

using RestEase;

using Take.Api.GitHub.Models;
using Take.Api.GitHub.Models.Exceptions;

namespace Take.Api.GitHub.Tests.Setup.Controller
{
    public static class ControllerSetup
    {

        #region Private Fields

        private const string HEADER_VALUE = "Header";

        #endregion Private Fields

        #region Public Properties

        public static HttpContext HttpContext
        {
            get
            {
                var context = new DefaultHttpContext();
                context.Request.Headers[Constants.BLIP_USER_HEADER] = HEADER_VALUE;
                return context;
            }
        }

        public static ApiException ApiException
        {
            get
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    RequestMessage = new HttpRequestMessage(HttpMethod.Post,
                        string.Empty)
                };

                var exception = new ApiException(new HttpRequestMessage(HttpMethod.Post,
                    string.Empty), response, string.Empty);

                return exception;
            }
        }

        public static NotImplementedException NotImplementedException
        {
            get
            {
                return new NotImplementedException(string.Empty);
            }
        }

        public static RepositoryException RepositoryException
        {
            get
            {
                return new RepositoryException(string.Empty);
            }
        }

        #endregion Public Properties

    }
}
