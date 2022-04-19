using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

namespace SuperbillCompanion.Services
{
    public class Authenticator : IAuthenticator
    {
        readonly IHttpContextAccessor _httpContext;
        public Authenticator(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public async ValueTask Authenticate(RestClient client, RestRequest request)
        {
            var accessToken = await _httpContext.HttpContext.GetTokenAsync("access_token");
            request.AddHeader("Authorization", $"Bearer {accessToken}");
        }
    }
}
