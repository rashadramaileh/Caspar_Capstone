using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ClassroomFeaturePossessions
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public ClassroomFeaturePossession objClassroomFeature { get; set; }
        public DeleteModel(UnitOfWork unit, IWebHostEnvironment web)
        {
            _unitOfWork = unit;
            objClassroomFeature = new ClassroomFeaturePossession();
        }
        public IActionResult OnGet(int? id)
        {

            objClassroomFeature = _unitOfWork.ClassroomFeaturePossession.GetById(id);
            if (objClassroomFeature == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(int? id)
        {
            var objClassroomFeature = _unitOfWork.ClassroomFeaturePossession.GetById(id);
            if (objClassroomFeature == null)
            {
                return NotFound();
            }
            _unitOfWork.ClassroomFeaturePossession.Delete(objClassroomFeature);
            TempData["success"] = "Classroom Feature Deleted Successfully";
            _unitOfWork.Commit();

            return RedirectToPage("./Index");
        }
    }
}
