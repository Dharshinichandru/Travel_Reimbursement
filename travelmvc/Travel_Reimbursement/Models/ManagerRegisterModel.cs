using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Travel_Reimbursement.Models;

namespace Travel_Reimbursement.Models
{
    public class ManagerRegisterModel
    {
        [Key]  
        public int UserId { get; set; }  
  
        [Display(Name = "UserName")]
        [Required(ErrorMessage ="Please Enter Username")]  
        [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Username format is invalid")]
         public string ? Username { get; set; }  
  
        [Display(Name = "Password")] 
        [Required(ErrorMessage = "Please enter password")]  
        [DataType(DataType.Password)]  
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",ErrorMessage = "Password must contain atleast 1 lowercase letter,1 uppercase letter,1 digit,1 special character, and be at least 8 characters long.")]
        // [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]  
       // [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase      Alphabet, 1 Number and 1 Special Character")]
         public string ?Password { get; set; }  
  
        [Display(Name = "Confirm password")]  
        [Required(ErrorMessage = "Please enter confirm password")]  
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]  
        [DataType(DataType.Password)]  
        public string ?Confirmpassword { get; set; }  
        
        [Required(ErrorMessage = "Please enter email")]  
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]  
        public string ?Email { get; set; }  
  
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]  
        [Required(ErrorMessage = "Please enter Mobile Number")]  
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Entered phone format is not valid.")]  
        [ScaffoldColumn(false)] 
        public string ? Mobilenumber { get; set; }

        internal void RegisterManagerAsync(ManagerRegisterModel register)
        {
            throw new NotImplementedException();
        }
    }
}
