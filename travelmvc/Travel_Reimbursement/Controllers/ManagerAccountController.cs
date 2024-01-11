using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Travel_Reimbursement.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

using Travel_Reimbursement.ContextDBConfig;
using Travel_Reimbursement.Models.Domain;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Travel_Reimbursement.Filters;


namespace Travel_Reimbursement.Controllers
{
    public class ManagerAccountController:Controller
    {
          private readonly Travel_ReimbursementDbContext _context;
          private readonly IWebHostEnvironment _hostEnvironment;

          // private ILogger<ManagerAccountController> _logger;
            
           
           public ManagerAccountController(Travel_ReimbursementDbContext context,IWebHostEnvironment hostEnvironment)
           {
           
            _context=context;
            _hostEnvironment=hostEnvironment;

           }
         
        [HttpGet]
        public IActionResult RegisterManager()
        {
                return View();         
        }
        
        [HttpPost]
        //[CustomAuthorizeFilter]
        public async Task<ActionResult> RegisterManagerAsync(ManagerRegisterModel register)
        {  
              if (ModelState.IsValid)  
            {  
                var data=new ManagerRegisterModel()
            {
                Username=register.Username,
                Password=register.Password,
                Confirmpassword=register.Confirmpassword,
                Email=register.Email,
                Mobilenumber=register.Mobilenumber,
            };
              await  _context.ManagerRegistertable.AddAsync(register);
              await  _context.SaveChangesAsync();
              TempData["successMessage"]="Please fill your credentials then login!";
               return RedirectToAction("LoginManager");
            }
            else
            {
                TempData["errorMessage"]="Try Again!";
                return View(register);    
            }
                 
            }
        
         [HttpGet]
          public IActionResult LoginManager()
        {
           
           return View();
        }

        [HttpPost]
      
