﻿using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Serilog;

using Take.Api.GitHub.Models;

namespace Take.Api.GitHub.Facades.Strategies.ExceptionHandlingStrategies
{
    public class NotImplementedExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        private readonly ILogger _logger;

        public NotImplementedExceptionHandlingStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            var notImplementedException = exception as NotImplementedException;
            _logger.Error(notImplementedException, "[{@user}] Error: {@exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], notImplementedException?.Message);
            context.Response.StatusCode = StatusCodes.Status501NotImplemented;

            return await Task.FromResult(context);
        }
    }
}
