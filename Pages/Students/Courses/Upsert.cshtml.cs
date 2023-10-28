using CASPAR.Infrastructure.Models;
using DataAccess;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Students.Courses
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public StudentWishlistDetails objStudentWishlistDetails { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }
        public int students;
        public UpsertModel(UnitOfWork unitOfWork)
        {
            students = 0;
            _unitOfWork = unitOfWork;
            objStudentWishlistDetails = new StudentWishlistDetails();
            CourseList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? id, int? student)
        {
            CourseList = _unitOfWork.Course.GetAll().Select(c => new SelectListItem
            {
                Text = c.CoursePrefix + c.CourseNumber + " " + c.CourseName,
                Value = c.CourseId.ToString()
            });

            students = (int)student;
            objStudentWishlistDetails.StudentWishlistId = students;


            if (id != 0)
            {
                objStudentWishlistDetails = _unitOfWork.StudentWishlistDetails.GetById(id);
            }

            if (objStudentWishlistDetails == null)
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

            if (objStudentWishlistDetails.StudentWishlistDetailsId == 0)
            {
                _unitOfWork.StudentWishlistDetails.Add(objStudentWishlistDetails);
                TempData["success"] = "Student Wishlist Added Successfully";
            }

            else
            {
                _unitOfWork.StudentWishlistDetails.Update(objStudentWishlistDetails);
                TempData["success"] = "Student Wishlist Updated Successfully";
            }

            _unitOfWork.Commit();
            return Redirect("./WishlistDetails?id=" + objStudentWishlistDetails.StudentWishlistId);
        }
    }
}
