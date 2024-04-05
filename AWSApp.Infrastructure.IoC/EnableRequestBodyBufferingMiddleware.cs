using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Infrastructure.IoC
{
    public class EnableRequestBodyBufferingMiddleware
    {
        private readonly RequestDelegate _next;

        public EnableRequestBodyBufferingMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();

            await _next(context);
        }
    }
}
