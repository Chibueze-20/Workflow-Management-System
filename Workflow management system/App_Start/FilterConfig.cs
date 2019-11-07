using System.Web;
using System.Web.Mvc;

namespace Workflow_management_system
{
     public class FilterConfig
     {
          public static void RegisterGlobalFilters(GlobalFilterCollection filters)
          {
               filters.Add(new HandleErrorAttribute());
          }
     }
}
