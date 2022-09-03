using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using PNRAnalysisSystem.Dao;
using PNRAnalysisSystem.Models;

namespace PNRAnalysisSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Default()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}