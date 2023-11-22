using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.TimeBlocks
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public TimeBlock objTimeBlock { get; set; }
        public DeleteModel(UnitOfWork unit, IWebHostEnvironment web)
        {
            _unitOfWork = unit;
            objTimeBlock = new TimeBlock();
        }
        public IActionResult OnGet(int? id)
        {

            objTimeBlock = _unitOfWork.TimeBlock.GetById(id);
            if (objTimeBlock == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(int? id)
        {
            var objType = _unitOfWork.TimeBlock.GetById(id);
            if (objType == null)
            {
                return NotFound();
            }
            _unitOfWork.TimeBlock.Delete(objType);
            TempData["success"] = "Time Block Deleted Successfully";
            _unitOfWork.Commit();

            return RedirectToPage("./Index");
        }
    }
}
