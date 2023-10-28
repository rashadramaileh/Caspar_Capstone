using DataAccess;
using Microsoft.AspNetCore.Mvc;


namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BuildingController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public BuildingController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Building.GetAll(null,null, "Campus") });
        }
    }
}
