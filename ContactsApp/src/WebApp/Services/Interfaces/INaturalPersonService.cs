using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using static WebApp.Services.Interfaces.Base.IPersonService;

namespace WebApp.Services.Interfaces
{
    public interface INaturalPersonService : IPersonService<NaturalPersonModel>
    {
    }
}
