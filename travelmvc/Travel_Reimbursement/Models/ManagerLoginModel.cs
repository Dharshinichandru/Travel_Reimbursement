using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Travel_Reimbursement.Models;

namespace Travel_Reimbursement.Models
{
    public class ManagerLoginModel
    {

        [Key]  
        public int ID { get; set; } 

        [Display(Name = "UserName")] 
        [Required(ErrorMessage ="Username is requried!")]  
        [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Username format is invalid")]
        
        public string ? Username{get; set;}

        [Display(Name = "Password")] 
        [Required(ErrorMessage = "Password is requried")]  
        [DataType(DataType.Password)]  
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        
        public string ? Password{get; set;}
         
        public bool RememberMe { get; set; }
    }
}