using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudWithReact.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }


        public int Age { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Skills { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Designation { get; set; }

    }
}
