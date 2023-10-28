using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Students.Modalities
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public StudentWishlistModality objModality { get; set; }
        public IEnumerable<SelectListItem> ModalityList { get; set; }
        public int students;
        public UpsertModel(UnitOfWork unitOfWork)
        {
            students = 0;
            _unitOfWork = unitOfWork;
            objModality = new StudentWishlistModality();
            ModalityList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? id, int? student)
        {
            ModalityList = _unitOfWork.Modality.GetAll().Select(c => new SelectListItem
            {
                Text = c.ModalityName,
                Value = c.ModalityId.ToString()
            });

            students = (int)student;
            objModality.StudentWishListDetailsId = students;


            if (id != 0)
            {
                objModality = _unitOfWork.StudentWishlistModality.GetById(id);
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

            if (objModality.StudentWishlistModalityId == 0)
            {
                _unitOfWork.StudentWishlistModality.Add(objModality);
                TempData["success"] = "Student Wishlist Added Successfully";
            }

            else
            {
                _unitOfWork.StudentWishlistModality.Update(objModality);
                TempData["success"] = "Student Wishlist Updated Successfully";
            }

            _unitOfWork.Commit();
            return Redirect("./Index?id=" + objModality.StudentWishListDetailsId);
        }
    }
}
