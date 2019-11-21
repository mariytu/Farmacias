using FarmaciasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciasCore.DTO
{
    public class FarmaciasDTO
    {
        public string NombreLocal { get; set; }
        public string DireccionLocal { get; set; }
        public string TelefonoLocal { get; set; }
        public Ubicacion UbicacionLocal { get; set; }

        public FarmaciasDTO() { }

        public FarmaciasDTO(FarmaciasDTO farmacia)
        {
            this.NombreLocal = farmacia.NombreLocal;
            this.DireccionLocal = farmacia.DireccionLocal;
            this.TelefonoLocal = farmacia.TelefonoLocal;
            this.UbicacionLocal = farmacia.UbicacionLocal;
        }

        public FarmaciasDTO(Farmacias farmacia)
        {
            this.NombreLocal = farmacia.LocalNombre ?? "";
            this.DireccionLocal = farmacia.LocalDireccion ?? "";
            this.TelefonoLocal = farmacia.LocalTelefono ?? "";
            this.UbicacionLocal = farmacia.LocalLat.HasValue && farmacia.LocalLng.HasValue ? new Ubicacion() { Lat = farmacia.LocalLat.Value, Lng = farmacia.LocalLng.Value } : null;
        }
    }

    public class Ubicacion
    {
        public float Lat { get; set; }
        public float Lng { get; set; }
    }
}