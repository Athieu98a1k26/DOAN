using KMT.DATA_MODEL.PermissionMenu;
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
    public class PermissonMenuService
    {
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public PermissonMenuService(string remoteService, IHttpClient httpClient)
        {
            _remoteServiceBaseUrl = string.Format("{0}/api/permissonMenu", remoteService);

            _apiClient = httpClient;
        }
        public async Task<int> AddOrUpdate(PermissionMenuRequest model)
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

        public async Task<PermissionMenuResponse> search(PermissionMenuRequest model)
        {
            var dataString =
                await _apiClient.PostAsync(string.Format("{0}/search", _remoteServiceBaseUrl), model);
            if (dataString.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<PermissionMenuResponse>(await dataString.Content.ReadAsStringAsync());

                return response;
            }
            return new PermissionMenuResponse();
        }

        public async Task<int> Delete(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/Delete?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<int>(dataString);

            return response;
        }

        public async Task<PermissionMenuInfo> GetById(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/GetById?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<PermissionMenuInfo>(dataString);

            return response;
        }
    }
}