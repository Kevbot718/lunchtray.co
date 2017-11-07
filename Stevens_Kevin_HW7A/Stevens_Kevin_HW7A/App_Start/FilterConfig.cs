using System.Web;
using System.Web.Mvc;

namespace Stevens_Kevin_HW7A
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}