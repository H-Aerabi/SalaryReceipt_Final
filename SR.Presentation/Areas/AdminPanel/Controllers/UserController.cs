using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SR.Application.Contract;
using SR.Application;
using SR.Application.Contract.User;
using SR.Application.Contract.Organization;
using SR.Presentation.Security;

namespace SR.Presentation.Areas.AdminPanel.Controllers
{
    [CheckIsAdmin]
    public class UserController : Controller
    {
        private readonly IUserApplication _userApplication;
        private readonly IOrganizationApplication _organizationApplication;
        public UserController()
        {
            _userApplication = new UserApplication();
            _organizationApplication=new OrganizationApplication();
        }


        public ActionResult Index()
        {
            var users = _userApplication.GetAll();
            return View(users);
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            var organizations = _organizationApplication.GetAll();
            ViewBag.Organizations = new SelectList(organizations, "Id", "Name");
            
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(CreateUser command)
        {
           

            if (!ModelState.IsValid)
            {
                var organizations = _organizationApplication.GetAll();
                ViewBag.Organizations = new SelectList(organizations, "Id", "Name");
                return View(command);
            }
          var result=  _userApplication.Create(command);
            if (result.IsSuccess == true)
            {

                return RedirectToAction("Index");

            }
            else
            {
                var organizations = _organizationApplication.GetAll();
                ViewBag.Organizations = new SelectList(organizations, "Id", "Name");
                ModelState.AddModelError("", result.Message);
                return View(command);
            }
        }

        [HttpGet]
        public ActionResult EditUser(int id) {
            var organizations = _organizationApplication.GetAll();
            ViewBag.Organizations = new SelectList(organizations, "Id", "Name");

            var result = _userApplication.GetDetails(id);
            if (result.IsSuccess == true)
            {
                var user = result.Result;
                return View(user);
            }
            else
            {
                return HttpNotFound();
            }
            
        }
        [HttpPost]
        public ActionResult EditUser(FullEditUser command)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Organizations = _organizationApplication.GetAll();
                return View(command);
            }

            var result = _userApplication.Edit(command);

            if (result.IsSuccess)
            {
                return RedirectToAction("index");

            }

            ModelState.AddModelError("", result.Message);
            var organizations = _organizationApplication.GetAll();
            ViewBag.Organizations = new SelectList(organizations, "Id", "Name");
            return View(command);

        }

    }
}