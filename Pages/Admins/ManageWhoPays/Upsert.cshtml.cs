using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.ManageWhoPays
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        [BindProperty]
        public WhoPays objWhoPays { get; set; }
        public List<SelectListItem> isActiveList { get; set; }

        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objWhoPays = new WhoPays();
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
                objWhoPays = _unitOfWork.WhoPays.GetById(id);
            }
            if (objWhoPays == null) //nothing found in database
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
            if (objWhoPays.WhoPaysId == 0)
            {
                _unitOfWork.WhoPays.Add(objWhoPays);    //not saved to database yet.
                TempData["success"] = "Who Pays added successfully.";
            }

            //if exists
            else
            {
                _unitOfWork.WhoPays.Update(objWhoPays);
                TempData["success"] = "Who Pays updated successfully.";
            }

            _unitOfWork.Commit();  //saves changes to database.
            return RedirectToPage("./Index");
        }
    }
}
