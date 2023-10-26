using CASPAR.Infrastructure.Models;
using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ClassroomFeatures
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public ClassroomFeature objClassroomFeature { get; set; }
        public DeleteModel(UnitOfWork unit, IWebHostEnvironment web)
        {
            _unitOfWork = unit;
            objClassroomFeature = new ClassroomFeature();
        }
        public IActionResult OnGet(int? id)
        {

            objClassroomFeature = _unitOfWork.ClassroomFeature.GetById(id);
            if (objClassroomFeature == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(int? id)
        {
            var objClassroomFeature = _unitOfWork.ClassroomFeature.GetById(id);
            if (objClassroomFeature == null)
            {
                return NotFound();
            }
            _unitOfWork.ClassroomFeature.Delete(objClassroomFeature);
            TempData["success"] = "Classroom Feature Deleted Successfully";
            _unitOfWork.Commit();

            return RedirectToPage("./Index");
        }
    }
}
