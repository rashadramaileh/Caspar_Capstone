using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentWishlistDetailsController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public StudentWishlistDetailsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult OnGet(int? id)
        {
            return Json(new { data = _unitOfWork.StudentWishlistDetails.GetAll(null, null, "Course,StudentWishlist").Where(c => c.StudentWishlistDetailsId == id) });
        }
    }
}
