using System.Web.Mvc;

namespace InventoryManager.Areas.Management
{
    public class ManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Management";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Management_default",
                "Management/{controller}/{action}/{id}",
                new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}