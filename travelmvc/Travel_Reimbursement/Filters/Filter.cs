using Microsoft.AspNetCore.Mvc.Filters;

namespace Travel_Reimbursement.Filters
{
   // [AttributeUsage(AttributeTargets.Method)]
    public class Filter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("ONaction executed");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
             Console.WriteLine("ONaction executing");
        }
    }
}