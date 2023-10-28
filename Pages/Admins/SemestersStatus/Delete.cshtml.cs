using CASPAR.Infrastructure.Models;
using DataAccess;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.SemestersStatus
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public SemesterStatus objSemesterStatus { get; set; }
        public DeleteModel(UnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
            objSemesterStatus = new SemesterStatus();
        }
        public IActionResult OnGet(int? id)
        {
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
                TempData["error"] = "Data Error unable to connect to DB";
                return Page();
            }
            else
            {
                _unitOfWork.SemesterStatus.Delete(objSemesterStatus);
                TempData["success"] = "Semester Status Deleted Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
