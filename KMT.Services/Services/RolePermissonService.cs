using KMT.DATA_MODEL.RolePermisson;
using KMT.DATA_MODEL.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KMT.Services
{
    public class RolePermissonService
    {
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public RolePermissonService(string remoteService, IHttpClient httpClient)
        {
            _remoteServiceBaseUrl = string.Format("{0}/api/rolepermisson", remoteService);

            _apiClient = httpClient;
        }
        public async Task<int> AddOrUpdate(RolePermissonRequest model)
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

        public async Task<RolePermissonResponse> search(RolePermissonRequest model)
        {
            var dataString =
                await _apiClient.PostAsync(string.Format("{0}/search", _remoteServiceBaseUrl), model);
            if (dataString.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<RolePermissonResponse>(await dataString.Content.ReadAsStringAsync());

                return response;
            }
            return new RolePermissonResponse();
        }

        public async Task<int> Delete(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/Delete?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<int>(dataString);

            return response;
        }

        public async Task<RolePermissonInfo> GetById(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/GetById?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<RolePermissonInfo>(dataString);

            return response;
        }
    }
}