using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class InstructorRelease
    {
        [Key]
        public int InstructorReleaseId { get; set; }

        [StringLength(50)]
        public string? ReleaseTimeName { get; set; }

        [Range(0, 12)]
        public int ReleaseTimeAmount { get; set; }

        [Range(1, 65535)]
        public string ApplicationUserId { get; set; }

        [Range(1, 65535)]
        public int SemesterId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }

        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }
    }
}
