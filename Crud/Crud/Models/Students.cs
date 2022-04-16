using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class Students
    {
        [Key]
        public int id { get; set; }


        [Required(ErrorMessage ="Required")]
        public string name { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        
        public string email { get; set; }


        [Required(ErrorMessage = "Required")]
        public string mobile { get; set; }


        [Required(ErrorMessage = "Required")]
        public string address { get; set; }


        [Required(ErrorMessage ="Required")]
        [Display(Name ="batch")]
        public int batch_id { get; set; }


        [Required(ErrorMessage = "Required")]
        [Display(Name = "faculty")]
        public int faculty_id { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Required")]
        public string faculty { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Required")]
        public string batch { get; set; }
    }
}
