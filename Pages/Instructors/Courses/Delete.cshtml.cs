using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Instructors.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public InstructorWishlistDetails objDetailsList { get; set; }
        public Course objCourse { get; set; }
        public DeleteModel(UnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
            objDetailsList = new InstructorWishlistDetails();
            objCourse = new Course();
        }
        public IActionResult OnGet(int? id)
        {
            if (id != 0)
            {
                objDetailsList = _unitOfWork.InstructorWishlistDetails.GetById(id);
                objCourse = _unitOfWork.Course.GetById(objDetailsList.CourseId);
                objCourse.CourseName = objCourse.CoursePrefix + objCourse.CourseNumber + " " + objCourse.CourseName;
            }

            if (objDetailsList == null)
            {
                return NotFound();
            }

            return Page();

        }

        public IActionResult OnPost()
        {
            string redirect = "./WishlistDetails?id=" + objDetailsList.InstructorWishlistId;

            if (!ModelState.IsValid)
            {
                TempData["error"] = "Data Error unable to connect to DB";
                return Page();
            }
            else
            {
                _unitOfWork.InstructorWishlistDetails.Delete(objDetailsList);
                TempData["success"] = "Course Deleted Successfully";
            }

            _unitOfWork.Commit();
            return Redirect(redirect);
        }

    }
}
