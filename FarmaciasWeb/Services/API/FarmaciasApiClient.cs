using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FarmaciasWeb.Services.API
{
    public class FarmaciasApiClient : IFarmaciasApiClient
    {
        private readonly HttpClient _httpClient;

        public FarmaciasApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException("httpClient");
        }

        public async Task<HttpResponseMessage> Get(string requestUri, IFarmaciasApiAuthenticator authenticator)
        {
            if (authenticator == null) throw new ArgumentNullException("authenticator");
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                authenticator.AuthenticateMessage(requestMessage);
                return await _httpClient.SendAsync(requestMessage);
            }
        }

        public async Task<HttpResponseMessage> Post(string requestUri, HttpContent content, IFarmaciasApiAuthenticator authenticator)
        {
            if (authenticator == null) throw new ArgumentNullException("authenticator");
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri))
            {
                authenticator.AuthenticateMessage(requestMessage);
                requestMessage.Content = content;
                return await _httpClient.SendAsync(requestMessage);
            }
        }

        public async Task<HttpResponseMessage> Put(string requestUri, HttpContent content, IFarmaciasApiAuthenticator authenticator)
        {
            if (authenticator == null) throw new ArgumentNullException("authenticator");
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri))
            {
                authenticator.AuthenticateMessage(requestMessage);
                requestMessage.Content = content;
                return await _httpClient.SendAsync(requestMessage);
            }
        }

        public async Task<HttpResponseMessage> Delete(string requestUri, IFarmaciasApiAuthenticator authenticator)
        {
            if (authenticator == null) throw new ArgumentNullException("authenticator");
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri))
            {
                authenticator.AuthenticateMessage(requestMessage);
                return await _httpClient.SendAsync(requestMessage);
            }
        }
    }
}