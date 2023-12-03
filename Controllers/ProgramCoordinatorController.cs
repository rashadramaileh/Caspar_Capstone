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

        }
    }
}
