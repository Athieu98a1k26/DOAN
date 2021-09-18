using KMT.DATA_MODEL;
using KMT.DATA_MODEL.Role;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KMT.Services
{
    public class RoleService
    {
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public RoleService(string remoteService, IHttpClient httpClient)
        {
            _remoteServiceBaseUrl = string.Format("{0}/api/role", remoteService);

            _apiClient = httpClient;
        }
        public async Task<int> AddOrUpdate(RoleRequest model)
        {
            var dataString =
                await _apiClient.PostAsync(string.Format("{0}/AddOrUpdate", _remoteServiceBaseUrl), model);
            if (dataString.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<int>(await dataString.Content.ReadAsStringAsync());

                return response;
            }
            return 0;
        }

        public async Task<RoleResponse> search(RoleRequest model)
        {
            var dataString =
                await _apiClient.PostAsync(string.Format("{0}/search", _remoteServiceBaseUrl), model);
            if (dataString.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<RoleResponse>(await dataString.Content.ReadAsStringAsync());

                return response;
            }
            return new RoleResponse();
        }
    }
}