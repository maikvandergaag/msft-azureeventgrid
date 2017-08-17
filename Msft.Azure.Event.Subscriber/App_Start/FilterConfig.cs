using System.Web;
using System.Web.Mvc;

namespace Msft.Azure.Event.Subscriber {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new ErrorHandler.AiHandleErrorAttribute());
        }
    }
}
