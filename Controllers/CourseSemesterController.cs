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
        public IActionResult OnGet(int? id)
        {
            return Json(new { data = _unitOfWork.CourseSemester.GetAll(null,null,"SemesterType,Course").Where(c => c.SemesterTypeId == id) }); // added the .Where statement delete if not working
        }
    }
}
