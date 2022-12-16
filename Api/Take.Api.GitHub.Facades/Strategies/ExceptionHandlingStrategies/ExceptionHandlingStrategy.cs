using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Take.Api.GitHub.Facades.Strategies.ExceptionHandlingStrategies
{
    public abstract class ExceptionHandlingStrategy
    {
        public abstract Task<HttpContext> HandleAsync(HttpContext context, Exception exception);
    }
}
