using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.Majors
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public Major objMajor { get; set; }
        public DeleteModel(UnitOfWork unit, IWebHostEnvironment web)
        {
            _unitOfWork = unit;
            objMajor = new Major();
        }
        public IActionResult OnGet(int? id)
        {

            objMajor = _unitOfWork.Major.GetById(id);
            if (objMajor == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(int? id)
        {
            var objProduct = _unitOfWork.Major.GetById(id);
            if (objProduct == null)
            {
                return NotFound();
            }
            _unitOfWork.Major.Delete(objProduct);
            TempData["success"] = "Major Deleted Successfully";
            _unitOfWork.Commit();

            return RedirectToPage("./Index");
        }
    }
}
