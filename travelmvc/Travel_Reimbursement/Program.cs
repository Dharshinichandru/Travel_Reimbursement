using Travel_Reimbursement.ContextDBConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Travel_Reimbursement.Models;
using Microsoft.AspNetCore.Identity;
using Travel_Reimbursement.Filters;
using ExceptionFilter.Filters;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var DefaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Travel_ReimbursementDbContext>(options=>
options.UseSqlServer(DefaultConnection));

builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<Travel_ReimbursementDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(op=> op.LoginPath="/UserAuthentication/Login");


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddMvc().AddSessionStateTempDataProvider();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=>
{
options.ExpireTimeSpan=TimeSpan.FromMinutes(60*1);
options.LoginPath="/Accounts/Login";
options.AccessDeniedPath="/Accounts/Login";
});

builder.Services.AddSession(options=>
{
    options.IdleTimeout=TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly=true;
    options.Cookie.IsEssential=true;
});
// builder.Services.AddControllers(options =>
// {
//     options.Filters.Add(new CustomExceptionfilter());
// });


builder.Services.AddControllers(Options =>
 {
    Options.Filters.Add(new Filter());
 });

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
    //UseStatusCodePagesWithReExecute
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// app.UseMvc();

app.Run();
