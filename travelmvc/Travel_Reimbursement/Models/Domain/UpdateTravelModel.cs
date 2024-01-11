using System.ComponentModel.DataAnnotations;
namespace Travel_Reimbursement.Models
{
  public class UpdateTravelModel
    {
        internal string? tempEmail;

        [Key]
        public int Id{get; set;}
        public int TravelId { get; set; }  
  
        
        public string ? Passportnumber { get; set; }
  
       
        public string? Issue { get; set; }

       
        public DateTime ExpiryDate { get; set; }
  
        
         public string ? Place { get; set; } 

        
        public string ? PAN { get; set; }
        
        
        public string ? Department{get; set;}
   
        
        public string ? Project{get; set;}

       
        public string ? Clientname{get; set;}

         
        public string ? Country{get; set;}

        
        public DateTime Fromdate { get; set; } 

       
        public DateTime Todate { get; set; } 

        
        public string ? NoofDays{get; set;}

         
        public string ? Perdiem{get; set;}
        
        
        public string ? Eligible{get; set;}

        

         // public string ? TicketUpload{get; set;}

        
        public DateTime Date { get; set; } = DateTime.Now;


         
        public string ? Particularofexpenses{get; set;}

        
        
        public string ? Detailsofexpense{get; set;}

        
      
        public string? Currency{get; set;}

       
        public float Amount{get; set;}

     
      //  public string ? FileUpload{get; set;}

        
        public string ? Mode{get; set;}
        public string ?EmployeeEmail{get; set;}
        public float Totalperdiem {get; set;}
 
       
         public float Totalamount {get; set;}

 
         public float Advanceamount {get; set;}
         public string ? Remarks{get; set;}
        //  public string? Status{get;set;}

    
    }
}