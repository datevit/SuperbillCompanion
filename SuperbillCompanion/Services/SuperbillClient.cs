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
    public class SuperbillClient
    {
        readonly RestClient _restClient;
        public SuperbillClient(HttpClient httpClient, IAuthenticator auth)
        {
            var options = new RestClientOptions("https://superbillapp.datev.it/efat");
            _restClient = new RestClient(httpClient, options);
            _restClient.UseAuthenticator(auth);
        }

        public async Task<IEnumerable<Ditta>> GetDitteAsync(RequestViewModel data, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest("/api/v1/ditte");
            request.AddHeader("Authorization-Key", data.ApiKey);
            request.AddHeader("User-Tenant", data.TenantId);
            var response = await _restClient.GetAsync(request, cancellationToken);
            if (response.IsSuccessful)
            {
                var ditte = _restClient.Deserialize<IEnumerable<Ditta>>(response).Data;
                return ditte;
            }

            throw new NotImplementedException();
        }

        public async Task<PageResults<Documento>> GetFattureAsync(RequestViewModel data, int page = 0, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest($"/api/v1/documenti/{data.IdElemento}");
            request.AddHeader("Authorization-Key", data.ApiKey);
            request.AddHeader("User-Tenant", data.TenantId);

            request.AddParameter("TipoDocumento", 3, ParameterType.QueryString); // 3=fatture
            request.AddParameter("Anno", 2021, ParameterType.QueryString);
            if (page > 0)
            {
                request.AddParameter("Page", page, ParameterType.QueryString);
            }
            var response = await _restClient.GetAsync(request, cancellationToken);
            if (response.IsSuccessful)
            {
                return _restClient.Deserialize<PageResults<Documento>>(response).Data;
            }

            throw new NotImplementedException();
        }
    }

}
