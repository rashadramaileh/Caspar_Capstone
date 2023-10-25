using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.UniPrograms
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public UniProgram objUniProgram { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objUniProgram = new UniProgram();
        }

        public IActionResult OnGet(int? id)
        {

            if (id != 0)
            {
                objUniProgram = _unitOfWork.UniProgram.GetById(id);
            }

            if (objUniProgram == null)
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

            if (objUniProgram.UniProgramId == 0)
            {
                _unitOfWork.UniProgram.Add(objUniProgram);
                TempData["success"] = "Uni Program Added Successfully";
            }

            else
            {
                _unitOfWork.UniProgram.Update(objUniProgram);
                TempData["success"] = "Uni Program Updated Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
