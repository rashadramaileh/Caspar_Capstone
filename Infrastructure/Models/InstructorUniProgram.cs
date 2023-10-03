using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class InstructorUniProgram
    {
        [Key, Range(0, 65535)]
        public int InstructorProgramId { get; set; }

        [Range(0, 65535)]
        public int InstructorId { get; set; }

        [Range(0, 65535)]
        public int UniProgramId { get; set; }

        [ForeignKey("InstructorId")]
        public Instructor? Instructor { get; set; }

        [ForeignKey("UniProgramId")]
        public UniProgram? UniProgram { get; set; }
    }
}
