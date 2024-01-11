using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Travel_Reimbursement.Filters;
using Travel_Reimbursement.Models;

public class CustomAuthorizeFilter : Attribute,IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.Session.GetObjectFromJson<ManagerLoginModel>("users");
        if (user == null)
        {
            Console.WriteLine("Error: users is null");
            context.Result = new RedirectToActionResult("LoginManager", "ManagerAccount", null);
            return;
        }
        Console.WriteLine($"users: {JsonConvert.SerializeObject(user)}");
    }
}