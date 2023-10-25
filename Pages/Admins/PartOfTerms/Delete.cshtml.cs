using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.PartOfTerms
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public PartOfTerm objPartTermList { get; set; }
        public DeleteModel(UnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
            objPartTermList = new PartOfTerm();
        }
        public IActionResult OnGet(int? id)
        {
            if (id != 0)
            {
                objPartTermList = _unitOfWork.PartOfTerm.GetById(id);
            }

            if (objPartTermList == null)
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
                _unitOfWork.PartOfTerm.Delete(objPartTermList);
                TempData["success"] = "Day Block Deleted Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
