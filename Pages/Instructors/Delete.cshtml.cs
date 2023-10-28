using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Instructors
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public InstructorWishlist objInstructorWishlist { get; set; }
        [BindProperty]
        public InstructorWishlistDetails objInstructorWishlistDetails { get; set; }
        [BindProperty]
        public InstructorWishlistModality objInstructorWishlistModality { get; set; }
        [BindProperty]
        public InstructorTime objInstructorTime { get; set; }


        public DeleteModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult OnGet(int? id)
        {
            objInstructorWishlist = new InstructorWishlist();
            objInstructorWishlist = _unitOfWork.InstructorWishlist.GetById(id);

            if (objInstructorWishlist == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            var objInstructorWishlist = _unitOfWork.InstructorWishlist.GetById(id);
            if (objInstructorWishlist == null)
            {
                return NotFound();
            }
           

            _unitOfWork.InstructorWishlist.Delete(objInstructorWishlist);
            TempData["success"] = "Product Deleted Successfully";
            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}

