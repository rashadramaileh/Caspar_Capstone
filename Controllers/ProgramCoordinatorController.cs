using DataAccess;
using Microsoft.AspNetCore.Mvc;


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
        public IActionResult OnGet(int? id)
        {
            return Json(new
            {
                data = _unitOfWork.Section.GetAll(null, null, "Campus,Course,Modality,ApplicationUser,MeetingTime,DayBlock,Classroom,PartOfTerm,PayModel,WhoPays,SectionStatus,Semester")
                .Where(x => x.SemesterId == id)
            });
        }
    }
}
