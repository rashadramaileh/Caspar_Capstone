using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Instructors.Times
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public InstructorTime objTime { get; set; }
        public IEnumerable<SelectListItem> TimeList { get; set; }
        public IEnumerable<SelectListItem> DayList { get; set; }
        public IEnumerable<SelectListItem> CampusList { get; set; }
        public int instructors;
        public UpsertModel(UnitOfWork unitOfWork)
        {
            instructors = 0;
            _unitOfWork = unitOfWork;
            objTime = new InstructorTime();
            TimeList = new List<SelectListItem>();
            CampusList = new List<SelectListItem>();
            DayList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? id, int? instructor)
        {
            TimeList = _unitOfWork.MeetingTime.GetAll().Select(c => new SelectListItem
            {
                Text = c.meetingTimeName,
                Value = c.meetingTimeId.ToString()
            });

            CampusList = _unitOfWork.Campus.GetAll().Select(c => new SelectListItem
            {
                Text = c.CampusName,
                Value = c.CampusId.ToString()
            });

            DayList = _unitOfWork.DayBlock.GetAll().Select(c => new SelectListItem
            {
                Text = c.DayName,
                Value = c.DaysBlockId.ToString()
            });

            instructors = (int)instructor;
            objTime.InstructorWishlistModalityId = instructors;

            if (id != 0)
            {
                objTime = _unitOfWork.InstructorTime.GetById(id);
            }

            if (objTime == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Data Incomplete";
                return Page();
            }

            if (objTime.InstructorTimeId == 0)
            {
                _unitOfWork.InstructorTime.Add(objTime);
                TempData["success"] = "Instructor Wishlist Added Successfully";
            }

            else
            {
                _unitOfWork.InstructorTime.Update(objTime);
                TempData["success"] = "Instructor Wishlist Updated Successfully";
            }

            _unitOfWork.Commit();
            return Redirect("./Index?id=" + objTime.InstructorWishlistModalityId);
        }
    }
}
