using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorLandingController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public InstructorLandingController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult OnGet()
        {
            return Json(new { data = _unitOfWork.InstructorWishlist.GetAll(null, null, "Semester,Instructor") });
        }
    }
}
