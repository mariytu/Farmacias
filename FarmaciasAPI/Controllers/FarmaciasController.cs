using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using FarmaciasAPI.Repositories;
using Microsoft.Extensions.Configuration;

namespace FarmaciasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciasController : ControllerBase
    {
        private readonly IFarmaciasRepository _farmRepo;

        public FarmaciasController(IConfiguration configuration)
        {
            _farmRepo = new FarmaciasRepository(new HttpClientFactory(configuration), configuration);
        }

        /// <summary>
        /// GET: api/Farmacias/PorComunaLocal?comuna={0}&local={1}
        /// Método que obtiene todas las farmacias de una comuna en particular y que coincidan o contengan parte del nombre de local indicado como parámetro.
        /// 
        /// Tanto comuna como local no son case sensitive, es decir, no es necesario preocuparse por mayúsculas o minúsculas.
        /// 
        /// (miturriaga)
        /// </summary>
        /// <param name="comuna">[Obligatorio] Nombre de la comuna donde se desea buscar la farmacia.</param>
        /// <param name="local">[Obligatorio] El nombre del local que se desea consultar en la comuna antes mencionada.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("PorComunaLocal")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPorComunaLocal([FromQuery] string comuna, [FromQuery] string local)
        {
            try
            {
                var farmacias = await _farmRepo.GetFarmaciasPorComunaLocalAsync(comuna, local);
                return Ok(farmacias);
            }
            catch (ArgumentNullException ane)
            {
                //Para este metodo, la mayoria de las excepciones de este tipo es porque comuna o local son parametros nulos o vacios
                return BadRequest(ane.Message);
            }
            catch (Exception ex)
            {
                // Para el resto de las excepciones que puedan ocurrir que no se controlen como cuando hay un error al consultar la api de farmacias de turno
                return BadRequest(ex.Message);
            }
        }
    }
}