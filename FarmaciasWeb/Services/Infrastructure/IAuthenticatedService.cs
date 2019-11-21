using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciasWeb.Services
{
    public interface IAuthenticatedService
    {
        IFarmaciasApiAuthenticator MessageAuthenticator { get; set; }
    }
}