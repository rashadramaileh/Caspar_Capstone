using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace CASPAR.Pages.Admins.ManageCampus
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        [BindProperty]
        public Campus objCampus { get; set; }
        public List<SelectListItem> isActiveList { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objCampus = new Campus();
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
            isActiveList.Add(inActive);
            isActiveList.Add(active);
            
            
            
            //assuming am i in edit mode:
            if (id != 0)
            {
                objCampus = _unitOfWork.Campus.GetById(id);
            }
            if (objCampus == null) //nothing found in database
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
            if (objCampus.CampusId == 0)
            {
                //objCampus.IsActive = 1;
                _unitOfWork.Campus.Add(objCampus);    //not saved to database yet.
                TempData["success"] = "Campus added successfully.";
            }

            //if exists
            else
            {
                _unitOfWork.Campus.Update(objCampus);
                TempData["success"] = "Campus updated successfully.";
            }

            _unitOfWork.Commit();  //saves changes to database.
            return RedirectToPage("./Index");
        }
    }
}
