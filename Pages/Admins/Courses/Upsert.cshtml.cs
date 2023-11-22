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
        public List<SelectListItem> isActiveList { get; set; }
        public int? savedId;

        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objCourse = new Course();
            UniProgramList = new List<SelectListItem>();
            isActiveList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? id)
        {
            UniProgramList = _unitOfWork.UniProgram.GetAll().Where(c => c.IsActive == 1).Select( c=> new SelectListItem 
            {
                Text = c.ProgramName,
                Value = c.UniProgramId.ToString()
            });

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
            
            if(id == null)
            {
                id = 0;
            }
            savedId = id;

            if (id > 0)
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
                return RedirectToPage(new { id = savedId.ToString() });
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
