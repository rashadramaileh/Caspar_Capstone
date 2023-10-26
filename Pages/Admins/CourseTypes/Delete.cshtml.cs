using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.CourseTypes
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public CourseType objCourseType { get; set; }
        public DeleteModel(UnitOfWork unit, IWebHostEnvironment web)
        {
            _unitOfWork = unit;
            objCourseType = new CourseType();
        }
        public IActionResult OnGet(int? id)
        {

            objCourseType = _unitOfWork.CourseType.GetById(id);
            if (objCourseType == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(int? id)
        {
            var objCrsType = _unitOfWork.CourseType.GetById(id);
            if (objCrsType == null)
            {
                return NotFound();
            }
            _unitOfWork.CourseType.Delete(objCrsType);
            TempData["success"] = "Course Type Deleted Successfully";
            _unitOfWork.Commit();

            return RedirectToPage("./Index");
        }
    }
}
