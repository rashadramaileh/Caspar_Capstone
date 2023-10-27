using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManageRoomConfig
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        [BindProperty]
        public RoomConfig objRoomConfig { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objRoomConfig = new RoomConfig();
        }
        public IActionResult OnGet(int? id)
        {
            //assuming am i in edit mode:
            if (id != 0)
            {
                objRoomConfig = _unitOfWork.RoomConfig.GetById(id);
            }
            if (objRoomConfig == null) //nothing found in database
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
            if (objRoomConfig.RoomConfigId == 0)
            {
                _unitOfWork.RoomConfig.Add(objRoomConfig);    //not saved to database yet.
                TempData["success"] = "Pay Model added successfully.";
            }

            //if exists
            else
            {
                _unitOfWork.RoomConfig.Update(objRoomConfig);
                TempData["success"] = "Pay Model updated successfully.";
            }

            _unitOfWork.Commit();  //saves changes to database.
            return RedirectToPage("./Index");
        }
    }
}
