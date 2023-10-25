using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartOfTermController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public PartOfTermController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult OnGet()
        {
            return Json(new { data = _unitOfWork.PartOfTerm.GetAll() });
        }
    }
}
