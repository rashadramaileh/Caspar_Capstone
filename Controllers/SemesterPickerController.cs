using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterPickerController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public SemesterPickerController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult OnGet()
        {
            return Json(new { data = _unitOfWork.Semester.GetAll(null, null, "SemesterType,SemesterStatus") });
        }
    }
}
