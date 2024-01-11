using Microsoft.AspNetCore.Mvc.Filters;

namespace Travel_Reimbursement.ActionFilters
{
    public class LogAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //RouteData object contains information about the current route, including the controller and action names.
            Log("OnActionExecuted",context.RouteData);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Log("OnActionExecuting",context.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Log("OnResultExecuted",context.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Log("OnResultExecuting",context.RouteData);
        }

       //Log method retrieves the controller and action name from routedata
        private void Log(string methodName, RouteData routeData)
        {
            var controllerName=routeData.Values["controller"];
            var actionName=routeData.Values["action"];
            var message =String.Format("{0}-controller:{1} action:{2}",methodName,controllerName,actionName);

            Console.WriteLine(message);
        }
    }
}