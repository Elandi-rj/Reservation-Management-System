using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace T1RMSWS.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize(Roles = "Staff,Manager")]
    public class StaffAreaController : Controller
    {

    }
}