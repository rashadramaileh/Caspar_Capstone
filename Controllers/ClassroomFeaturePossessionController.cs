using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomFeaturePossessionController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public ClassroomFeaturePossessionController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.ClassroomFeaturePossession.GetAll(null,null,"Classroom,ClassroomFeature") });
        }
    }
}
