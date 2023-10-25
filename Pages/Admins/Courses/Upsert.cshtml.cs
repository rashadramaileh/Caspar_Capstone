using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.Courses
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public Course objCourse { get; set; }
        public IEnumerable<SelectListItem> UniProgramList { get; set; }
        public IEnumerable<SelectListItem> CourseTypeList { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objCourse = new Course();
            UniProgramList = new List<SelectListItem>();
            CourseTypeList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? id)
        {
            UniProgramList = _unitOfWork.UniProgram.GetAll().Select(c => new SelectListItem
            {
                Text = c.ProgramName,
                Value = c.UniProgramId.ToString()
            });

            CourseTypeList = _unitOfWork.CourseType.GetAll().Select(c => new SelectListItem
            {
                Text = c.CourseTypeName,
                Value = c.CourseTypeId.ToString()
            });

            if (id != 0)
            {
                objCourse = _unitOfWork.Course.GetById(id);
            }

            if(objCourse == null)
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

            if(objCourse.CourseId == 0)
            {
                _unitOfWork.Course.Add(objCourse);
                TempData["success"] = "Course Added Successfully";
            }

            else
            {
                _unitOfWork.Course.Update(objCourse);
                TempData["success"] = "Course Updated Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
