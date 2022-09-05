using System.Web;
using System.Web.Mvc;

namespace _220904_StefhannyaForeroG
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
