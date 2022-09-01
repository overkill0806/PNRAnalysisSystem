using Microsoft.AspNetCore.Mvc;
using PNRAnalysisSystem.Models;

namespace PNRAnalysisSystem.Controllers
{
    public class PNRAnalysisController : Controller
    {
        public IActionResult SFlightPassenger()
        {
            return View();
        }
        public IActionResult ListSFlightPassenger()
        {
            //var list = new List<SFlightPassengerModel>();

            return View();
        }
        public IActionResult Multinational()
        {
            return View();
        }   
        public IActionResult ListMultinational()
        {
            return View();
        }
    }
}
