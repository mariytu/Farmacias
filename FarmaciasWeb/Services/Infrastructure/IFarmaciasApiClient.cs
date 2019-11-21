using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FarmaciasWeb.Services
{
    public interface IFarmaciasApiClient
    {
        Task<HttpResponseMessage> Get(string requestUri, IFarmaciasApiAuthenticator authenticator);
        Task<HttpResponseMessage> Post(string requestUri, HttpContent content, IFarmaciasApiAuthenticator authenticator);
        Task<HttpResponseMessage> Put(string requestUri, HttpContent content, IFarmaciasApiAuthenticator authenticator);
        Task<HttpResponseMessage> Delete(string requestUri, IFarmaciasApiAuthenticator authenticator);
    }
}