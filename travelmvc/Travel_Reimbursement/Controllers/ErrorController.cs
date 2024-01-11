using Microsoft.AspNetCore.Mvc;

namespace Travel_Reimbursement.Controllers
{
    public class ErrorController:Controller
    {

      [Route("Error/{statusCode}")]
        public ActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage="Sorry, the resource you requested could not be found in TravelReimbursement";
                    break;
                case 500:
                    ViewBag.ErrorMessage="Oops! Something went wrong on the server.";
                    break;
            }
            return View("NotFound");
        }
    }
}