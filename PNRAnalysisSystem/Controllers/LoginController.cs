using Microsoft.AspNetCore.Mvc;
using Utility;
using PNRAnalysisSystem.Dao;

namespace PNRAnalysisSystem.Controllers
{
    public class LoginController : Controller
    {
        public UserDao _UserDao { get; set; }
        public LoginController()
        {
            _UserDao = new UserDao();
        }
        public IActionResult Index(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                ViewBag.Msg = msg;
            }

            return View();
        }

        public IActionResult Login(string accountid, string pwd)
        {
            if(!string.IsNullOrWhiteSpace(accountid) && !string.IsNullOrWhiteSpace(pwd))
            {
                if (_UserDao.IsValidLogin(accountid, pwd))
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", new { msg = "Fail Login" });
        }
    }
}
