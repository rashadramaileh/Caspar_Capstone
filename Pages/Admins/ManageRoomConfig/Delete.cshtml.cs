using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManageRoomConfig
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public RoomConfig objRoomConfig { get; set; }
        public DeleteModel(UnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
            objRoomConfig = new RoomConfig();
        }
        public IActionResult OnGet(int? id)
        {
            if (id != 0)
            {
                objRoomConfig = _unitOfWork.RoomConfig.GetById(id);
            }

            if (objRoomConfig == null)
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
                _unitOfWork.RoomConfig.Delete(objRoomConfig);
                TempData["success"] = "Pay Model Deleted Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
