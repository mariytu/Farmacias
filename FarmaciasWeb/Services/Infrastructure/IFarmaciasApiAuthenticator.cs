using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FarmaciasWeb.Services
{
    public interface IFarmaciasApiAuthenticator
    {
        void AuthenticateMessage(HttpRequestMessage message);
    }
}