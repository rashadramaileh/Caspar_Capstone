using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;


namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProgramCoordinatorController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public ProgramCoordinatorController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult OnGet(int id)
        {
            if (id == 0) { id = 2; }

            return Json(new
            {
                data = _unitOfWork.Section.GetAll(null, null, "Campus,Course,Modality,ApplicationUser,MeetingTime,DayBlock,Classroom,PartOfTerm,PayModel,WhoPays,SectionStatus,Semester")
                .Where(x => x.SemesterId == id)
            });

            //IEnumerable<Section> sections = _unitOfWork.Section.GetAll(null, null, "Campus,Course,Modality,ApplicationUser,MeetingTime,DayBlock,Classroom,PartOfTerm,PayModel,WhoPays,SectionStatus,Semester")
            //    .Where(x => x.SemesterId == id);

            //Semester semester = _unitOfWork.Semester.GetById(id);
            //IEnumerable<Campus> campuses = _unitOfWork.Campus.GetAll();
            //IEnumerable<Building> buildings = _unitOfWork.Building.GetAll();
            //IEnumerable<Course> courses = _unitOfWork.Course.GetAll();
            //IEnumerable<Modality> modalities = _unitOfWork.Modality.GetAll();
            //IEnumerable<ApplicationUser> applicationUsers = _unitOfWork.ApplicationUser.GetAll(); //TODO filter for instructors
            //IEnumerable<MeetingTime> meetingTimes = _unitOfWork.MeetingTime.GetAll();
            //IEnumerable<DayBlock> dayBlocks = _unitOfWork.DayBlock.GetAll();
            //IEnumerable<Classroom> classrooms = _unitOfWork.Classroom.GetAll();
            //IEnumerable<PartOfTerm> partOfTerms = _unitOfWork.PartOfTerm.GetAll();
            //IEnumerable<PayModel> payModels = _unitOfWork.PayModel.GetAll();
            //IEnumerable<WhoPays> whoPayss = _unitOfWork.WhoPays.GetAll();
            //IEnumerable<SectionStatus> sectionStatuses = _unitOfWork.SectionStatus.GetAll();

            ////Loop to add all of these items to the Section
            //foreach (Section s in sections)
            //{
            //    s.Semester = semester;
            //    s.Classroom = classrooms.FirstOrDefault(i => i.ClassroomId == s.ClassroomId);
            //    //s.Classroom.Building = buildings.FirstOrDefault(b => b.BuildingId == s.Classroom.BuildingId);
            //    s.Campus = campuses.FirstOrDefault(c => c.CampusId == s.CampusId);
            //    s.Course = courses.FirstOrDefault(c => c.CourseId == s.CourseId);
            //    s.Modality = modalities.FirstOrDefault(m => m.ModalityId == s.ModalityId);
            //    s.ApplicationUser = applicationUsers.FirstOrDefault(a => a.Id == s.ApplicationUserId);
            //    s.MeetingTime = meetingTimes.FirstOrDefault(m => m.meetingTimeId == s.MeetingTimeId);
            //    s.DayBlock = dayBlocks.FirstOrDefault(d => d.DaysBlockId == s.DayBlockId);
            //    s.PartOfTerm = partOfTerms.FirstOrDefault(p => p == s.PartOfTerm); // trying to get in Includes
            //    s.PayModel = payModels.FirstOrDefault(p => p.PayModelId == s.PayModelId);
            //    s.WhoPays = whoPayss.FirstOrDefault(w => w.WhoPaysId == s.WhoPaysId);
            //    s.SectionStatus = sectionStatuses.FirstOrDefault(t => t.SectionStatusId == s.SectionStatusId);
            //}

            //return Json(new
            //{
            //    data = sections
            //});


        }
    }
}
