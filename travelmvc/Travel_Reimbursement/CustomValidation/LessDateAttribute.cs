// using System.ComponentModel.DataAnnotations;

// namespace Travel_Reimbursement.CustomValidation
// {
//     public class LessDateAttribute:ValidationAttribute
//     {
//         public  LessDateAttribute(): base("{0}Date should less than current date")
//         {

//         }
//         public override bool IsValid(object value)
//         {
//             DateTime propValue = Convert.ToDateTime(value);
//             if(propValue<=DateTime.Now)
//             return true;
//             else
//             return false;
//         }
//         // protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//         // {
//         //     if(value!=null)
//         //     {
//         //         string Name=value.ToString();
//         //         if(Name.Contains("gambo"))
//         //         {
//         //             return ValidationResult.Success;
//         //         }
//         //     }
//         //         return new ValidationResult("Field must contain Gambo");
            
//         // }

//     }
// }