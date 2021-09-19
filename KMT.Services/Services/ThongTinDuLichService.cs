using KMT.DATA_MODEL.ThongTinDuLich;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KMT.Services.Services
{
    public class ThongTinDuLichService
    {
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public ThongTinDuLichService(string remoteService, IHttpClient httpClient)
        {
            _remoteServiceBaseUrl = string.Format("{0}/api/ThongTinDuLich", remoteService);

            _apiClient = httpClient;
        }
        public async Task<int> AddOrUpdate(ThongTinDuLichInfo model)
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

        public async Task<ThongTinDuLichResponse> search(ThongTinDuLichRequest model)
        {
            var dataString =
                await _apiClient.PostAsync(string.Format("{0}/search", _remoteServiceBaseUrl), model);
            if (dataString.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<ThongTinDuLichResponse>(await dataString.Content.ReadAsStringAsync());

                return response;
            }
            return new ThongTinDuLichResponse();
        }

        public async Task<int> Delete(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/Delete?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<int>(dataString);

            return response;
        }

        public async Task<ThongTinDuLichInfo> GetById(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/GetById?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<ThongTinDuLichInfo>(dataString);

            return response;
        }
    }
}