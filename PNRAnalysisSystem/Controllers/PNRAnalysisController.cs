using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PNRAnalysisSystem.Service;
using static PNRAnalysisSystem.Models.PNRModel;

namespace PNRAnalysisSystem.Controllers
{
    public class PNRAnalysisController : Controller
    {
        public readonly ServiceHttp _ServiceHttp;

        public PNRAnalysisController()
        {
            _ServiceHttp = new ServiceHttp();
        }

        public IActionResult SFlightPassenger()
        {
            return View();
        }
        public IActionResult ListSFlightPassenger(string flightno,string flightdate)
        {
            string Domain = "http://172.16.1.101:8080";
            string Route = "/seat";

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };
            var param = new Dictionary<string, string>()
            {
                {"flightNo",flightno},//"CX474" 
                {"startedFlightDate","2022-03-01T00:00:00" },
                {"endedFlightDate","2022-06-30T00:00:00" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;
            JArray jarray = _ServiceHttp.HttpGet(param, dic);

            var res = jarray.ToObject<List<SFlightPassenger>>();

            return View(res);
        }
        public IActionResult Multinational()
        {
            return View();
        }   
        public IActionResult ListMultinational()
        {
            return View();
        }

        public IActionResult OutNotBack()
        {
            return View();
        }
        public IActionResult ListOutNotBack()
        {
            return View();
        }
    }
}
