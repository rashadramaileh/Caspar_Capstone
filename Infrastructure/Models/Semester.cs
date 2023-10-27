using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class Semester
    {
        [Key, Range(0, 65535)]
        public int SemesterId { get; set; }

        [StringLength(20), Display(Name = "Semester")]
        public string? SemesterName { get; set; }

        [Display(Name = "Begin Date")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Registration")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Status")]
        public int SemesterStatusId { get; set; }

        [Display(Name = "Type")]
        public int SemesterTypeId { get; set; }

        [ForeignKey("SemesterStatusId")]
        public SemesterStatus? SemesterStatus { get; set; }

        [ForeignKey("SemesterTypeId")]
        public SemesterType? SemesterType { get; set; }
    }
}
