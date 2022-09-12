using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PNRAnalysisSystem.Models;
using PNRAnalysisSystem.Service;
using System.Threading.Tasks;
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

    #region 座位查詢
        public IActionResult SFlightPassenger()
        {
            return View();
        }
        public IActionResult ListSFlightPassenger(string flightno,string flightdate)
        {
            var dtIso8601Start = Convert.ToDateTime(flightdate).ToString("yyyy-MM-dd\\THH:mm:ss\\Z");
            var dtIso8601End = Convert.ToDateTime(flightdate).AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyy-MM-dd\\THH:mm:ss\\Z");
           

            string Domain = "http://172.16.1.101:8080";
            string Route = "/seat";

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };
            var param = new Dictionary<string, string>()
            {
                {"flightNo",flightno},
                {"startedFlightDate",dtIso8601Start},
                {"endedFlightDate",dtIso8601End}
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;
            JArray jarray = _ServiceHttp.HttpGet(param, dic);

            var res = jarray.ToObject<List<SFlightPassenger>>();

            ViewData["flightDate"] = dtIso8601Start;

            return View(res);
        }
        public IActionResult SFlightPassenger_View(string flightno, string name, string seatNo, string flightdate)
        {
            var dtIso8601 = Convert.ToDateTime(flightdate).ToString("yyyy-MM-dd\\THH:mm:ss\\Z");

            string Domain = "http://172.16.1.101:8080";
            string Route = "/seat/"+ flightno+"/"+ seatNo;

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };
            var param = new Dictionary<string, string>()
            {
                {"flightDate",dtIso8601 }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;
            JArray jarray = _ServiceHttp.HttpGet(param, dic);

            var res = jarray.ToObject<List<SFlightPassenger_View>>();

            ViewData["flightno"] = flightno;
            ViewData["seat"] = seatNo;
            ViewData["name"] = name;

            return View(res);
        }
        #endregion

    #region 多國籍旅客
        public IActionResult Multinational()
        {
            return View();
        }   
        public IActionResult ListMultinational(string passengerSeqNo,string enName,string birthdate)
        {
            string Domain = "http://172.16.1.101:8080";
            string Route = "/chinese/multi-nation";

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };
            var param = new Dictionary<string, string>()
            {
                {"startedDate","2022-01-08T14:23:06.791Z" },
                {"endedDate","2022-09-08T14:23:06.791Z" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;
            JArray jarray = _ServiceHttp.HttpGet(param, dic);

            var res = jarray.ToObject<List<MultinationalModel>>();

            return View(res);
        }
    #endregion

        public IActionResult OutNotBack()
        {
            return View();
        }
        public IActionResult ListOutNotBack()
        {
            return View();
        }

        public IActionResult SameFlightPassenger()
        {
            return View();
        }
        public IActionResult ListSameFlightPassenger(string flightno)
        {
            //var dtStart = Convert.ToDateTime(flightdate);

            string Domain = "http://172.16.1.101:8080";
            string Route = "/sameFlight/tasks";

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;

            JArray jarray = _ServiceHttp.HttpGet(null, dic);

            var res = jarray.ToObject<List<SameFlightTask>>();

            return View(res);
        }
        public IActionResult SameFlightPassenger_View(string taskId)
        {
            string Domain = "http://172.16.1.101:8080";
            string Route = "/sameFlight/tasks/" + taskId;

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;
            JToken obj = _ServiceHttp.HttpGet(null, dic);


            List<SameFlightTask_View> list = new List<SameFlightTask_View>();

            foreach (var item in obj)
            {
                SameFlightTask_View ent = new SameFlightTask_View();

                var a = item.Children()[0].Children();
            }
            

            return View();
        }

        public IActionResult MutiSameFlightPassenger()
        {
            return View();
        }
        public IActionResult ListMutiSameFlightPassenger()
        {
            return View();
        }

        public IActionResult OutLongerIn()
        {
            return View();
        }
        public IActionResult ListOutLongerIn()
        {
            return View();
        }

        public IActionResult HumanTrafficker()
        {
            return View();
        }
        public IActionResult TimeRisk()
        {
            return View();
        }

    #region 頻密風險
        public IActionResult HighFreqQuery()
        {
            return View();
        }
        public IActionResult ListHighFreqQuery(string nation,string inTimes, string flightdate)
        {
            var dtStart = Convert.ToDateTime(flightdate);

            string Domain = "http://172.16.1.101:8080";
            string Route = "/frequency/tasks";

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;

            JArray jarray = _ServiceHttp.HttpGet(null, dic);

            var res = jarray.ToObject<List<HighFreqQueryModel>>();

            if(!string.IsNullOrEmpty(nation) && res != null )
            {
                res = res.Where(x => x.nation == nation).ToList();
            }
            if (!string.IsNullOrEmpty(inTimes) && res != null)
            {
                res = res.Where(x => x.numberOfEntries == inTimes).ToList();
            }
            if (!string.IsNullOrEmpty(flightdate) && res != null)
            {
                res = res.Where(x=>Convert.ToDateTime(x.startedDate) >= dtStart).ToList();
            }

            return View(res);
        }
        public IActionResult HighFreqQuery_View(string taskId)
        {
            string Domain = "http://172.16.1.101:8080";
            string Route = "/frequency/tasks/" + taskId;

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;
            JArray jarray = _ServiceHttp.HttpGet(null, dic);

            var res = jarray.ToObject<List<HighFreqQueryViewModel>>();

            return View(res);
        }
        [HttpPost]
        public JsonResult HighFreqQuery_Del(string taskid)
        {
            string Domain = "http://172.16.1.101:8080";
            string Route = "/frequency/tasks/" + taskid;

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;

            var res = _ServiceHttp.HttpDelete(null, dic);

            return Json(new { msg = "success" });
        }
        [HttpPost]
        public JsonResult HighFreqQuery_Add()
        {
            string Domain = "http://172.16.1.101:8080";
            string Route = "/frequency/batch";

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;

            var res = _ServiceHttp.HttpPost(null, dic);

            return Json(new { msg = "success" });
        }
    #endregion

    #region 行李風險
        public IActionResult Luggage()
        {
            return View();
        }
        public IActionResult ListLuggage(string inout,string luggagewt,string flightdate)
        {
            var dtIso8601Start = Convert.ToDateTime(flightdate);
            var dtIso8601End = Convert.ToDateTime(flightdate).AddMonths(6).AddHours(23).AddMinutes(59).AddSeconds(59);

            string Domain = "http://172.16.1.101:8080";
            string Route = "/luggage/tasks";

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;
            JArray jarray = _ServiceHttp.HttpGet(null, dic);

            var res = jarray.ToObject<List<LuggageModel>>();

            if(!string.IsNullOrWhiteSpace(luggagewt) && res !=null)
            {
                res = res.Where(x => x.luggageWeight == luggagewt).ToList();
            }
            if(!string.IsNullOrEmpty(flightdate) && res != null)
            {
                res = res.Where(x => Convert.ToDateTime(x.startedDate) > dtIso8601Start && Convert.ToDateTime(x.endedDate) < dtIso8601End).ToList();
            }

            return View(res);
        }
        public IActionResult Luggage_View(string taskId)
        {
            string Domain = "http://172.16.1.101:8080";
            string Route = "/luggage/tasks/"+ taskId;

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;
            JArray jarray = _ServiceHttp.HttpGet(null, dic);

            var res = jarray.ToObject<List<LuggageViewModel>>();

            return View(res);
        }
        [HttpPost]
        public JsonResult Luggage_Del(string taskid)
        {
            string Domain = "http://172.16.1.101:8080";
            string Route = "/luggage/tasks/" + taskid;

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;

            var res = _ServiceHttp.HttpDelete(null, dic);

            return Json(new { msg = "success" });
        }
        [HttpPost]
        public JsonResult Luggage_Add()
        {
            string Domain = "http://172.16.1.101:8080";
            string Route = "/luggage/batch";

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "TEST" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;

            var res = _ServiceHttp.HttpPost(null, dic);

            return Json(new { msg = "success" });
        }
    #endregion

    }
}
