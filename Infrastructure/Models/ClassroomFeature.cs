using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class ClassroomFeature
    {
        [Key, Range(0, 65535)]
        public int ClassroomFeatureId { get; set; }

        [Required, StringLength(30), Display(Name ="Feature Name")]
        public string? ClassroomFeatureName { get; set; }
        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;
    }
}
