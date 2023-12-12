using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CASPAR.Infrastructure.Models
{
    public class Section
    {
        //Local Properties
        [Key, Display(Name = "Section")]
        public int SectionId { get; set; }

        [StringLength(20), Display(Name = "CRN")]
        public string? Crn { get; set; }

        [Range(0, 65535), Display(Name = "Max Enrollment")]
        public int? MaxEnrollment { get; set; }

        [Range(0, 65535), Display(Name = "First Week Enrollment")]
        public int? FirstWeekEnroll { get; set; }

        [Range(0, 65535), Display(Name = "Third Week Enrollment")]
        public int? ThirdWeekEnroll { get; set; }

        [StringLength(200), Display(Name = "Notes")]
        public string? Notes { get; set; }



        //Required Relations
        [Required, Range(0, 65535), Display(Name = "Semester")]
        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }
        
        
        //Optional Relations



        [Range(0, 65535), Display(Name = "Classroom")]
        public int? ClassroomId { get; set; }
        [ForeignKey("ClassroomId")]
        public Classroom? Classroom { get; set; }


        [Range(0, 65535), Required, Display(Name = "Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }


        [Range(0, 65535), Display(Name = "Instructor")]
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }


        [Range(0, 65535), Display(Name = "Section Status")]
        public int? SectionStatusId { get; set; }
        [ForeignKey("SectionStatusId")]
        public SectionStatus? SectionStatus { get; set; }


        [Range(0, 65535), Display(Name = "Who Pays")]
        public int? WhoPaysId { get; set; }
        [ForeignKey("WhoPaysId")]
        public WhoPays? WhoPays { get; set; }


        [Range(0, 65535), Display(Name = "Pay Model")]
        public int? PayModelId { get; set; }
        [ForeignKey("PayModelId")]
        public PayModel? PayModel { get; set; }


        // having this column and the relation to PartOfTerm causes an error. 
        //[Range(0, 255), Display(Name = "Part of Term")]
        //public int? PartofTermId { get; set; } = null;
        [ForeignKey("PartOfTermID")]
        public int? PartOfTermID { get; set; }
        public PartOfTerm? PartOfTerm { get; set; }


        [Range(0, 255), Display(Name = "Modality")]
        public int? ModalityId { get; set; }
        [ForeignKey("ModalityId")]
        public Modality? Modality { get; set; }


        [Range(0, 255), Display(Name = "Meeting Time")]
        public int? MeetingTimeId { get; set; }
        [ForeignKey("MeetingTimeId")]
        public MeetingTime? MeetingTime { get; set; }


        [Range(0, 255), Display(Name = "Day Block")]
        public int? DayBlockId { get; set; }
        [ForeignKey("DayBlockId")]
        public DayBlock? DayBlock { get; set; }
                

        [Range(0, 65535), Display(Name = "Campus")]
        public int? CampusId { get; set; }
        [ForeignKey("CampusId")]
        public Campus? Campus { get; set; }


        [Display(Name = "Active")]
        public int IsActive { get; set; } = 1;



    }
}
