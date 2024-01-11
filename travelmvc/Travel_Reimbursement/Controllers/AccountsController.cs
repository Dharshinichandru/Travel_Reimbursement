using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Travel_Reimbursement.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Identity;
using Travel_Reimbursement.ContextDBConfig;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Travel_Reimbursement.ActionFilters;
using Message=System.Console;

namespace Travel_Reimbursement.Controllers;

[Log]
public class AccountsController : Controller
{
    private readonly UserManager<ApplicationUser>? _userManager;
    private readonly SignInManager<ApplicationUser>? _signInManager;
    public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel login, string? returlUrl)
    {
        if(ModelState.IsValid)
        {
            
            var result=await _signInManager.PasswordSignInAsync(login.Email, login.Password,false,false);
            if(result.Succeeded)
            {
                if(!string.IsNullOrEmpty(returlUrl))
                return LocalRedirect(returlUrl);
                return RedirectToAction("Index","Details");
            }
            ModelState.AddModelError("","Invalid Login Attempt");
            
        }
        return View(login);
    }

      [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index","Home");
    }
     public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register( RegisterModel register)
    {
        if(ModelState.IsValid)
        {
            var user = new ApplicationUser()
            {
                Name=register.Name,
                Email=register.Email,
                UserName=register.Email
            };
            var result = await _userManager.CreateAsync(user,register.Password);
            if(result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(user, register.Password,false,false);
                return RedirectToAction("Index","Home");
            }
            else
            {
                foreach(var err in result.Errors)
                {
                   // ModelState.AddModelError("",err.Description);
                   Message.WriteLine("",err.Description);
                }
            }
        }
        return View(register);
    }
    

}