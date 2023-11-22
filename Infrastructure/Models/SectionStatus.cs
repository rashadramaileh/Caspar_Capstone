using System.ComponentModel.DataAnnotations;

namespace CASPAR.Infrastructure.Models
{
    public class SectionStatus
    {
        [Key, Range(0, 65535)]
        public int SectionStatusId { get; set; }

        [Required, StringLength(20), Display(Name = "Status")]
        public String? StatusName { get; set; }

        [StringLength(200), Display(Name = "Description")]
        public String? StatusDescription { get; set; }

        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;

    }
}
