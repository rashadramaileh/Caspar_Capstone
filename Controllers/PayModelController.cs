using DataAccess;
using Microsoft.AspNetCore.Mvc;


namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PayModelController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public PayModelController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.PayModel.GetAll() });
        }
    }
}
