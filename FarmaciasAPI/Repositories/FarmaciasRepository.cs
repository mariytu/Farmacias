using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FarmaciasAPI.DTO;
using FarmaciasAPI.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FarmaciasAPI.Repositories
{
    public interface IFarmaciasRepository
    {
        Task<ICollection<FarmaciasDTO>> GetFarmaciasPorComunaLocalAsync(string comuna, string local);
    }

    public class FarmaciasRepository : IFarmaciasRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _comunasEndpoint;
        private readonly string _farmaciasTurnoEndpoint;

        public FarmaciasRepository(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException("httpClientFactory");
            _configuration = configuration ?? throw new ArgumentNullException("configuration");

            _comunasEndpoint = _configuration["ExternalEndpoints:Comunas"];
            _farmaciasTurnoEndpoint = _configuration["ExternalEndpoints:FarmaciasTurno"];
        }

        /// <summary>
        /// Método que obtiene todas las farmacias de una comuna en particular y que coincidan o contengan parte del nombre de local indicado como parámetro.
        /// 
        /// Tanto comuna como local no son case sensitive, es decir, no es necesario preocuparse por mayúsculas o minúsculas.
        /// 
        /// (miturriaga)
        /// </summary>
        /// <param name="comuna">[Obligatorio] Nombre de la comuna donde se desea buscar la farmacia.</param>
        /// <param name="local">[Obligatorio] El nombre del local que se desea consultar en la comuna antes mencionada.</param>
        /// <returns></returns>
        public async Task<ICollection<FarmaciasDTO>> GetFarmaciasPorComunaLocalAsync(string comuna, string local)
        {
            #region Validacion de campos obligatorios
            if (string.IsNullOrEmpty(comuna))
                throw new ArgumentNullException(string.Format("El campo {0} no puede ser nulo o vacío.", "comuna"));
            if (string.IsNullOrEmpty(local))
                throw new ArgumentNullException(string.Format("El campo {0} no puede ser nulo o vacío.", "local"));
            #endregion

            var httpClient = _httpClientFactory.GetForHost(new Uri(_farmaciasTurnoEndpoint));
            ICollection<Farmacias> farmaciasResponse = null;

            var url = String.Format("{0}?id_region=7", _farmaciasTurnoEndpoint);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            using (var response = await httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Se obtiene la respuesta y se transforma el json de respuesta en el objeto Farmacias que contiene la descripción del objeto con todos sus campos
                    var resp = await response.Content.ReadAsStringAsync();
                    farmaciasResponse = JsonConvert.DeserializeObject<ICollection<Farmacias>>(resp);
                }
                else
                {
                    throw new HttpRequestException(String.Format("Ocurrio un error al consultar las farmacias de turno. {0}", response.ReasonPhrase));
                }
            }

            // TODO: Aquí eventualmente podría guardar la data obtenida de las farmacias en un cache con la llave Farmacias-dia, y un poco más arriba validar si existe un cache.. tiempo para la data en cache: 1 día

            // Se filtran las farmacias obtenidas por la comuna y nombre de local. Para el local el string solo debe contener parte del local
            return farmaciasResponse.Where(x => x.ComunaNombre.ToLower().Equals(comuna.ToLower()) && x.LocalNombre.ToLower().Contains(local.ToLower())).Select(x => new FarmaciasDTO(x)).ToList();
        }
    }
}
