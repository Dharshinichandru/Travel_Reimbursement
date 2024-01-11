using System.ComponentModel.DataAnnotations;
namespace Travel_Reimbursement.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Please enter email")]  
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id Format is not valid")]  
        public string? Email{get; set;}
        
        [Display(Name = "Password")] 
        [Required(ErrorMessage = "Please enter password")]  
        [DataType(DataType.Password)]  
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string? Password{get; set;}
        
    }
}