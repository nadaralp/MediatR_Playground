using MediatorTut.Services.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorTut.WebApi.Infrastructure
{
    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private readonly HttpContext httpContext;

        // DI container gets injected in the constructor. automatically happens for all classes in .NET Core.
        public UserIdPipe(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext;
        }

        


        // This is a Middleware. We can have an access token coming in and we want to read the UserId.
        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            var userId = httpContext
                        .User
                        .Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                        ?.Value;

            if (request is BaseRequest br)
            {
                br.UserId = "NadarAlpenidze";
            }

            return await next();

        }
    }
}
