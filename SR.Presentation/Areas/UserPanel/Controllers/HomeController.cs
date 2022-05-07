
﻿using SR.Application;
using SR.Application.Contract.User;

using System.Web.Mvc;

namespace SR.Presentation.Areas.UserPanel.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        //[Authorize]


        private readonly IUserApplication _userApplication;
        public HomeController()
        {

            _userApplication = new UserApplication();
        }
        public ActionResult Index()
        {
           
            ;
            var userId = int.Parse(User.Identity.Name);
            FullEditUser userInfo = _userApplication.GetDetails(userId).Result;
            return View(userInfo);
        }

        [HttpGet]
        public ActionResult EditUserInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditUserInfo(string name)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            var userId = int.Parse(User.Identity.Name);
            var result = _userApplication.ChangePassword(userId, command);
            if (result.IsSuccess == false)
            {
                ModelState.AddModelError("", result.Message);
                return View(command);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult IsAdminPartial()
        {
            var userId = int.Parse(User.Identity.Name);
            var result = _userApplication.GetDetails(userId);
            if (result.IsSuccess == true && result.Result.IsAdmin)
            {
                ViewBag.IsAdmin = true;
            }
            return PartialView("_IsAdminPartial");
        }

    }
}