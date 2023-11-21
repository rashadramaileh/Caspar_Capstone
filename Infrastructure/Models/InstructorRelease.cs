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

        [Range(0, 200)]
        public string? ReleaseNotes { get; set; }

        [Range(1, 65535)]
        public int UserId { get; set; }

        [Range(1, 65535)]
        public int SemesterId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }
    }
}
