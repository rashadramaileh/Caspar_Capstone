using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Students.Times
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public StudentTime objTime { get; set; }
        public IEnumerable<SelectListItem> TimeList { get; set; }
        public IEnumerable<SelectListItem> CampusList { get; set; }
        public int students;
        public UpsertModel(UnitOfWork unitOfWork)
        {
            students = 0;
            _unitOfWork = unitOfWork;
            objTime = new StudentTime();
            TimeList = new List<SelectListItem>();
            CampusList = new List<SelectListItem>();
        }

        public IActionResult OnGet(int? id, int? student)
        {
            TimeList = _unitOfWork.TimeBlock.GetAll().Select(c => new SelectListItem
            {
                Text = c.TimeName,
                Value = c.TimeBlockId.ToString()
            });

            CampusList = _unitOfWork.Campus.GetAll().Select(c => new SelectListItem
            {
                Text = c.CampusName,
                Value = c.CampusId.ToString()
            });

            students = (int)student;
            objTime.StudentWishlistModalityId = students;

            if (id != 0)
            {
                objTime = _unitOfWork.StudentTime.GetById(id);
            }

            if (objTime == null)
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

            if (objTime.StudentTimeId == 0)
            {
                _unitOfWork.StudentTime.Add(objTime);
                TempData["success"] = "Student Wishlist Added Successfully";
            }

            else
            {
                _unitOfWork.StudentTime.Update(objTime);
                TempData["success"] = "Student Wishlist Updated Successfully";
            }

            _unitOfWork.Commit();
            return Redirect("./Index?id=" + objTime.StudentWishlistModalityId);
        }
    }
}
