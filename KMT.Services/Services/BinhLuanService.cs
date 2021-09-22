using KMT.DATA_MODEL.BinhLuan;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KMT.Services.Services
{
    public class BinhLuanService
    {
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public BinhLuanService(string remoteService, IHttpClient httpClient)
        {
            _remoteServiceBaseUrl = string.Format("{0}/api/BinhLuan", remoteService);

            _apiClient = httpClient;
        }
        public async Task<int> AddOrUpdate(BinhLuanRequest model)
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

        public async Task<BinhLuanResponse> search(BinhLuanRequest model)
        {
            var dataString =
                await _apiClient.PostAsync(string.Format("{0}/search", _remoteServiceBaseUrl), model);
            if (dataString.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<BinhLuanResponse>(await dataString.Content.ReadAsStringAsync());

                return response;
            }
            return new BinhLuanResponse();
        }

        public async Task<int> Delete(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/Delete?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<int>(dataString);

            return response;
        }
        //public List<BinhLuanInfo> GetListBinhLuan(int IDSANPHAM)
        public async Task<List<BinhLuanInfo>> GetListBinhLuan(int IDSANPHAM)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/GetListBinhLuan?IDSANPHAM={1}", _remoteServiceBaseUrl, IDSANPHAM));

            var response = JsonConvert.DeserializeObject<List<BinhLuanInfo>>(dataString);

            return response;
        }
        public async Task<BinhLuanInfo> GetById(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/GetById?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<BinhLuanInfo>(dataString);

            return response;
        }
        //bool IsBinhLuan(int IDUSER, int IDSANPHAM)
        public async Task<bool> IsBinhLuan(int IDUSER, int IDSANPHAM)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/IsBinhLuan?IDUSER={1}&IDSANPHAM={2}", _remoteServiceBaseUrl, IDUSER, IDSANPHAM));

            var response = JsonConvert.DeserializeObject<bool>(dataString);

            return response;
        }
    }
}