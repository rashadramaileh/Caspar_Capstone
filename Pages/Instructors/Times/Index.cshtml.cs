using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Instructors.Times
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public IEnumerable<InstructorTime> objTimeList;
        public int? createId;
        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objTimeList = new List<InstructorTime>();
        }

        public IActionResult OnGet(int? id)
        {
            createId = id;
            objTimeList = _unitOfWork.InstructorTime.GetAll().Where(c => c.InstructorWishlistModalityId == id);
            foreach (InstructorTime obj in objTimeList)
            {
                obj.DayBlock = _unitOfWork.DayBlock.GetById(obj.DaysBlockId);
                obj.MeetingTime = _unitOfWork.MeetingTime.GetById(obj.MeetingTimeId);
                obj.Campus = _unitOfWork.Campus.GetById(obj.CampusId);
            }
            return Page();
        }
    }
}
