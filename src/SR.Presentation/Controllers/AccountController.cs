using SR.Application.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SR.Application;
using System.Web.Security;
using SR.Application.Contract.Organization;

namespace SR.Presentation.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserApplication _userApplication;
        private readonly IOrganizationApplication _organizationApplication;
        public AccountController()
        {
            _userApplication=new UserApplication();
            _organizationApplication = new OrganizationApplication();
        }
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            ViewBag.Organization = new SelectList(_organizationApplication.GetAll(), "Id", "Code");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser command,string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.returnUrl = returnUrl;
                ViewBag.Organization = new SelectList(_organizationApplication.GetAll(), "Id", "Code");
                return View(command);
            }
            var result = _userApplication.LoginUser(command);

            if (result.IsSuccess == false)
            {
                ViewBag.returnUrl = returnUrl;
                ViewBag.Organization = new SelectList(_organizationApplication.GetAll(), "Id", "Code");
                ModelState.AddModelError("", result.Message);
                return View(command);
            }
            var user = result.Result;
            var cookie = user.Id.ToString() + "|" + user.Code; ;
            FormsAuthentication.SetAuthCookie(cookie, true);

            if (string.IsNullOrEmpty(returnUrl))
            {
                return Redirect("/UserPanel/Home/Index");

            }
            return Redirect(returnUrl);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }
}