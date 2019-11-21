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
    public class CommonController : ControllerBase
    {
        private readonly ICommonRepository _commonRepo;

        public CommonController(IConfiguration configuration)
        {
            _commonRepo = new CommonRepository(new HttpClientFactory(configuration), configuration);
        }

        /// <summary>
        /// GET: api/Common/ComunasRM
        /// 
        /// (miturriaga)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ComunasRM")]
        public async Task<IActionResult> GetComunasRM()
        {
            try
            {
                var comunas = await _commonRepo.GetComunasRMAsync();
                return Ok(comunas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}