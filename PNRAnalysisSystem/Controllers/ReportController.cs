using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Web;
using PNRAnalysisSystem.Service;

namespace PNRAnalysisSystem.Controllers
{
    public class ReportController : Controller
    {
        public readonly  ServiceHttp _ServiceHttp;
        public ReportController()
        {
            _ServiceHttp = new ServiceHttp();
        }
        public IActionResult DemoReport()
        {
            return View();
        }
        public IActionResult DemoTest()
        {
            return View();
        }

        public IActionResult DemoReport_Detail()
        {
            return View();
        }
        public IActionResult DemoDashboard()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetTest(string str)
        {
            string Domain = "http://172.16.1.101:8080";
            string Route = "/sameFlight/tasks";

            var dic = new Dictionary<string, string>()
            {
                {"agent-id", "HYTEST01" }
            };

            _ServiceHttp.Domain = Domain;
            _ServiceHttp.Route = Route;
            JArray jarray = _ServiceHttp.HttpGet(new KeyValuePair<string, string>(), dic);

            var res = jarray.ToObject<List<SameFlightTask>>();

            return Json(new { msg = "Success" });
        }

        public class SameFlightTask
        {
            public string taskId { get; set; }
            public string agentId { get; set; }
            public string agentName { get; set; }
            public string batchStartedTime { get; set; }
            public string batchEndedTime { get; set; }
            public string status { get; set; }
            public string comparisonStatus { get; set; }
            public string startedDate { get; set; }
            public string endedDate { get; set; }
            public List<SameFlightTask_Passengers> Passengers { get; set; }
        }
        public class SameFlightTask_Passengers
        {
            public string dateOfBirth { get; set; }
            public string ename { get; set; }
        }
    }
}
