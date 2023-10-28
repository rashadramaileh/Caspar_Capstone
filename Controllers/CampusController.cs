using DataAccess;
using Microsoft.AspNetCore.Mvc;


namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CampusController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public CampusController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Campus.GetAll() });
        }
    }
}
