using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSemesterController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public CourseSemesterController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult OnGet()
        {
            return Json(new { data = _unitOfWork.CourseSemester.GetAll(null,null,"SemesterType") });
        }
    }
}
