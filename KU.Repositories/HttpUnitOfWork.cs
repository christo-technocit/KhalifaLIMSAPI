using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KU.Repositories
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(ApplicationDbContext context, IHttpContextAccessor httpAccessor) : base(context)
        {
            context.CurrentUserId = httpAccessor.HttpContext.User.FindFirst(OpenIdConnectConstants.Claims.Subject)?.Value?.Trim();
        }
    }
}
