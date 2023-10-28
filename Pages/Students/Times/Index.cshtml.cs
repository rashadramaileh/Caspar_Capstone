using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Students.Times
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public IEnumerable<StudentTime> objTimeList;
        public int? createId;
        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objTimeList = new List<StudentTime>();
        }

        public IActionResult OnGet(int? id)
        {
            createId = id;
            objTimeList = _unitOfWork.StudentTime.GetAll().Where(c => c.StudentWishlistModalityId == id);
            foreach (StudentTime obj in objTimeList)
            {
                obj.TimeBlock = _unitOfWork.TimeBlock.GetById(obj.TimeBlockId);
                obj.Campus = _unitOfWork.Campus.GetById(obj.CampusId);
            }
            return Page();
        }
    }
}
