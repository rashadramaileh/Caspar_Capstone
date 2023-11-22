using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.MeetingTimes
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public MeetingTime objMeetingTime { get; set; }
        public List<SelectListItem> isActiveList { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objMeetingTime = new MeetingTime();
            isActiveList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? id)
        {
            var active = new SelectListItem
            {
                Text = "Active",
                Value = 1.ToString()
            };
            var inActive = new SelectListItem
            {
                Text = "Inactive",
                Value = 0.ToString()
            };
            isActiveList.Add(inActive);
            isActiveList.Add(active);

            if (id != 0)
            {
                objMeetingTime = _unitOfWork.MeetingTime.GetById(id);
            }

            if (objMeetingTime == null)
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

            if (objMeetingTime.meetingTimeId == 0)
            {
                _unitOfWork.MeetingTime.Add(objMeetingTime);
                TempData["success"] = "Meeting Time Added Successfully";
            }

            else
            {
                _unitOfWork.MeetingTime.Update(objMeetingTime);
                TempData["success"] = "Meeting Time Updated Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
