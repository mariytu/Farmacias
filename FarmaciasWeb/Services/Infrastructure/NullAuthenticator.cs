using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FarmaciasWeb.Services
{
    public class NullAuthenticator : IFarmaciasApiAuthenticator
    {
        public void AuthenticateMessage(HttpRequestMessage message)
        {
            //hacer nada
        }

        private static NullAuthenticator _null;
        public static NullAuthenticator Null
        {
            get
            {
                if (_null == null)
                    _null = new NullAuthenticator();
                return _null;
            }
        }
    }
}