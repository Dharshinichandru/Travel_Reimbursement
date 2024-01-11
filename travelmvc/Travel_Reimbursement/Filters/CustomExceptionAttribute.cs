using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionFilter.Filters{
public class CustomExceptionfilter: ActionFilterAttribute,IExceptionFilter
{  
    public void OnException(ExceptionContext filterContext)   
    {  
        Exception error=filterContext.Exception;
        filterContext.ExceptionHandled=true;
        filterContext.Result=new ViewResult()
        {
            ViewName="Error"
        };
    }  
} 
}


