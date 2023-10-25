using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorWishlistController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public InstructorWishlistController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.InstructorWishlist.GetAll(null, null, null) });
        }
    }
}
