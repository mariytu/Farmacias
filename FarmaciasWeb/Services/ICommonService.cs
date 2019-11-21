using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmaciasWeb.Services
{
    public interface ICommonService : IAuthenticatedService
    {
        Task<string> GetComunasRM();
    }
}