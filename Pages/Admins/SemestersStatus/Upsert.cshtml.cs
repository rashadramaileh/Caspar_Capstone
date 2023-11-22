using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.SemestersStatus
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public SemesterStatus objSemesterStatus { get; set; }
        public List<SelectListItem> isActiveList { get; set; }

        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objSemesterStatus = new SemesterStatus();
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
                objSemesterStatus = _unitOfWork.SemesterStatus.GetById(id);
            }

            if (objSemesterStatus == null)
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

            if (objSemesterStatus.SemesterStatusID == 0)
            {
                _unitOfWork.SemesterStatus.Add(objSemesterStatus);
                TempData["success"] = "Semester Status Added Successfully";
            }

            else
            {
                _unitOfWork.SemesterStatus.Update(objSemesterStatus);
                TempData["success"] = "Semester Status Updated Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
