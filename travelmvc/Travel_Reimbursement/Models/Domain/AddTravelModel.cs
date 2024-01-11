using System.ComponentModel.DataAnnotations;
using Travel_Reimbursement.CustomValidation;


namespace Travel_Reimbursement.Models
{
  public class AddTravelModel
    {
        [Display(Name ="TravelId")]
        [Required(ErrorMessage ="TravelId is required")]
        
        public int TravelId { get; set; }  
  
        [Display(Name = "Passport Number")]
        [Required(ErrorMessage = "Passport Number is required")]
        [RegularExpression(@"^[A-Z][1-9]\d\s?\d{4}[1-9]$", ErrorMessage = "Invalid Passport Number")]
        public string ? Passportnumber { get; set; }
  
        [Display(Name = "Issue")]
        [Required(ErrorMessage ="Issue is required")]
        [RegularExpression("^(\\d{2}).(\\d{2}).(\\d{4})$",ErrorMessage ="Date is invalid")]
        public string? Issue { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage ="ExpiryDate is required")]
       
       // [RegularExpression("^(\\d{2}).(\\d{2}).(\\d{4})$",ErrorMessage ="Date is invalid")]
        public DateTime ExpiryDate { get; set; }
  
        [Display(Name = "Place Of Issue")]
        [Required(ErrorMessage ="Please Enter Place of issue")]
        [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Name format is invalid,Numbers are not valid")]
        
        public string ? Place { get; set; } 

        [Display(Name = "PAN Card:")]
        [Required(ErrorMessage = "PAN Number is required")]
        [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number")]
        public string ? PAN { get; set; }
        
        [Display(Name = "Department")] 
        [Required(ErrorMessage ="Department is requried!")]
        [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Department format is invalid")]  
        public string ? Department{get; set;}
   
        [Display(Name = "Project")] 
        [Required(ErrorMessage ="Project is requried!")]  
        [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Project format is invalid")]
        public string ? Project{get; set;}

        [Display(Name = "ClientName")] 
        [Required(ErrorMessage ="Clientname is requried!")] 
        [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Clientname format is invalid")] 
        public string ? Clientname{get; set;}

         [Display(Name = "Country")] 
        [Required(ErrorMessage ="Country is requried!")]  
        [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Countryname format is invalid")]
        public string ? Country{get; set;}

        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Fromdate is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
     
        public DateTime Fromdate { get; set; } 

        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Todate is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Todate { get; set; } 

        [Display(Name = "No Of Days")] 
        [Required(ErrorMessage ="No of Days is requried!")]  
        public string ? NoofDays{get; set;}

         [Display(Name = "Perdiem")] 
         [Required(ErrorMessage ="PerDiem  is requried!")]
          public string ? Perdiem{get; set;}

           [Display(Name = "Eligible")] 
         [Required(ErrorMessage ="Eligible is requried!")]
         [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Eligible format is invalid")]
          public string ? Eligible{get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        // [LessDate]
        public DateTime Date { get; set; } = DateTime.Now;


        [Display(Name = "Particular Expenses")] 
        [Required(ErrorMessage =" Particular Expenses is requried!")]  
        
        public string ? Particularofexpenses{get; set;}

        
        [Display(Name = "Details Expense")] 
        [Required(ErrorMessage =" Details of Expense is requried!")] 
        [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Details of Expense format is invalid")] 
        public string ? Detailsofexpense{get; set;}
        
        [Display(Name = "Currency")] 
        [Required(ErrorMessage =" Currency is requried!")]  
        public string? Currency{get; set;}

        [Display(Name = "Amount")] 
        [Required(ErrorMessage =" Amount is requried!")]  
        [RegularExpression(@"^\d+(\.\d{1,2})?$",ErrorMessage ="Only numbers are valid")]
        //  [ScaffoldColumn(false)] 
        public float Amount{get; set;}

        [Display(Name = "Mode")] 
        [Required(ErrorMessage =" Mode is requried!")]  
        public string ? Mode{get; set;}
         [Display(Name = "Employee Email")] 
        [Required(ErrorMessage = "Please enter email")]  
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]  
         public string ? EmployeeEmail{get; set;}

        
        [Display(Name = "Total Per Diem Amount")] 
        [Required(ErrorMessage =" Total Per Diem Amount is requried!")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$",ErrorMessage ="Only numbers are valid")]  
        public float Totalperdiem {get; set;}
 
        [Display(Name = "Total Amount")] 
        [Required(ErrorMessage =" Total Amount is requried!")]  
        [RegularExpression(@"^\d+(\.\d{1,2})?$",ErrorMessage ="Only numbers are valid")]
         public float Totalamount {get; set;}

        [Display(Name = "Advance  Amount")] 
        [Required(ErrorMessage =" Total Amount is requried!")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$",ErrorMessage ="Only numbers are valid")]  
         public float Advanceamount {get; set;}

          [Display(Name = "Remarks")] 
        [Required(ErrorMessage =" Remarks is requried!")] 
         [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Remarks format is invalid,Numbers are not valid")]
         public string ? Remarks{get; set;}

        internal int Max(Func<object, object> value)
        {
            throw new NotImplementedException();
        }

        //   public int TravelId { get; set; }  

        //     [Display(Name = "Passport Number")]
        //   [Required(ErrorMessage = "Passport Number is required")]
        //   [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid Passport Number")]
        //   public string ? Passportnumber { get; set; }


        //   public string? Issue { get; set; }


        //   public DateTime ExpiryDate { get; set; }


        //    public string ? Place { get; set; } 


        //   public string ? PAN { get; set; }


        //   public string ? Department{get; set;}


        //   public string ? Project{get; set;}


        //   public string ? Clientname{get; set;}


        //   public string ? Country{get; set;}


        //   public DateTime Fromdate { get; set; } 


        //   public DateTime Todate { get; set; } 


        //   public string ? NoofDays{get; set;}


        //   public string ? Perdiem{get; set;}


        //   public string ? Eligible{get; set;}



        //    // public string ? TicketUpload{get; set;}


        //   public DateTime Date { get; set; } = DateTime.Now;



        //   public string ? Particularofexpenses{get; set;}



        //   public string ? Detailsofexpense{get; set;}



        //   public string? Currency{get; set;}


        //   public float Amount{get; set;}


        // //  public string ? FileUpload{get; set;}


        //   public string ? Mode{get; set;}
        //   public string ?EmployeeEmail{get; set;}



        //   public float Totalperdiem {get; set;}


        //    public float Totalamount {get; set;}


        //    public float Advanceamount {get; set;}
        //    public string ? Remarks{get; set;}


    }
}