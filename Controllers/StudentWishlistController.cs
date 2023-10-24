using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentWishlistController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public StudentWishlistController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.StudentWishlist.GetAll(null, null, null) });
        }
    }
}
