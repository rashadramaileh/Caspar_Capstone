using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManageBuilding
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public Building objBuilding { get; set; }
        public DeleteModel(UnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
            objBuilding = new Building();
        }
        public IActionResult OnGet(int? id)
        {
            if (id != 0)
            {
                objBuilding = _unitOfWork.Building.GetById(id);
            }

            if (objBuilding == null)
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
                _unitOfWork.Building.Delete(objBuilding);
                TempData["success"] = "Day Block Deleted Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
