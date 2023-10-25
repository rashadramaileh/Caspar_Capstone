using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.PartOfTerms
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public PartOfTerm objPartTerm { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objPartTerm = new PartOfTerm();
        }

        public IActionResult OnGet(int? id)
        {

            if (id != 0)
            {
                objPartTerm = _unitOfWork.PartOfTerm.GetById(id);
            }

            if (objPartTerm == null)
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

            if (objPartTerm.PartOfTermID == 0)
            {
                _unitOfWork.PartOfTerm.Add(objPartTerm);
                TempData["success"] = "Part Of Term Added Successfully";
            }

            else
            {
                _unitOfWork.PartOfTerm.Update(objPartTerm);
                TempData["success"] = "Part Of Term Updated Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
