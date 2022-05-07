using System.Web.Mvc;

namespace SR.Presentation.Areas.UserPanel
{
    public class UserPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UserPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UserPanel_default",
                "UserPanel/{controller}/{action}/{id}",
<<<<<<< HEAD
                new { action = "Index", id = UrlParameter.Optional }
=======
                new { action = "Index", id = UrlParameter.Optional },
                 new[] { "SR.Presentation.Areas.UserPanel.Controllers" }
>>>>>>> 9bcbc77864788fe59e4466b492a52298ee846da4
            );
        }
    }
}