using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Batch
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string batch { get; set; }
    }
}
