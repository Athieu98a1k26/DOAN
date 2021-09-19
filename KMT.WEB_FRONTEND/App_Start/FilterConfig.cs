using System.Web;
using System.Web.Mvc;

namespace KMT.WEB_FRONTEND
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
