using CASPAR.Infrastructure.Models;
using Infrastructure.Interfaces;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _dbcontext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public IGenericRepository<Building> _Building;
        public IGenericRepository<Campus> _Campus;
        public IGenericRepository<Classroom> _Classroom;
        public IGenericRepository<Course> _Course;
        public IGenericRepository<CourseSemester> _CourseSemester;
        public IGenericRepository<CourseType> _CourseType;
        public IGenericRepository<DayBlock> _DayBlock;
        public IGenericRepository<Instructor> _Instructor;
        public IGenericRepository<InstructorLoad> _InstructorLoad;
        public IGenericRepository<InstructorRelease> _InstructorRelease;
        public IGenericRepository<InstructorUniProgram> _InstructorUniProgram;
        public IGenericRepository<InstructorWishlist> _InstructorWishlist;
        public IGenericRepository<InstructorWishlistDetails> _InstructorWishlistDetails;
        public IGenericRepository<Major> _Major;
        public IGenericRepository<MeetingTime> _MeetingTime;
        public IGenericRepository<Modality> _Modality;
        public IGenericRepository<PartOfTerm> _PartOfTerm;
        public IGenericRepository<PayModel> _PayModel;
        public IGenericRepository<PreReq> _PreReq;
        public IGenericRepository<Role> _Role;
        public IGenericRepository<RoomConfig> _RoomConfig;
        public IGenericRepository<Section> _Section;
        public IGenericRepository<SectionStatus> _SectionStatus;
        public IGenericRepository<Semester> _Semester;
        public IGenericRepository<SemesterStatus> _SemesterStatus;
        public IGenericRepository<SemesterType> _SemesterType;
        public IGenericRepository<Student> _Student;
        public IGenericRepository<StudentWishlist> _StudentWishlist;
        public IGenericRepository<TimeBlock> _TimeBlock;
        public IGenericRepository<UniProgram> _UniProgram;
        public IGenericRepository<User> _User;
        public IGenericRepository<UserRole> _UserRole;
        public IGenericRepository<WhoPays> _WhoPays;

        public IGenericRepository<Building> Building
        {
            get
            {
                if (_Building == null)
                {
                    _Building = new GenericRepository<Building>(_dbcontext);
                }
                return _Building;
            }
        }

        public IGenericRepository<Campus> Campus
        {
            get
            {
                if (_Campus == null)
                {
                    _Campus = new GenericRepository<Campus>(_dbcontext);
                }
                return _Campus;
            }
        }

        public IGenericRepository<Classroom> Classroom
        {
            get
            {
                if (_Classroom == null)
                {
                    _Classroom = new GenericRepository<Classroom>(_dbcontext);
                }
                return _Classroom;
            }
        }

        public IGenericRepository<Course> Course
        {
            get
            {
                if (_Course == null)
                {
                    _Course = new GenericRepository<Course>(_dbcontext);
                }
                return _Course;
            }
        }

        public IGenericRepository<CourseSemester> CourseSemester
        {
            get
            {
                if (_CourseSemester == null)
                {
                    _CourseSemester = new GenericRepository<CourseSemester>(_dbcontext);
                }
                return _CourseSemester;
            }
        }

        public IGenericRepository<CourseType> CourseType
        {
            get
            {
                if (_CourseType == null)
                {
                    _CourseType = new GenericRepository<CourseType>(_dbcontext);
                }
                return _CourseType;
            }
        }
        public IGenericRepository<DayBlock> DayBlock
        {
            get
            {
                if (_DayBlock == null)
                {
                    _DayBlock = new GenericRepository<DayBlock>(_dbcontext);
                }
                return _DayBlock;
            }
        }
        public IGenericRepository<Instructor> Instructor
        {
            get
            {
                if (_Instructor == null)
                {
                    _Instructor = new GenericRepository<Instructor>(_dbcontext);
                }
                return _Instructor;
            }
        }
        public IGenericRepository<InstructorLoad> InstructorLoad
        {
            get
            {
                if (_InstructorLoad == null)
                {
                    _InstructorLoad = new GenericRepository<InstructorLoad>(_dbcontext);
                }
                return _InstructorLoad;
            }
        }
        public IGenericRepository<InstructorRelease> InstructorRelease
        {
            get
            {
                if (_InstructorRelease == null)
                {
                    _InstructorRelease = new GenericRepository<InstructorRelease>(_dbcontext);
                }
                return _InstructorRelease;
            }
        }

        public IGenericRepository<InstructorUniProgram> InstructorUniProgram
        {
            get
            {
                if (_InstructorUniProgram == null)
                {
                    _InstructorUniProgram = new GenericRepository<InstructorUniProgram>(_dbcontext);
                }
                return _InstructorUniProgram;
            }
        }

        public IGenericRepository<InstructorWishlist> InstructorWishlist
        {
            get
            {
                if (_InstructorWishlist == null)
                {
                    _InstructorWishlist = new GenericRepository<InstructorWishlist>(_dbcontext);
                }
                return _InstructorWishlist;
            }
        }

        public IGenericRepository<InstructorWishlistDetails> InstructorWishlistDetails
        {
            get
            {
                if (_InstructorWishlistDetails == null)
                {
                    _InstructorWishlistDetails = new GenericRepository<InstructorWishlistDetails>(_dbcontext);
                }
                return _InstructorWishlistDetails;
            }
        }

        public IGenericRepository<Major> Major
        {
            get
            {
                if (_Major == null)
                {
                    _Major = new GenericRepository<Major>(_dbcontext);
                }
                return _Major;
            }
        }

        public IGenericRepository<MeetingTime> MeetingTime
        {
            get
            {
                if (_MeetingTime == null)
                {
                    _MeetingTime = new GenericRepository<MeetingTime>(_dbcontext);
                }
                return _MeetingTime;
            }
        }

        public IGenericRepository<Modality> Modality
        {
            get
            {
                if (_Modality == null)
                {
                    _Modality = new GenericRepository<Modality>(_dbcontext);
                }
                return _Modality;
            }
        }

        public IGenericRepository<PartOfTerm> PartOfTerm
        {
            get
            {
                if (_PartOfTerm == null)
                {
                    _PartOfTerm = new GenericRepository<PartOfTerm>(_dbcontext);
                }
                return _PartOfTerm;
            }
        }

        public IGenericRepository<PayModel> PayModel
        {
            get
            {
                if (_PayModel == null)
                {
                    _PayModel = new GenericRepository<PayModel>(_dbcontext);
                }
                return _PayModel;
            }
        }

        public IGenericRepository<PreReq> PreReq
        {
            get
            {
                if (_PreReq == null)
                {
                    _PreReq = new GenericRepository<PreReq>(_dbcontext);
                }
                return _PreReq;
            }
        }

        public IGenericRepository<Role> Role
        {
            get
            {
                if (_Role == null)
                {
                    _Role = new GenericRepository<Role>(_dbcontext);
                }
                return _Role;
            }
        }

        public IGenericRepository<RoomConfig> RoomConfig
        {
            get
            {
                if (_RoomConfig == null)
                {
                    _RoomConfig = new GenericRepository<RoomConfig>(_dbcontext);
                }
                return _RoomConfig;
            }
        }

        public IGenericRepository<Section> Section
        {
            get
            {
                if (_Section == null)
                {
                    _Section = new GenericRepository<Section>(_dbcontext);
                }
                return _Section;
            }
        }

        public IGenericRepository<SectionStatus> SectionStatus
        {
            get
            {
                if (_SectionStatus == null)
                {
                    _SectionStatus = new GenericRepository<SectionStatus>(_dbcontext);
                }
                return _SectionStatus;
            }
        }

        public IGenericRepository<Semester> Semester
        {
            get
            {
                if (_Semester == null)
                {
                    _Semester = new GenericRepository<Semester>(_dbcontext);
                }
                return _Semester;
            }
        }

        public IGenericRepository<SemesterStatus> SemesterStatus
        {
            get
            {
                if (_SemesterStatus == null)
                {
                    _SemesterStatus = new GenericRepository<SemesterStatus>(_dbcontext);
                }
                return _SemesterStatus;
            }
        }

        public IGenericRepository<SemesterType> SemesterType
        {
            get
            {
                if (_SemesterType == null)
                {
                    _SemesterType = new GenericRepository<SemesterType>(_dbcontext);
                }
                return _SemesterType;
            }
        }

        public IGenericRepository<Student> Student
        {
            get
            {
                if (_Student == null)
                {
                    _Student = new GenericRepository<Student>(_dbcontext);
                }
                return _Student;
            }
        }

        public IGenericRepository<StudentWishlist> StudentWishlist
        {
            get
            {
                if (_StudentWishlist == null)
                {
                    _StudentWishlist = new GenericRepository<StudentWishlist>(_dbcontext);
                }
                return _StudentWishlist;
            }
        }

        public IGenericRepository<TimeBlock> TimeBlock
        {
            get
            {
                if (_TimeBlock == null)
                {
                    _TimeBlock = new GenericRepository<TimeBlock>(_dbcontext);
                }
                return _TimeBlock;
            }
        }

        public IGenericRepository<UniProgram> UniProgram
        {
            get
            {
                if (_UniProgram == null)
                {
                    _UniProgram = new GenericRepository<UniProgram>(_dbcontext);
                }
                return _UniProgram;
            }
        }

        public IGenericRepository<User> User
        {
            get
            {
                if (_User == null)
                {
                    _User = new GenericRepository<User>(_dbcontext);
                }
                return _User;
            }
        }

        public IGenericRepository<UserRole> UserRole
        {
            get
            {
                if (_UserRole == null)
                {
                    _UserRole = new GenericRepository<UserRole>(_dbcontext);
                }
                return _UserRole;
            }
        }

        public IGenericRepository<WhoPays> WhoPays
        {
            get
            {
                if (_WhoPays == null)
                {
                    _WhoPays = new GenericRepository<WhoPays>(_dbcontext);
                }
                return _WhoPays;
            }
        }

        public int Commit()
        {
            return _dbcontext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
