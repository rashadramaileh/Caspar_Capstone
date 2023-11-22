using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Instructors.Landing
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public InstructorWishlist objInstructorWishlist { get; set; }
        public IEnumerable<SelectListItem> SemesterList { get; set; }
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objInstructorWishlist = new InstructorWishlist();
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
                objInstructorWishlist = _unitOfWork.InstructorWishlist.GetById(id);
            }

            if (objInstructorWishlist == null)
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

            if (objInstructorWishlist.InstructorWishlistId == 0)
            {
                //objInstructorWishlist.ApplicationUserId = 1;
                _unitOfWork.InstructorWishlist.Add(objInstructorWishlist);
                TempData["success"] = "Semester Added Successfully";
            }

            else
            {
                _unitOfWork.InstructorWishlist.Update(objInstructorWishlist);
                TempData["success"] = "Semester Updated Successfully";
            }

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
