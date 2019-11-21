using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FarmaciasCore.DTO;
using Newtonsoft.Json;

namespace FarmaciasWeb.Services.API
{
    public class FarmaciasService : IFarmaciasService
    {
        private readonly IFarmaciasApiClient _apiClient;
        public IFarmaciasApiAuthenticator MessageAuthenticator { get; set; }

        public FarmaciasService(IFarmaciasApiClient apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException("apiClient");
        }

        public async Task<IEnumerable<FarmaciasDTO>> GetPorComunaLocal(string comuna, string local)
        {
            var auth = MessageAuthenticator ?? NullAuthenticator.Null;
            var url = string.Format("api/Farmacias/PorComunaLocal?comuna={0}&local={1}", comuna, local);

            var result = await _apiClient.Get(url, auth);
            var resultContent = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<FarmaciasDTO>>(resultContent);
        }

        public async Task<IEnumerable<FarmaciasDTO>> GetPorComunaIdLocal(int comunaId, string local)
        {
            var auth = MessageAuthenticator ?? NullAuthenticator.Null;
            var url = string.Format("api/Farmacias/PorComunaIdLocal?comunaId={0}&local={1}", comunaId, local);

            var result = await _apiClient.Get(url, auth);
            var resultContent = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<FarmaciasDTO>>(resultContent);
        }
    }
}