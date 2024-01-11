using System.ComponentModel.DataAnnotations;

namespace Travel_Reimbursement.CustomValidation
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime dateTime=Convert.ToDateTime(value);
            if(dateTime<=DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}