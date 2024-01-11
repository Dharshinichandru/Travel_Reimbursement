using Travel_Reimbursement.Models;

using Travel_Reimbursement.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_Reimbursement.ContextDBConfig;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Data.SqlClient;

namespace Travel_Reimbursement.Controllers
{
    public class DetailsController : Controller
    {
        private readonly Travel_ReimbursementDbContext dbContext;
         
        public DetailsController(Travel_ReimbursementDbContext dbContext)
        {
          
            this.dbContext= dbContext;
        }
        [HttpGet]
        [Authorize]
       
        public async Task<IActionResult> Index()
        {
            try
            {
                
               //we set a timeout duration of 10 sec using
                var timeout=TimeSpan.FromSeconds(10);

               //To cancel the task if it exceeds the specified timeout duration.
                var cancellationTokenSource=new CancellationTokenSource(timeout);
                var cancellationToken=cancellationTokenSource.Token;

                var task=Task.Run(async ()=>
                {
                    var table=await dbContext.Traveltable.ToListAsync();
                    return table;
                },cancellationToken);

                var result=await task;
                return View(result);

            }
            catch (TaskCanceledException)
            {
                ModelState.AddModelError("","Database operation timed out: ");
            }
      
            catch(Exception exception)
            {
                ModelState.AddModelError("","An error occured.");
                //return View("Error"); 
            }
            return View("Error");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(AddTravelModel addTravelModel)
        {
            try
                {
                    if(ModelState.IsValid)
                        {
                           // addTravelModel.TravelId=addTravelModels.Max(c=>c.TravelId)+1;
                            if(addTravelModel==null)
                            {
                                throw new ArgumentNullException(nameof(addTravelModel));
                            }
                            if(string.IsNullOrEmpty(addTravelModel.Clientname))
                            {
                                throw new ArgumentException("Name cannot be empty.",nameof(addTravelModel.Clientname));
                            }
                            if(addTravelModel.Clientname=="Admin")
                            {
                                throw new ApplicationException("Cannot create a Client name with the name 'Admin'.");
                            }
                            var worker = new TravelModel()
                            {
                                
                                TravelId=addTravelModel.TravelId,
                                Passportnumber=addTravelModel.Passportnumber,
                                Issue=addTravelModel.Issue,
                                ExpiryDate=addTravelModel.ExpiryDate,
                                Place=addTravelModel.Place,
                                PAN=addTravelModel.PAN,
                                Department=addTravelModel.Department,
                                Project=addTravelModel.Project,
                                Clientname=addTravelModel.Clientname,
                                Country=addTravelModel.Country,
                                Fromdate=addTravelModel.Fromdate,
                                Todate=addTravelModel.Todate,
                                NoofDays=addTravelModel.NoofDays,
                                Perdiem=addTravelModel.Perdiem,
                                Eligible=addTravelModel.Eligible,
                                Date=addTravelModel.Date,
                                Particularofexpenses=addTravelModel.Particularofexpenses,
                                Detailsofexpense=addTravelModel.Detailsofexpense,
                                Currency=addTravelModel.Currency,
                                Amount=addTravelModel.Amount,
                                Mode=addTravelModel.Mode,
                                EmployeeEmail=addTravelModel.EmployeeEmail,
                                Totalperdiem=addTravelModel.Totalperdiem,
                                Totalamount=addTravelModel.Totalamount,
                                Advanceamount=addTravelModel.Advanceamount,
                                Remarks=addTravelModel.Remarks,

                            };
                                await dbContext.Traveltable.AddAsync(worker);
                                await dbContext.SaveChangesAsync();
                                return RedirectToAction("Index");
           
                        }
                        else
                        {
                            //Modelstate exception
                            var errorMessage=ModelState.Values.SelectMany(v=>v.Errors).Select(e=>e.ErrorMessage).ToList();
                            TempData["errorMessage"]="Try Again!";
                            return View(addTravelModel);    
                        }
                }
                
            catch(DbUpdateException dbUpdateException)
            {
                ModelState.AddModelError("","An error occurred while saving to the database: "+dbUpdateException?.Message);
            }
            catch(ArgumentException argumentException)
            {
                ModelState.AddModelError("","Invalid argument:"+argumentException.Message);
            }
            catch(FormatException formatException)
            {
                ModelState.AddModelError("","Invalid format: "+formatException.Message);
            }
            catch(InvalidOperationException invalidOperationException)
            {
                ModelState.AddModelError("","Invalid Operation: "+invalidOperationException.Message);
            }
            catch(NullReferenceException nullReferenceException)
            {
                ModelState.AddModelError("","Null reference: "+nullReferenceException.Message);
            }
            catch(ApplicationException applicationException)
            {
                ModelState.AddModelError("",applicationException.Message);
            }
            catch(HttpRequestException httpRequestException)
            {
                //eg: network errors
                ModelState.AddModelError("","HttP request exception occurred: "+httpRequestException.Message);
            }
            catch(SqlException sqlException)
            {
                //eg: database connection failures
                 ModelState.AddModelError("","SQL Exception occurred: "+sqlException.Message);
            }
            catch (Exception exception)
            {
                //Handles general exceptions,eg: internal server errors
                ModelState.AddModelError("","An error occured.");
            }
            
            return View(addTravelModel);
        }
           
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            string? tempEmail;
            try
            {
                var worker = await dbContext.Traveltable.FirstOrDefaultAsync(x=>x.Id==id);
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
                }
            }
            catch(Exception exception)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");  
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateTravelModel updateTravelModel)
        {  
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
         {
            client.BaseAddress = new Uri("http://localhost:5029/api/Travel/");
             client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync("http://localhost:5029/api/Travel/Get");

        if (response.IsSuccessStatusCode)
        {
            
            var data = response.Content.ReadAsStringAsync().Result;
             
           var employee = JsonConvert.DeserializeObject<List<TravelModel>>(data);
            return View(employee);
        }
        else
        {
            return View("Error");
        }
    }
 }

