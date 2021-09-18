using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace KMT.Services
{
    public class StandardHttpClient : IHttpClient
    {
        private readonly HttpClient _client;
        public StandardHttpClient()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetStringAsync(string uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            var lang = Thread.CurrentThread.CurrentCulture.Name;
            requestMessage.Headers.AcceptLanguage.TryParseAdd(lang);

            var response = await _client.SendAsync(requestMessage);

            return await response.Content.ReadAsStringAsync();
        }
        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
        {
            return await DoPostPutAsync(HttpMethod.Post, uri, item);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string uri, T item)
        {
            return await DoPostPutAsync(HttpMethod.Put, uri, item);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            return await _client.SendAsync(requestMessage);
        }

        private async Task<HttpResponseMessage> DoPostPutAsync<T>(HttpMethod method, string uri, T item)
        {
            if (method != HttpMethod.Post && method != HttpMethod.Put)
                throw new ArgumentException("Value must be either post or put.", nameof(method));

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            requestMessage.Content =
                new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(requestMessage);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());

            return response;
        }

        public HttpResponseMessage Post<T>(string uri, T item)
        {
            return DoPostPut(HttpMethod.Post, uri, item);
        }
        private HttpResponseMessage DoPostPut<T>(HttpMethod method, string uri, T item)
        {
            if (method != HttpMethod.Post && method != HttpMethod.Put)
                throw new ArgumentException("Value must be either post or put.", nameof(method));

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            requestMessage.Content =
                new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

            var response = _client.SendAsync(requestMessage).Result;

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                throw new HttpRequestException(response.Content.ToString());

            return response;
        }
    }
}