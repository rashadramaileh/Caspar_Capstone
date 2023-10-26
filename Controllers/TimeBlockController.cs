using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeBlockController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public TimeBlockController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.TimeBlock.GetAll() });
        }
    }
}
