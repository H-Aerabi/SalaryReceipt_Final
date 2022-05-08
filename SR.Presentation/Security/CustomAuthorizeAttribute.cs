using SR.Application;
using SR.Application.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SR.Presentation.Security
{
    
        public class CheckIsAdminAttribute : AuthorizeAttribute
        {
        private readonly IUserApplication _userApplication;

        public CheckIsAdminAttribute()
        {
            _userApplication = new UserApplication();

        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
            {

                bool authorize = false;
                if (httpContext.User.Identity.IsAuthenticated)
                {
                    int userId  = int.Parse(httpContext.User.Identity.Name);


                    bool isAdmin;

                isAdmin = _userApplication.GetDetails(userId).Result.IsAdmin;


                    if (isAdmin)
                    {

                        authorize = true;

                    }

                }
                else
                {
                    authorize = false;
                }



                return authorize;
            }

            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                base.HandleUnauthorizedRequest(filterContext);

            }
        }
    }
