using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class InstructorLoad
    {
        [Key, Range(0, 65535)]
        public int InstructorLoadId { get; set; }

        [Range(0, 255), Required]
        public int LoadHours { get; set; }

        [Range(0, 65535)]
        public string ApplicationUserId { get; set; }

        [Range(0, 65535)]
        public int SemesterId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }

        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }
    }
}
