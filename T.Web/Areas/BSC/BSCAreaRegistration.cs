using System.Web.Mvc;

namespace T.Web.Areas.BSC
{
    public class BSCAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BSC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BSC_default",
                "BSC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}