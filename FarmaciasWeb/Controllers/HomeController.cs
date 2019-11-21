using FarmaciasCore.DTO;
using FarmaciasWeb.Services;
using FarmaciasWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FarmaciasWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommonService _commonService;
        private readonly IFarmaciasService _farmaciasService;
        private static string _comunasHTML;

        public HomeController(ICommonService commonService, IFarmaciasService farmaciasService)
        {
            _commonService = commonService ?? throw new ArgumentNullException("commonService");
            _farmaciasService = farmaciasService ?? throw new ArgumentNullException("farmaciasService");
        }

        public async Task<ActionResult> Index()
        {
            _comunasHTML = await _commonService.GetComunasRM();

            return View(new FarmaciasViewModels()
            {
                ComunasHTML = _comunasHTML,
                Farmacias = new List<FarmaciasDTO>()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Index(FarmaciasViewModels model)
        {
            model.Farmacias = new List<FarmaciasDTO>();

            if (ModelState.IsValid)
            {
                var resp = await _farmaciasService.GetPorComunaIdLocal(model.IdComuna, model.NombreLocal);
                model.Farmacias = resp;
            }

            #region Para mantener la opcion seleccionada
            string comunas = _comunasHTML;
            if (model.IdComuna != 0)
            {
                comunas = comunas.Replace(" selected", "");
                string match = String.Format("value='{0}'", model.IdComuna);
                int pos = comunas.IndexOf(match) + match.Length;

                string part1 = comunas.Substring(0, pos);
                string part2 = comunas.Substring(pos, comunas.Length - pos);

                comunas = part1 + " selected" + part2;
            }
            #endregion

            model.ComunasHTML = comunas;
            return View(model);
        }
    }
}