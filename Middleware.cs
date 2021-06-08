using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _Logger;

        public Middleware(RequestDelegate next,ILoggerFactory loggerFactory)
        {
            
            _next = next;
            _Logger = loggerFactory.CreateLogger<Middleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _Logger.LogInformation("**HandlingRequest:" +httpContext.Request.Path +"**");
            await _next.Invoke(httpContext);
            _Logger.LogInformation("** finished Request **");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
