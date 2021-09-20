using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KMT.Services.Services
{
    public class PhongService
    {
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public PhongService(string remoteService, IHttpClient httpClient)
        {
            _remoteServiceBaseUrl = string.Format("{0}/api/Phong", remoteService);

            _apiClient = httpClient;
        }
        public async Task<int> AddOrUpdate(PhongInfo model)
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

        public async Task<PhongResponse> search(PhongRequest model)
        {
            var dataString =
                await _apiClient.PostAsync(string.Format("{0}/search", _remoteServiceBaseUrl), model);
            if (dataString.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<PhongResponse>(await dataString.Content.ReadAsStringAsync());

                return response;
            }
            return new PhongResponse();
        }

        public async Task<int> Delete(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/Delete?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<int>(dataString);

            return response;
        }

        public async Task<PhongInfo> GetById(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/GetById?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<PhongInfo>(dataString);

            return response;
        }
    }
}