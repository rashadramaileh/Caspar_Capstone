using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorWishlistDetailsController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public InstructorWishlistDetailsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult OnGet(int? id)
        {
            return Json(new { data = _unitOfWork.InstructorWishlistDetails.GetAll(null, null, "Course,InstructorWishlist").Where(c => c.InstructorWishlistDetailsId == id) });
        }
    }
}
