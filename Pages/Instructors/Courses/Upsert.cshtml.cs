using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Instructors.Courses
{

    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public InstructorWishlistDetails objInstructorWishlistDetails { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }
        public IEnumerable<SelectListItem> RankingList { get; set; }
        public int instructors;
        public UpsertModel(UnitOfWork unitOfWork)
        {
            instructors = 0;
            _unitOfWork = unitOfWork;
            objInstructorWishlistDetails = new InstructorWishlistDetails();
            RankingList = new List<SelectListItem>();
            CourseList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? id, int? instructor)
        {
            CourseList = _unitOfWork.Course.GetAll().Select(c => new SelectListItem
            {
                Text = c.CoursePrefix + c.CourseNumber + " " + c.CourseName,
                Value = c.CourseId.ToString()
            });
            List<int> Rankings = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                Rankings.Add(i);
            }
            RankingList = Rankings
                .Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = x.ToString(),
                });
            instructors = (int)instructor;
            objInstructorWishlistDetails.InstructorWishlistId = instructors;


            if (id != 0)
            {
                objInstructorWishlistDetails = _unitOfWork.InstructorWishlistDetails.GetById(id);
            }

            if (objInstructorWishlistDetails == null)
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

            if (objInstructorWishlistDetails.InstructorWishlistDetailsId == 0)
            {
                _unitOfWork.InstructorWishlistDetails.Add(objInstructorWishlistDetails);
                TempData["success"] = "Student Wishlist Added Successfully";
            }

            else
            {
                _unitOfWork.InstructorWishlistDetails.Update(objInstructorWishlistDetails);
                TempData["success"] = "Student Wishlist Updated Successfully";
            }

            _unitOfWork.Commit();
            return Redirect("./WishlistDetails?id=" + objInstructorWishlistDetails.InstructorWishlistId);
        }
    }
}
