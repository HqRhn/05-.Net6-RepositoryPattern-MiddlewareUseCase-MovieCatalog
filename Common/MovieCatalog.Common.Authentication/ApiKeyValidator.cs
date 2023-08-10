using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalog.Common.Authentication
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        public IConfiguration _configuration;
        public ApiKeyValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool IsValid(string inputApiKey)
        {
            var actualApiKey  =_configuration.GetSection("Keys").GetSection("MovieCatalogApiKey").Value;
            if ((inputApiKey != null)  && (inputApiKey == actualApiKey))
            { 
                return true;
            }
            else
            return false;
        }
    }

    public interface IApiKeyValidator
    {
        bool IsValid(string apiKey);
    }
}
