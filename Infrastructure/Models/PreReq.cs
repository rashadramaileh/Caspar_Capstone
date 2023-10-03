using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class PreReq
    {
        [Key]
        public int PreReqId { get; set; }

        [Required]
        public bool IsCoRequisite { get; set; }

        [Range(0, 65535), Required]
        public int CourseId { get; set; }
        
        //Navigation Properties
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        //[ForeignKey("CourseId")]
        //public Course? Course2 { get; set; }

    }
}
