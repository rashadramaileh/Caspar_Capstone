using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.SemesterTypes
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public SemesterType objSemesterType { get; set; }
        public List<SelectListItem> isActiveList { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objSemesterType = new SemesterType();
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
                objSemesterType = _unitOfWork.SemesterType.GetById(id);
            }

            if (objSemesterType == null)
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

            if (objSemesterType.SemesterTypeId == 0)
            {
                _unitOfWork.SemesterType.Add(objSemesterType);
                TempData["success"] = "Semester Type Added Successfully";
            }

            else
            {
                _unitOfWork.SemesterType.Update(objSemesterType);
                TempData["success"] = "Semester Type Updated Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
