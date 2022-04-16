using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudWithoutEF.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Address { get; set; }

       
        [Required]
        public string Designation { get; set; }

       
    }
}
