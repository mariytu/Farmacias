using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FarmaciasCore.DTO;
using FarmaciasCore.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FarmaciasAPI.Repositories
{
    public interface ICommonRepository
    {
        Task<string> GetComunasRMAsync();
    }

    public class CommonRepository : ICommonRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _comunasEndpoint;

        public CommonRepository(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException("httpClientFactory");
            _configuration = configuration ?? throw new ArgumentNullException("configuration");

            _comunasEndpoint = _configuration["ExternalEndpoints:Comunas"];
        }

        public async Task<string> GetComunasRMAsync()
        {
            var httpClient = _httpClientFactory.GetForHost(new Uri(_comunasEndpoint));
            string comunasResponseHTML = null;

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("reg_id", "7")
            });
            using (var response = await httpClient.PostAsync(_comunasEndpoint, formContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Se obtiene la respuesta y se transforma el json de respuesta en el objeto Farmacias que contiene la descripción del objeto con todos sus campos
                    comunasResponseHTML = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException(String.Format("Ocurrio un error al consultar las comunas de la region metropolitana. {0}", response.ReasonPhrase));
                }
            }

            return comunasResponseHTML;
        }
    }
}
