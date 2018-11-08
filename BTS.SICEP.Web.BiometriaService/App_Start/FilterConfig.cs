using System.Web;
using System.Web.Mvc;

namespace BTS.SICEP.Web.BiometriaService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
