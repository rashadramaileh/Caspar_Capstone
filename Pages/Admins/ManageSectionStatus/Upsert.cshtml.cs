using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManageSectionStatus
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        [BindProperty]
        public SectionStatus objSectionStatus { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objSectionStatus = new SectionStatus();
        }
        public IActionResult OnGet(int? id)
        {
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
