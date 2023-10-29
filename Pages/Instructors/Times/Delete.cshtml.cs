using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Instructors.Times
{

    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public InstructorTime objTimeList { get; set; }
        public Campus objCampus { get; set; }
        public MeetingTime objTimeBlock { get; set; }
        public DayBlock objDayBlock { get; set; }
        public DeleteModel(UnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
            objTimeList = new InstructorTime();
            objCampus = new Campus();
            objTimeBlock = new MeetingTime();
            objDayBlock = new DayBlock();
        }
        public IActionResult OnGet(int? id)
        {
            if (id != 0)
            {
                objTimeList = _unitOfWork.InstructorTime.GetById(id);
                objCampus = _unitOfWork.Campus.GetById(objTimeList.CampusId);
                objTimeBlock = _unitOfWork.MeetingTime.GetById(objTimeList.MeetingTimeId);
                objDayBlock = _unitOfWork.DayBlock.GetById(objTimeList.DaysBlockId);
            }

            if (objTimeList == null)
            {
                return NotFound();
            }



            return Page();

        }

        public IActionResult OnPost()
        {
            string redirect = "./Index?id=" + objTimeList.InstructorWishlistModalityId;

            if (!ModelState.IsValid)
            {
                TempData["error"] = "Data Error unable to connect to DB";
                return Page();
            }
            else
            {
                _unitOfWork.InstructorTime.Delete(objTimeList);
                TempData["success"] = "Modality Deleted Successfully";
            }

            _unitOfWork.Commit();
            return Redirect(redirect);
        }
    }
}
