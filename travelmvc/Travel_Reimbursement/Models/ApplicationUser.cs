using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_Reimbursement.Models
{
    public class ApplicationUser:IdentityUser
    {
        [PersonalData]
        [Column(TypeName="nVarchar(100)")]
        public string? Name{get; set;}
        
    }
}