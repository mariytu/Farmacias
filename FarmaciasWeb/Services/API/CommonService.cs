using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FarmaciasWeb.Services.API
{
    public class CommonService : ICommonService
    {
        private readonly IFarmaciasApiClient _apiClient;
        public IFarmaciasApiAuthenticator MessageAuthenticator { get; set; }

        public CommonService(IFarmaciasApiClient apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException("apiClient");
        }

        public async Task<string> GetComunasRM()
        {
            var auth = MessageAuthenticator ?? NullAuthenticator.Null;
            var url = string.Format("api/Common/ComunasRM");

            var result = await _apiClient.Get(url, auth);
            var resultContent = await result.Content.ReadAsStringAsync();
            return resultContent;
        }
    }
}