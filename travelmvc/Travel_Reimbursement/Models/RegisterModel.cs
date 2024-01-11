using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Travel_Reimbursement.Models
{
    public class RegisterModel
    {
        
        [Display(Name = "Name")]
        [Required(ErrorMessage ="Please Enter Name")] 
        [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage ="Name format is invalid")]
        // [CustomValidation]
        public string? Name{get; set;}
        
       
        [Required(ErrorMessage = "Please enter email")]  
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id format is not valid")]
        [RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", ErrorMessage = "Please enter a valid email address")]    
        public string? Email{get; set;}

        
        [Display(Name = "Password")] 
        [Required(ErrorMessage = "Please enter password")]  
        [DataType(DataType.Password)]  
        //[RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",ErrorMessage = "Password must contain atleast 1 lowercase letter,1 uppercase letter,1 digit,1 special character, and be at least 8 characters long.")]
        public string? Password{get; set;}


        [Display(Name = "Confirm password")]  
        [Required(ErrorMessage = "Please enter confirm password")]  
        [Compare("Password", ErrorMessage = "Confirm password doesn't match the password, Type again !")]  
        [DataType(DataType.Password)]  
        public string? ConfirmPassword{get; set;}
    }
}