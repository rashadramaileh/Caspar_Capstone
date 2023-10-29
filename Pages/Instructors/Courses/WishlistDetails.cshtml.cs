using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Instructors.Courses
{

    public class WishlistDetailsModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public IEnumerable<InstructorWishlistDetails> objDetailsList;
        public int? createId;
        public WishlistDetailsModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objDetailsList = new List<InstructorWishlistDetails>();
        }

        public IActionResult OnGet(int? id)
        {
            createId = id;
            objDetailsList = _unitOfWork.InstructorWishlistDetails.GetAll().Where(c => c.InstructorWishlistId == id);
            foreach (InstructorWishlistDetails obj in objDetailsList)
            {
                obj.Course = _unitOfWork.Course.GetById(obj.CourseId);
            }
            return Page();
        }
    }
}
