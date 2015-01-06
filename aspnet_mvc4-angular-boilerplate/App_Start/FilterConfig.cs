using System.Web;
using System.Web.Mvc;

namespace aspnet_mvc4_angular_boilerplate
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}