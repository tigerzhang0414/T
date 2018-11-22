using System.Web.Mvc;

namespace T.Web.Areas.ADM
{
    public class ADMAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ADM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ADM_default",
                "ADM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}