using KMT.DATA_MODEL.Users;
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

        public async Task<int> AddOrUpdate(UserRequest model)
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

        public async Task<UserResponse> search(UserRequest model)
        {
            var dataString =
                await _apiClient.PostAsync(string.Format("{0}/search", _remoteServiceBaseUrl), model);
            if (dataString.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<UserResponse>(await dataString.Content.ReadAsStringAsync());

                return response;
            }
            return new UserResponse();
        }

        public async Task<int> Delete(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/Delete?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<int>(dataString);

            return response;
        }

        public async Task<UserInfo> GetById(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/GetById?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<UserInfo>(dataString);

            return response;
        }

        public async Task<UserIdentity> getUserIdentity(int Id)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/getUserIdentity?Id={1}", _remoteServiceBaseUrl, Id));

            var response = JsonConvert.DeserializeObject<UserIdentity>(dataString);

            return response;
        }


        public async Task<UserInfo> GetByUserName(string UserName)
        {
            var dataString =
                await _apiClient.GetStringAsync(string.Format("{0}/GetByUserName?UserName={1}", _remoteServiceBaseUrl, UserName));

            var response = JsonConvert.DeserializeObject<UserInfo>(dataString);

            return response;
        }


    }
}