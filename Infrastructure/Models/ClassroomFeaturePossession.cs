using CASPAR.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class ClassroomFeaturePossession
    {
        [Key, Range(0, 65535)]
        public int FeaturePossessionId { get; set; }
        [Required]
        public int FeatureId { get; set; }
        [Required]
        public int ClassroomId { get; set; }

        [ForeignKey("FeatureId")]
        public ClassroomFeature? ClassroomFeature { get; set; }
        [ForeignKey("ClassroomId")]
        public Classroom? Classroom { get; set; }
        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;
    }
}
