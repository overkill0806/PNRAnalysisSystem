using Microsoft.AspNetCore.Mvc;

namespace PNRAnalysisSystem.Controllers
{
    public class SystemManageController : Controller
    {
        public IActionResult AccountManage()
        {
            return View();
        }
    }
}
