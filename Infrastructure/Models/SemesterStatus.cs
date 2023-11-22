using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class SemesterStatus
    {
        [Key, Range(0, 255)]
        public int SemesterStatusID { get; set; }

        [Required, StringLength(20), Display(Name = "Status")]
        public String? SemesterStatusName { get; set; }

        [StringLength(200), Display(Name = "Description")]
        public String? SemesterStatusDescription { get; set; }

        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;

    }
}
