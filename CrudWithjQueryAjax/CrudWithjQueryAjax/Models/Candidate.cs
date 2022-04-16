using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudWithjQueryAjax.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CandidateName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string BloodGroup { get; set; }


        public int Age { get; set; }

        public int Mobile { get; set; }

        public DateTime Created { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
    }
}
