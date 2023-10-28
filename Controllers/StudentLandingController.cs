using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentLandingController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public StudentLandingController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult OnGet()
        {
            return Json(new { data = _unitOfWork.StudentWishlist.GetAll(null, null, "Semester,Student") });
        }
    }
}
