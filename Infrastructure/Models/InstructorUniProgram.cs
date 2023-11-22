using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class InstructorUniProgram
    {
        [Key, Range(0, 65535)]
        public int InstructorProgramId { get; set; }

        [Range(0, 65535)]
        public string ApplicationUserId { get; set; }

        [Range(0, 65535)]
        public int UniProgramId { get; set; }

        [ForeignKey("InstructorId")]
        public ApplicationUser? ApplicationUser { get; set; }

        [ForeignKey("UniProgramId")]
        public UniProgram? UniProgram { get; set; }
    }
}
