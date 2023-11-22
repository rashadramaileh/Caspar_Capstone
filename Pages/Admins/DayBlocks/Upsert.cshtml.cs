using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.DayBlocks
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public DayBlock objDayBlock { get; set; }
        public List<SelectListItem> isActiveList { get; set; }

        public UpsertModel(UnitOfWork unitOfWork)
        {
            isActiveList = new List<SelectListItem>();

            _unitOfWork = unitOfWork;
            objDayBlock = new DayBlock();
        }

        public IActionResult OnGet(int? id)
        {
            var active = new SelectListItem
            {
                Text = "Active",
                Value = 1.ToString()
            };
            var inActive = new SelectListItem
            {
                Text = "Inactive",
                Value = 0.ToString()
            };
            isActiveList.Add(inActive);
            isActiveList.Add(active);

            if (id != 0)
            {
                objDayBlock = _unitOfWork.DayBlock.GetById(id);
            }

            if (objDayBlock == null)
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

            if (objDayBlock.DaysBlockId == 0)
            {
                _unitOfWork.DayBlock.Add(objDayBlock);
                TempData["success"] = "Day Block Added Successfully";
            }

            else
            {
                _unitOfWork.DayBlock.Update(objDayBlock);
                TempData["success"] = "Day Block Updated Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
