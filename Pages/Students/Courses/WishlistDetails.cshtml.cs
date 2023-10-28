using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CASPAR.Pages.Students.Courses
{
    public class WishlistDetailsModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public IEnumerable<StudentWishlistDetails> objDetailsList;
        public int? createId;
        public WishlistDetailsModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objDetailsList = new List<StudentWishlistDetails>();
        }

        public IActionResult OnGet(int? id)
        {
            createId = id;
            objDetailsList = _unitOfWork.StudentWishlistDetails.GetAll().Where(c => c.StudentWishlistId == id);
            foreach (StudentWishlistDetails obj in objDetailsList)
            {
                obj.Course = _unitOfWork.Course.GetById(obj.CourseId);
            }
            return Page();
        }
    }
}
