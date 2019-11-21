using FarmaciasCore.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmaciasWeb.ViewModels
{
    public class FarmaciasViewModels
    {
        public IEnumerable<FarmaciasDTO> Farmacias { get; set; }

        public string ComunasHTML { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una comuna.")]
        public int IdComuna { get; set; }

        [Required(ErrorMessage = "El campo Nombre Local es obligatorio.")]
        public string NombreLocal { get; set; }
    }
}