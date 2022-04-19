using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using RestSharp;
using RestSharp.Authenticators;
using SuperbillCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SuperbillCompanion.Services
{
    public class ConfigClient
    {
        readonly RestClient _restClient;
        public ConfigClient(HttpClient httpClient, IAuthenticator auth)
        {
            var options = new RestClientOptions("https://superbillapi.datev.it");
            _restClient = new RestClient(httpClient, options);
            _restClient.Authenticator = auth;
        }

        public async Task<IEnumerable<UserTenant>> GetMyTenantsAsync(CancellationToken cancellationToken = default)
        {
            var request = new RestRequest("/v10/user-tenants");
            var response = await _restClient.GetAsync<IEnumerable<UserTenant>>(request, cancellationToken);

            return response;
        }
    }
}
