using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Students.Modalities
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public StudentWishlistModality objModalityList { get; set; }
        public Modality objMod { get; set; }
        public DeleteModel(UnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
            objModalityList = new StudentWishlistModality();
            objMod = new Modality();
        }
        public IActionResult OnGet(int? id)
        {
            if (id != 0)
            {
                objModalityList = _unitOfWork.StudentWishlistModality.GetById(id);
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
            string redirect = "./Index?id=" + objModalityList.StudentWishListDetailsId;

            if (!ModelState.IsValid)
            {
                TempData["error"] = "Data Error unable to connect to DB";
                return Page();
            }
            else
            {
                _unitOfWork.StudentWishlistModality.Delete(objModalityList);
                TempData["success"] = "Modality Deleted Successfully";
            }

            _unitOfWork.Commit();
            return Redirect(redirect);
        }
    }
}
