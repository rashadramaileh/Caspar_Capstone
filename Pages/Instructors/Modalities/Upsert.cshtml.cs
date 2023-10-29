using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Instructors.Modalities
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public InstructorWishlistModality objModality { get; set; }
        public IEnumerable<SelectListItem> ModalityList { get; set; }
        public int instructors;
        public UpsertModel(UnitOfWork unitOfWork)
        {
            instructors = 0;
            _unitOfWork = unitOfWork;
            objModality = new InstructorWishlistModality();
            ModalityList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? id, int? instructor)
        {
            ModalityList = _unitOfWork.Modality.GetAll().Select(c => new SelectListItem
            {
                Text = c.ModalityName,
                Value = c.ModalityId.ToString()
            });

            instructors = (int)instructor;
            objModality.InstructorWishListDetailsId = instructors;


            if (id != 0)
            {
                objModality = _unitOfWork.InstructorWishlistModality.GetById(id);
            }

            if (objModality == null)
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

            if (objModality.InstructorWishlistModalityId == 0)
            {
                _unitOfWork.InstructorWishlistModality.Add(objModality);
                TempData["success"] = "Instructor Wishlist Added Successfully";
            }

            else
            {
                _unitOfWork.InstructorWishlistModality.Update(objModality);
                TempData["success"] = "Instructor Wishlist Updated Successfully";
            }

            _unitOfWork.Commit();
            return Redirect("./Index?id=" + objModality.InstructorWishListDetailsId);
        }
    }
}