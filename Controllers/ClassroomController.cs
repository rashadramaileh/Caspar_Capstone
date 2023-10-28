using DataAccess;
using Microsoft.AspNetCore.Mvc;


namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClassroomController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public ClassroomController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Classroom.GetAll(null, null, "Building") });
        }
    }
}
