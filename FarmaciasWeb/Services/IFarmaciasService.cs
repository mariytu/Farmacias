using System.Collections.Generic;
using System.Threading.Tasks;
using FarmaciasCore.DTO;

namespace FarmaciasWeb.Services
{
    public interface IFarmaciasService : IAuthenticatedService
    {
        Task<IEnumerable<FarmaciasDTO>> GetPorComunaLocal(string comuna, string local);
        Task<IEnumerable<FarmaciasDTO>> GetPorComunaIdLocal(int comunaId, string local);
    }
}