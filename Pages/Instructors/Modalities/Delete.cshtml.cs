using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Instructors.Modalities
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public InstructorWishlistModality objModalityList { get; set; }
        public Modality objMod { get; set; }
        public DeleteModel(UnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
            objModalityList = new InstructorWishlistModality();
            objMod = new Modality();
        }
        public IActionResult OnGet(int? id)
        {
            if (id != 0)
            {
                objModalityList = _unitOfWork.InstructorWishlistModality.GetById(id);
                objMod = _unitOfWork.Modality.GetById(objModalityList.ModalityId);
            }

            if (objModalityList == null)
            {
                return NotFound();
            }

            return Page();

        }

        public IActionResult OnPost()
        {
            string redirect = "./Index?id=" + objModalityList.InstructorWishListDetailsId;

            if (!ModelState.IsValid)
            {
                TempData["error"] = "Data Error unable to connect to DB";
                return Page();
            }
            else
            {
                _unitOfWork.InstructorWishlistModality.Delete(objModalityList);
                TempData["success"] = "Modality Deleted Successfully";
            }

            _unitOfWork.Commit();
            return Redirect(redirect);
        }
    }
}
