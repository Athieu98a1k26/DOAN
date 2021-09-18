using KMT.DATA_MODEL;
using KMT.DATA_MODEL.Permisson;
using KMT.DATA_MODEL.Role;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KMT.Services
{
    public class PermissonService
    {
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public PermissonService(string remoteService, IHttpClient httpClient)
        {
            _remoteServiceBaseUrl = string.Format("{0}/api/permisson", remoteService);

            _apiClient = httpClient;
        }
        public async Task<int> AddOrUpdate(PermissonRequest model)
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

        public async Task<PermissonResponse> search(PermissonRequest model)
        {
            var dataString =
                await _apiClient.PostAsync(string.Format("{0}/search", _remoteServiceBaseUrl), model);
            if (dataString.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<PermissonResponse>(await dataString.Content.ReadAsStringAsync());

                return response;
            }
            return new PermissonResponse();
        }
    }
}