using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_Reimbursement.Models
{
    public class FileModel
    {
        [Key]
        public int? ImageId{get; set;}
        [Column(TypeName ="varchar(250)")]
        [Display(Name = "Title")]
         [Required(ErrorMessage ="Please Enter Title")]
        public string? Title{get; set;}
        [Column(TypeName ="varchar(MAX)")]
        [DisplayName("Image Path")]
       
        public string? ImagePath{get; set;}
        [NotMapped]
        [DisplayName("UploadImage File")]
        [Required(ErrorMessage ="Please Upload File")]
        public IFormFile? ImageFile{get; set;}

    }
}