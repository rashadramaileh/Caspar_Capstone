using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.SemesterTypes
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public SemesterType objSemesterType { get; set; }
        public DeleteModel(UnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
            objSemesterType = new SemesterType();
        }
        public IActionResult OnGet(int? id)
        {
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
                TempData["error"] = "Data Error unable to connect to DB";
                return Page();
            }
            else
            {
                _unitOfWork.SemesterType.Delete(objSemesterType);
                TempData["success"] = "Semester Type Deleted Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
