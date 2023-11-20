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
            try
            {
                var jsonData = new { data = _unitOfWork.StudentWishlist.GetAll(null, null, "StudentWishlistDetails.Course,StudentWishlistModality") };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
