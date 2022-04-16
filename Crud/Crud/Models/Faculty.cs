using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Faculty
    {
        [Key]
        public int id { get; set; }

        [Required (ErrorMessage ="Required")]  
        public string faculty { get; set; }       

    }
}
