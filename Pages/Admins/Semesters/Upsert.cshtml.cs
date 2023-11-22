using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.Semesters
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public Semester objSemester { get; set; }
        public IEnumerable<SelectListItem> SemesterStatusList { get; set; }
        public IEnumerable<SelectListItem> SemesterTypeList { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objSemester = new Semester();
            SemesterStatusList = new List<SelectListItem>();
            SemesterTypeList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? id)
        {
            SemesterStatusList = _unitOfWork.SemesterStatus.GetAll().Where(c => c.IsActive == 1)
                .Select(c => new SelectListItem
                {
                Text = c.SemesterStatusName,
                Value = c.SemesterStatusID.ToString()
            });

            SemesterTypeList = _unitOfWork.SemesterType.GetAll().Where(c => c.IsActive == 1).Select(c => new SelectListItem
            {
                Text = c.SemesterName,
                Value = c.SemesterTypeId.ToString()
            });

            if (id != 0)
            {
                objSemester = _unitOfWork.Semester.GetById(id);
            }

            if (objSemester == null)
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

            if (objSemester.SemesterId == 0)
            {
                _unitOfWork.Semester.Add(objSemester);
                TempData["success"] = "Semester Added Successfully";
            }

            else
            {
                _unitOfWork.Semester.Update(objSemester);
                TempData["success"] = "Semester Updated Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
