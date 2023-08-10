using Microsoft.AspNetCore.Mvc;
using System;

namespace MovieCatalog.Common.Authentication
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute(): base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
