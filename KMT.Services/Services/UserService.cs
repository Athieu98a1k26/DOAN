using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KMT.Services
{
    public class UserService
    {
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public UserService(string remoteService, IHttpClient httpClient)
        {
            _remoteServiceBaseUrl = string.Format("{0}/api/user", remoteService);

            _apiClient = httpClient;
        }
        public async Task<int>GetCountByUserName(string UserName)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/GetCountByUserName?UserName={1}", _remoteServiceBaseUrl, UserName));

            var response = JsonConvert.DeserializeObject<int>(dataString);

            return response;
        }
    }
}