 [HttpPost]
        public async Task<IActionResult> DeleteDetails(UpdateTravelModel updateTravelModel)
        {
             var worker = await dbContext.Traveltable.FindAsync(updateTravelModel.Id);
            if(worker != null)
            {
                dbContext.Traveltable.Remove(worker);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // public async Task<IActionResult> View(UpdateTravelModel model)
        // {
        //     var worker= await dbContext.Traveltable.FindAsync(model.Id);
        //     if(worker!=null)
        //     {
        //             worker.Id=worker.Id;
        //             worker.TravelId=worker.TravelId;
        //             worker.Passportnumber=worker.Passportnumber; 
        //             worker.Issue=worker.Issue;
        //             worker.ExpiryDate=worker.ExpiryDate;
        //             worker.Place=worker.Place;
        //             worker.PAN=worker.PAN;
        //             worker.Department=worker.Department;
        //             worker.Project=worker.Project;
        //             worker.Clientname=worker.Clientname;
        //             worker.Country=worker.Country;
        //             worker.Fromdate=worker.Fromdate;
        //             worker.Todate=worker.Todate;
        //             worker.NoofDays=worker.NoofDays;
        //             worker.Perdiem=worker.Perdiem;
        //             worker.Eligible=worker.Eligible;
        //             worker.Date=worker.Date;
        //             worker.Particularofexpenses=worker.Particularofexpenses;
        //             worker.Detailsofexpense =worker.Detailsofexpense;
        //             worker.Currency =worker.Currency;
        //             worker.Amount =worker.Amount;
        //             worker.Mode =worker.Mode;
        //             worker.EmployeeEmail=worker.EmployeeEmail;
        //             worker.Totalperdiem =worker.Totalperdiem;
        //             worker.Totalamount=worker.Totalamount;
        //             worker.Advanceamount=worker.Advanceamount;
        //             worker.Remarks=worker.Remarks;

        //           await dbContext.SaveChangesAsync();

        //           return RedirectToAction("Index");

        //     }
        //     return RedirectToAction("Index");
        // }

    //   [HttpPost]
//          public  ActionResult Delete(int id)
//         {
//         if(ModelState.IsValid)
//         {
//             try
//             {
//                  var worker =  dbContext.Traveltable.FirstOrDefault(m=> m.Id==id);
//                 //   var exist =  _context.Employees.FirstOrDefault(m => m.EmployeeID==id);

//             if(worker != null)
//             {
//                 dbContext.Traveltable.Remove(worker);
//                 dbContext.SaveChangesAsync();
//                 return RedirectToAction("Index");
//                 //  _context.Employees.Remove(exist);
//                 // _context.SaveChanges();
//                 // return RedirectToAction("Index");

//             }
//             }
//             catch(Exception exception)
//             {
//                 ModelState.AddModelError(string.Empty,$"Something went wrong {exception.Message}");
//             }

//         }
//            ModelState.AddModelError(string.Empty,$"Something went wrong invalid model");
//          return RedirectToAction("Index");
//     }
        // public async Task<IActionResult> Delete(UpdateTravelModel model)
        // {
        //     var worker = await dbContext.Traveltable.FindAsync(model.Id);
        //     if(worker != null)
        //     {
        //         dbContext.Traveltable.Remove(worker);
        //         await dbContext.SaveChangesAsync();

        //         return RedirectToAction("Index");
        //     }
        //     return RedirectToAction("Index");
        // }


        

    }

    
}