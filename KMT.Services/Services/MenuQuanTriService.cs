using KMT.DATA_MODEL.MenuQuanTri;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KMT.Services
{
    public class MenuQuanTriService
    {
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public MenuQuanTriService(string remoteService, IHttpClient httpClient)
        {
            _remoteServiceBaseUrl = string.Format("{0}/api/menuQuanTri", remoteService);

            _apiClient = httpClient;
        }
        public async Task<List<MenuQuanTriInfo>>GetAll()
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/GetAll", _remoteServiceBaseUrl));

            var response = JsonConvert.DeserializeObject<List<MenuQuanTriInfo>>(dataString);

            return response;
        }
    }
}