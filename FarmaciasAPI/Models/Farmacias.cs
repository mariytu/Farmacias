using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciasAPI.Models
{
    public class Farmacias
    {
        [JsonProperty("fecha")]
        public string Fecha { get; set; }

        [JsonProperty("local_id")]
        public int LocalId { get; set; }

        [JsonProperty("local_nombre")]
        public string LocalNombre { get; set; }

        [JsonProperty("comuna_nombre")]
        public string ComunaNombre { get; set; }

        [JsonProperty("localidad_nombre")]
        public string LocalidadNombre { get; set; }

        [JsonProperty("local_direccion")]
        public string LocalDireccion { get; set; }

        [JsonProperty("funcionamiento_hora_apertura")]
        public string HoraApertura { get; set; }

        [JsonProperty("funcionamiento_hora_cierre")]
        public string HoraCierre { get; set; }

        [JsonProperty("loca_telefono")]
        public string LocalTelefono { get; set; }

        [JsonProperty("local_lat")]
        public float? LocalLat { get; set; }

        [JsonProperty("local_lng")]
        public float? LocalLng { get; set; }

        [JsonProperty("funcionamiento_dia")]
        public string FuncionamientoDia { get; set; }

        [JsonProperty("fk_region")]
        public int RegionFK { get; set; }

        [JsonProperty("fk_comuna")]
        public int ComunaFK { get; set; }
    }
}
