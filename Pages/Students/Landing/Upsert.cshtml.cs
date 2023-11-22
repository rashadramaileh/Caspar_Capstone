using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Students.Landing
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public StudentWishlist objStudentWishlist { get; set; }
        public IEnumerable<SelectListItem> SemesterList { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objStudentWishlist = new StudentWishlist();
            SemesterList = new List<SelectListItem>();

        }

        public IActionResult OnGet(int? id)
        {
            SemesterList = _unitOfWork.Semester.GetAll().Select(c => new SelectListItem
            {
                Text = c.SemesterName,
                Value = c.SemesterId.ToString()
            });


            if (id != 0)
            {
                objStudentWishlist = _unitOfWork.StudentWishlist.GetById(id);
            }

            if (objStudentWishlist == null)
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

            if (objStudentWishlist.StudentWishlistId == 0)
            {
                //objStudentWishlist.StudentId = 2;
                _unitOfWork.StudentWishlist.Add(objStudentWishlist);
                TempData["success"] = "Semester Added Successfully";
            }

            else
            {
                _unitOfWork.StudentWishlist.Update(objStudentWishlist);
                TempData["success"] = "Semester Updated Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
