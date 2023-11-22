using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.ManageSectionStatus
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        [BindProperty]
        public SectionStatus objSectionStatus { get; set; }
        public List<SelectListItem> isActiveList { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objSectionStatus = new SectionStatus();
            isActiveList = new List<SelectListItem>();

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
            isActiveList.Add(active);
            isActiveList.Add(inActive);
            //assuming am i in edit mode:
            if (id != 0)
            {
                objSectionStatus = _unitOfWork.SectionStatus.GetById(id);
            }
            if (objSectionStatus == null) //nothing found in database
            {
                return NotFound();  //built in page.
            }

            //assuming im in create mode:
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Data incomplete.";
                return Page();
            }

            //if this is a new category
            if (objSectionStatus.SectionStatusId == 0)
            {
                //objSectionStatus.IsActive = 1;
                _unitOfWork.SectionStatus.Add(objSectionStatus);    //not saved to database yet.
                TempData["success"] = "Pay Model added successfully.";
            }

            //if exists
            else
            {
                _unitOfWork.SectionStatus.Update(objSectionStatus);
                TempData["success"] = "Pay Model updated successfully.";
            }

            _unitOfWork.Commit();  //saves changes to database.
            return RedirectToPage("./Index");
        }
    }
}
