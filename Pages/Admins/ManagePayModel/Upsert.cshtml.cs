using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManagePayModel
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        [BindProperty]
        public PayModel objPayModel { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objPayModel = new PayModel();
        }
        public IActionResult OnGet(int? id)
        {
            //assuming am i in edit mode:
            if (id != 0)
            {
                objPayModel = _unitOfWork.PayModel.GetById(id);
            }
            if (objPayModel == null) //nothing found in database
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
            if (objPayModel.PayModelId == 0)
            {
                _unitOfWork.PayModel.Add(objPayModel);    //not saved to database yet.
                TempData["success"] = "Pay Model added successfully.";
            }

            //if exists
            else
            {
                _unitOfWork.PayModel.Update(objPayModel);
                TempData["success"] = "Pay Model updated successfully.";
            }

            _unitOfWork.Commit();  //saves changes to database.
            return RedirectToPage("./Index");
        }
    }
}
