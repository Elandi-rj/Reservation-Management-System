using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace T1RMSWS.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Manager")]
    public class ManagementAreaController : Controller
    {
        
    }
}