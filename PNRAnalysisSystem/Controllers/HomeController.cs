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

        private readonly UserDao _UserDao;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            _UserDao = new UserDao();
        }

        public IActionResult Index()
        {
            var list = new UserDao().GetFunctionList(1);

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