        public ActionResult LoginManager(ManagerLoginModel login)
        {
            if (ModelState.IsValid)
            {
              //FirstorDefault methods to filter and retrieve the first matching record.
                var data = _context.ManagerRegistertable.Where(e => e.Username == login.Username).FirstOrDefault();
                if (data != null)
                {
                    bool isValid = (data.Username == login.Username && data.Password == login.Password);
                    if (isValid)
                    {
                      //Here stores the login object in the session with the key "users".It converts the login object to json format using the setobjectasjson extension method. 
                      HttpContext.Session.SetObjectAsJson("users", login);
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, login.Username) },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Username", login.Username);
                        return RedirectToAction("Index", "ManagerAccount");
                    }

                    else
                    {
                        TempData["errorPassword"] = "Invalid Password";
                        return View(login);
                    }
                }
                else
                {
                    TempData["errorUsername"] = "Username not found!";
                    return View(login);
                }
            }
            else
            {
                return View(login);
            }
        }
          [Authorize]
          //[CustomAuthorize]
        public IActionResult LogoutManager()
        {
          HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
          var storedcookies=Request.Cookies.Keys;
          foreach(var cookies in storedcookies)
          {
            Response.Cookies.Delete(cookies);
          }
           return RedirectToAction("Index","Home");
        }

         [HttpGet]
         [CustomAuthorizeFilter]
        public async Task<IActionResult> Index()
        {
            var table = await _context.Traveltable.ToListAsync();
            return View(table);
        }
          [HttpGet]
        public async Task<IActionResult> View(int? id,TravelModel travelModel)
        {
          string? tempEmail;
            var worker = await _context.Traveltable.FirstOrDefaultAsync(x=>x.Id==id);
            if(worker!=null)
            {
                var ViewModel=new UpdateTravelModel()
                
                {
                 tempEmail=worker.EmployeeEmail,
                    Id=worker.Id,
                    TravelId=worker.TravelId,
                    Passportnumber=worker.Passportnumber, 
                    Issue=worker.Issue,
                    ExpiryDate=worker.ExpiryDate,
                    Place=worker.Place,
                    PAN=worker.PAN,
                    Department=worker.Department,
                    Project=worker.Project,
                    Clientname=worker.Clientname,
                    Country=worker.Country,
                    Fromdate=worker.Fromdate,
                    Todate=worker.Todate,
                    NoofDays=worker.NoofDays,
                    Perdiem=worker.Perdiem,
                    Eligible=worker.Eligible,
                    Date=worker.Date,
                    Particularofexpenses=worker.Particularofexpenses,
                    Detailsofexpense =worker.Detailsofexpense,
                    Currency =worker.Currency,
                    Amount =worker.Amount,
                    Mode =worker.Mode,
                    EmployeeEmail=worker.EmployeeEmail,
                    Totalperdiem =worker.Totalperdiem,
                    Totalamount=worker.Totalamount,
                    Advanceamount=worker.Advanceamount,
                    Remarks=worker.Remarks
                };
                return await Task.Run(() => View("View",ViewModel));
                TempData["myData"]=tempEmail;
                 Console.WriteLine(tempEmail);
                
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateTravelModel model)
        {
          // string? tempEmail;
            var worker= await _context.Traveltable.FindAsync(model.Id);
            if(worker!=null)
            {
                // tempEmail=worker.EmployeeEmail;
                    worker.Id=worker.Id;
                    worker.TravelId=worker.TravelId;
                    worker.Passportnumber=worker.Passportnumber; 
                    worker.Issue=worker.Issue;
                    worker.ExpiryDate=worker.ExpiryDate;
                    worker.Place=worker.Place;
                    worker.PAN=worker.PAN;
                    worker.Department=worker.Department;
                    worker.Project=worker.Project;
                    worker.Clientname=worker.Clientname;
                    worker.Country=worker.Country;
                    worker.Fromdate=worker.Fromdate;
                    worker.Todate=worker.Todate;
                    worker.NoofDays=worker.NoofDays;
                    worker.Perdiem=worker.Perdiem;
                    worker.Eligible=worker.Eligible;
                    worker.Date=worker.Date;
                    worker.Particularofexpenses=worker.Particularofexpenses;
                    worker.Detailsofexpense =worker.Detailsofexpense;
                    worker.Currency =worker.Currency;
                    worker.Amount =worker.Amount;
                    worker.Mode =worker.Mode;
                    worker.EmployeeEmail=worker.EmployeeEmail;
                    worker.Totalperdiem =worker.Totalperdiem;
                    worker.Totalamount=worker.Totalamount;
                    worker.Advanceamount=worker.Advanceamount;
                    worker.Remarks=worker.Remarks;

                  await _context.SaveChangesAsync();
                //   TempData["myData"]=tempEmail;
                // TempData.Keep();
                // Console.WriteLine(tempEmail);

                  return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
    public async Task<IActionResult> IndexFile()
    {
       
        var uplo=await _context.Filetable.ToListAsync();
        return View(uplo);
    }
    public async Task<IActionResult> Filetable(int? id)
      {
        if(id==null)
        {
            return NotFound();
        }
        var fileModel = await _context.Filetable.FirstOrDefaultAsync(m=> m.ImageId == id);
        if(fileModel==null)
        {
            return NotFound();
        }
        return View(fileModel);
      }
      [HttpGet]
      public IActionResult Fileupload()
      {
        return View();
      }
       [HttpPost]
      //[ValidateAntiForgeryToken]
      public async Task<IActionResult> Fileupload([Bind("ImageId,Title,ImageFile")] FileModel fileModel)
      {
        if(ModelState.IsValid)
        {
          try{
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(fileModel.ImageFile.FileName);
            string extension = Path.GetExtension(fileModel.ImageFile.FileName);
            fileModel.ImagePath=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path=Path.Combine(wwwRootPath+"/Image/", fileName);
            using (var fileStream = new FileStream(path,FileMode.Create))
            {
                await fileModel.ImageFile.CopyToAsync(fileStream);
            }

            _context.Add(fileModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("IndexFile");

          }
          catch(Exception exception)
                {
                    ModelState.AddModelError(string.Empty,$"Something went wrong {exception.Message}");
                }
            }
            ModelState.AddModelError(string.Empty,$"Something went wrong invalid model");
            return View(fileModel);
            
        
      }
     
     public async Task<IActionResult> DeleteFile(int? id)
        {
          if(id==null)
          {
            return NotFound();
          }
          var fileModel= await _context.Filetable.FirstOrDefaultAsync(m=>m.ImageId==id);
          if(fileModel==null)
          {
            return NotFound();
          }
          return View(fileModel);
        }
        [HttpPost, ActionName("DeleteFile")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          var fileModel=await _context.Filetable.FindAsync(id);

          var imagePath=Path.Combine(_hostEnvironment.WebRootPath,"image",fileModel.ImagePath);
          if(System.IO.File.Exists(imagePath))
             System.IO.File.Delete(imagePath);


          _context.Filetable.Remove(fileModel);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(IndexFile));
        }

        private bool FileModelExists(int id)
        {
          return _context.Filetable.Any(e => e.ImageId==id);
        }
        [HttpGet]
        public async Task<IActionResult> Approve(int id,TravelModel travelModel)
        {
           string? myData=TempData["myData"] as string;
           TempData.Keep("myData");
          if(_context.Traveltable!=null){
        var employees = await _context.Traveltable.Where(x => x.Id == id).FirstOrDefaultAsync();
        return View(employees);
        }
        return View();
        }
         [HttpGet]
        public async Task<IActionResult> Decline(int id,TravelModel travelModel)
        {
           string? myData=TempData["myData"] as string;
            TempData.Keep("myData");
          if(_context.Traveltable!=null){
        var employees = await _context.Traveltable.Where(x => x.Id == id).FirstOrDefaultAsync();
        return View(employees);
        }
        return View();
        }


        // [HttpPost]
         public async Task<IActionResult> Approve(TravelModel travelModel)
        {

          
                            string from, pass, messageBody;
                            string? myData=TempData["myData"] as string;
                            Console.WriteLine(myData);
                            MailMessage message = new MailMessage();
                            from = "gayathri1212200@gmail.com";
                            pass = "ayvlczdpqrzbdvjl";
                           string? tempemail="gayuraji1212@gmail.com";
                            messageBody = "Your Request has been Accepted";
                            message.To.Add(new MailAddress(tempemail));
                            // if(travelModel.EmployeeEmail != null)
                            // {
                            //     message.To.Add(new MailAddress(travelModel.EmployeeEmail ));
                            //     message.To.Add(new MailAddress(tempemail));
                            // }
                            //  else
                            //  {
                            //      throw new Exception("User email is null or invalid.");
                            //  }
                            message.From = new MailAddress(from);
                            message.Body = messageBody;
                            message.Subject = "Regarding Travel Details Accepted ";
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                            smtp.EnableSsl = true;
                            smtp.Port = 587;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.UseDefaultCredentials = false;
                            smtp.EnableSsl = true;
                            smtp.Credentials = new NetworkCredential(from, pass);                  
                            smtp.Send(message);
            //     }

            // }
          //  await  _context.SaveChangesAsync();
            return View();
        }

        // [HttpPost]
         public async Task<IActionResult> Decline(TravelModel travelModel)
        {
          //  var employees= await _context.Traveltable.FindAsync(travelModel.Id);
          //   if(employees!=null)
          //   {
          //     employees.ValidateRequest="Approved";
          //      string ? myData =TempData["reqemail"] as string; 
          //       if(myData!=null)
          //       {
          //                   string temp_email = myData;
          //                   Console.WriteLine(myData);
          //                   TempData["email"] =travelModel.EmployeeEmail;
                            string from, pass, messageBody;
                            MailMessage message = new MailMessage();
                            from = "gayathri1212200@gmail.com";
                            pass = "ayvlczdpqrzbdvjl";
                            string? tempemail="gayuraji1212@gmail.com";
                            messageBody = "Your Request has been Declined";
                            message.To.Add(new MailAddress(tempemail));
                            message.From = new MailAddress(from);
                            message.Body = messageBody;
                            message.Subject = "Regarding Travel Details Declined";
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                            smtp.EnableSsl = true;
                            smtp.Port = 587;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.UseDefaultCredentials = false;
                            smtp.EnableSsl = true;
                            smtp.Credentials = new NetworkCredential(from, pass);                  
                            smtp.Send(message);
            //     }

            // }
          //  await  _context.SaveChangesAsync();
            return View();
        }




     

    //  public IActionResult GetImage(int id)
    // {
    //     var fileModel =  _context.Filetable.FirstOrDefaultAsync(m=> m.ImageId == id);
    //   //  var employee = _context.Employee_Details.FirstOrDefault(e => e.employee_id == id);
    //     if (fileModel != null && fileModel.employee_Image != null)
    //     {
    //         return File(employee.employee_Image, "image/jpeg"); // adjust the content type to match your image type
    //     }
    //     return NotFound();
    // }
    // [HttpGet]
    
    // public async Task<IActionResult> EditEmployeeE(Employee employee)
    // {
    //     string ? myData = TempData["EmpId"] as String;
    //     TempData.Keep("EmpId");
    //     employee.employee_id=Convert.ToInt16(myData);
    //     if(_dbContext.Employee_Details!=null){
    //     var employees = await _dbContext.Employee_Details.Where(x => x.employee_id == employee.employee_id ).FirstOrDefaultAsync();
    //     return View(employees);
    //     }
    //     return View();
    // }
    // [HttpPost]
    // [CustomAuthorizeE]
    // public async Task<IActionResult> EditEmployeeE(Employee employee, IFormFile image1)
    // {
    //     string myData = TempData["EmpId"] as string;
    //     TempData.Keep("EmpId");
    //     employee.employee_id = Convert.ToInt16(myData);

    //     if (ModelState.IsValid)
    //     {
    //         try
    //         {
    //             if(_dbContext.Employee_Details!=null){
    //             var employees = await _dbContext.Employee_Details.FindAsync(employee.employee_id);
    //             if (employees != null)
    //             {
    //                 employees.employee_name = employee.employee_name;
    //                 employees.employee_number = employee.employee_number;
    //                 employees.employee_email = employee.employee_email;
                    
    //                 if (image1 != null && image1.Length > 0)
    //                 {
    //                     using (var memoryStream = new MemoryStream())
    //                     {
    //                         await image1.CopyToAsync(memoryStream);
    //                         employees.employee_Image = memoryStream.ToArray();
    //                     }
    //                 }
                    
    //                 await _dbContext.SaveChangesAsync();
                    
    //                 var url = Url.Action("EmployeeViewE", "Employee", new { id = employee.employee_id });
    //                 if (url != null)
    //                 {
    //                     return Redirect(url);
    //                 }
    //             }
    //             }
    //             else
    //             {
    //                 ModelState.AddModelError(string.Empty, "Employee not found");
    //             }
    //         }
    //         catch (Exception exception)
    //         {
    //             ModelState.AddModelError(string.Empty, $"Something went wrong: {exception.Message}");
    //         }
    //     }

    //     return View(employee);
    // }
    // [HttpPost]
    // [CustomAuthorizeE]
    // public async Task<IActionResult> VacationRequestE(Employee employee,int a)
    // {
    //     string myData = TempData["EmpId"] as string;
    //     TempData.Keep("EmpId");
    //     employee.employee_id = Convert.ToInt16(myData);

    //     if (ModelState.IsValid)
    //     {
    //         try
    //         {
    //             if(_dbContext.Employee_Details!=null){
    //             var employees = await _dbContext.Employee_Details.FindAsync(employee.employee_id);
    //             if (employees != null)
    //             {
    //                 employees.employee_vacation_req = "Assigned";
    //                 employees.employee_vacation_start_time =employee.employee_vacation_start_time ;
    //                 employees.employee_vacation_end_time = employee.employee_vacation_end_time;
    //                 employees.employee_vacation_reason=employee.employee_vacation_reason;
    //                 await _dbContext.SaveChangesAsync();
                    
    //                 var url = Url.Action("EmployeeViewE", "Employee", new { id = employee.employee_id });
    //                 if (url != null)
    //                 {
    //                     return Redirect(url);
    //                 }
    //             }
    //             }
    //             else
    //             {
    //                 ModelState.AddModelError(string.Empty, "Employee not found");
    //             }
    //         }
    //         catch (Exception exception)
    //         {
    //             ModelState.AddModelError(string.Empty, $"Something went wrong: {exception.Message}");
    //         }
    //     }

    //     return View(employee);
    // }

    
       

        
    }
}
