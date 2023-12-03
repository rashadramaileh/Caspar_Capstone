using CASPAR.Infrastructure.Models;
using Infrastructure.Models;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<ApplicationUser> ApplicationUser { get; }

        public IGenericRepository<Building> Building { get; } 
        public IGenericRepository<Classroom> Classroom { get;}
        public IGenericRepository<ClassroomFeature> ClassroomFeature { get; }
        public IGenericRepository<ClassroomFeaturePossession> ClassroomFeaturePossession { get; }
        public IGenericRepository<Campus> Campus { get;  }
        public IGenericRepository<RoomConfig> RoomConfig { get; }
        public IGenericRepository<Section> Section{ get;}
        public IGenericRepository<SectionStatus> SectionStatus { get;}
        public IGenericRepository<Modality> Modality { get;}
        public IGenericRepository<PayModel> PayModel { get; }
        public IGenericRepository<WhoPays> WhoPays { get; }
        public IGenericRepository<PartOfTerm> PartOfTerm { get; }
        public IGenericRepository<MeetingTime> MeetingTime { get; }
        public IGenericRepository<UniProgram> UniProgram { get; }
        public IGenericRepository<InstructorUniProgram> InstructorUniProgram { get; }
        public IGenericRepository<Instructor> Instructor { get; }
        public IGenericRepository<InstructorWishlist> InstructorWishlist { get; }
        public IGenericRepository<InstructorWishlistDetails> InstructorWishlistDetails { get;  }
        public IGenericRepository<InstructorWishlistModality> InstructorWishlistModality { get; }
        public IGenericRepository<InstructorTime> InstructorTime { get; }
        public IGenericRepository<DayBlock> DayBlock { get; }
        public IGenericRepository<Course> Course { get; }
        public IGenericRepository<PreReq> PreReq { get; }
        public IGenericRepository<CourseSemester> CourseSemester { get; }
        public IGenericRepository<TimeBlock> TimeBlock { get; }
        public IGenericRepository<Semester> Semester { get; }
        public IGenericRepository<StudentWishlist> StudentWishlist { get; }
        public IGenericRepository<Major> Major { get; }
        public IGenericRepository<Student> Student { get; }
        public IGenericRepository<StudentWishlistDetails> StudentWishlistDetails { get; }
        public IGenericRepository<StudentWishlistModality> StudentWishlistModality { get; }
        public IGenericRepository<StudentTime> StudentTime { get; }
        public IGenericRepository<InstructorRelease> InstructorRelease{ get; }
        public IGenericRepository<InstructorCurrentLoad> InstructorCurrentLoad { get; }
        public IGenericRepository<InstructorLoad> InstructorLoad { get; }
        public IGenericRepository<Role> Role { get; }
        public IGenericRepository<SemesterStatus> SemesterStatus{ get; }
        public IGenericRepository<SemesterType> SemesterType { get; }

        // Add other models/tables here after you you create them
        // so UnitOfWork has access to them

        // Save changes to the data source

        int Commit();

        Task<int> CommitAsync();

    }
}
