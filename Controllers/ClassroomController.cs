using CASPAR.Infrastructure.Models;
using DataAccess;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CASPAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClassroomController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public ClassroomController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Classroom> classrooms = _unitOfWork.Classroom.GetAll(null, null, "Building");
            IEnumerable<Campus> campuses = _unitOfWork.Campus.GetAll();

            foreach (var classroom in classrooms)
            {
                classroom.Building.Campus = campuses.FirstOrDefault(x => x.CampusId == classroom.Building.CampusId);
            }
            return Json(new { data = classrooms });
        }
    }
}
