using CASPAR.Infrastructure.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //Create Models

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Building> Building { get; set; } // the physical table "Buildings"
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<ClassroomFeature> ClassroomFeature { get; set; }
        public DbSet<ClassroomFeaturePossession> ClassroomFeaturePossession { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<RoomConfig> RoomConfiguration { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<SectionStatus> SectionStatus { get; set; }
        public DbSet<Modality> Modality { get; set; }
        public DbSet<PayModel> PayModel { get; set; }
        public DbSet<WhoPays> WhoPays { get; set; }
        public DbSet<PartOfTerm> PartOfTerm { get; set; }
        public DbSet<MeetingTime> MeetingTime { get; set; }
        public DbSet<UniProgram> UniProgram { get; set; }
        public DbSet<InstructorUniProgram> InstructorUniProgram { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<InstructorWishlist> InstructorWishlist { get; set; }
        public DbSet<InstructorWishlistDetails> InstructorWishlistDetails { get; set; }
        public DbSet<InstructorWishlistModality> InstructorWishlistModality { get; set; }
        public DbSet<InstructorTime> InstructorTime { get; set; }
        public DbSet<DayBlock> DayBlock { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<PreReq> PreReq { get; set; }
        public DbSet<CourseSemester> CourseSemester { get; set; }
        public DbSet<TimeBlock> TimeBlock { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<StudentWishlist> StudentWishlist { get; set; }
        public DbSet<Major> Major { get; set; }
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentWishlistDetails> StudentWishlistDetails { get; set; }
        public DbSet<StudentWishlistModality> StudentWishlistModality { get; set; }
        public DbSet<StudentTime> StudentTime { get; set; }
        public DbSet<InstructorRelease> InstructorRelease { get; set; }
        public DbSet<InstructorCurrentLoad> InstructorCurrentLoad { get; set; }
        public DbSet<InstructorLoad> InstructorLoad { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SemesterStatus> SemesterStatus { get; set; }
        public DbSet<SemesterType> SemesterType { get; set; }

       

    }
}
