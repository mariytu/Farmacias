using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FarmaciasAPI.Providers
{
    public class LoggingHandler : DelegatingHandler
    {
        private bool _log = true;
        private bool _log_request = true;
        private bool _log_response = true;

        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_log && _log_request)
            {
                System.Diagnostics.Debug.WriteLine("Request:");
                System.Diagnostics.Debug.WriteLine(request.ToString());
                if (request.Content != null)
                {
                    System.Diagnostics.Debug.WriteLine(await request.Content.ReadAsStringAsync());
                }
                System.Diagnostics.Debug.WriteLine("");
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (_log && _log_response)
            {
                System.Diagnostics.Debug.WriteLine("Response:");
                System.Diagnostics.Debug.WriteLine(response.ToString());
                if (response.Content != null)
                {
                    System.Diagnostics.Debug.WriteLine(await response.Content.ReadAsStringAsync());
                }
                System.Diagnostics.Debug.WriteLine("");
            }

            return response;
        }
    }
}
