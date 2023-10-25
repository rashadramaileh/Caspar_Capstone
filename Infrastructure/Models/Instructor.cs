using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class Instructor
    {
        public bool Adjunct { get; set; }

        [Key,Range(0, 65535)]
        public int InstructorId { get; set; }

        //[Range(0, 65535)]
        //public int InstructorUniProgramId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        //[ForeignKey("InstructorUniProgramId")]
        //public InstructorUniProgram? InstructorUniProgram { get; set; }

    }
}
