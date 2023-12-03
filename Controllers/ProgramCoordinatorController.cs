using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Linq;


namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProgramCoordinatorController : Controller
    {
        public int savedId;
        private readonly UnitOfWork _unitOfWork;
        public ProgramCoordinatorController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            savedId = id;
            IEnumerable<Section> data = _unitOfWork.Section.GetAll(null, null, "Campus,Course,Modality,ApplicationUser,MeetingTime,DayBlock,Classroom,PartOfTerm,PayModel,WhoPays,SectionStatus,Semester")
                .Where(x => x.SemesterId == savedId);

            IEnumerable<PartOfTerm> pot = _unitOfWork.PartOfTerm.GetAll();
            IEnumerable<PayModel> payModel = _unitOfWork.PayModel.GetAll();
            foreach (Section s in data)
            {
                s.PayModel = payModel.FirstOrDefault(x => x.PayModelId ==s.PayModelId);
                //s.PartOfTerm = pot.FirstOrDefault();
            }

            return Json(new
            {
                data
            });

        }
    }
}
