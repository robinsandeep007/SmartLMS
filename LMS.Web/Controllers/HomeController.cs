using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LMS.Web.Models;
using LMS.Data;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using LMS.Data.Models;
using LMS.Service;

namespace LMS.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserServices _userServices;

        public HomeController(IUserServices userServices)
        {
            _userServices = userServices;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel userAccount)
        {
            if (ModelState.IsValid)
            {
                userAccount.userId = Guid.NewGuid();
                userAccount.createdDate = DateTime.Now;
                userAccount.status = true;
                users userdto = Mapper.Map<UserModel, users>(userAccount);
                _userServices.Add(userdto);
                ViewBag.Message = userAccount.username + "Successfully Registered.";
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userAccount)
        {
           
            if (ModelState.IsValid)
            {
                users userdto = AutoMapper.Mapper.Map<UserModel, users>(userAccount);
                var user = _userServices.Login(userdto);
                if (user != null)
                {
                    if (user.password == user.password)
                    {
                        HttpContext.Session.SetString("userID", user.userId.ToString());
                        HttpContext.Session.SetString("username", user.username.ToString());
                        ViewBag.Message = "Welcome Registered.";
                    }
                    else
                    ModelState.AddModelError("", "Password is wrong.");
                }
                else
                {
                    ModelState.AddModelError("", "username or password is wrong.");
                }

            }
            return View();
        }


        public ActionResult Welcome()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userID")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }

        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
