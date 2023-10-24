using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public StudentWishlist objStudentWishlist { get; set; }
        

        public DeleteModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult OnGet(int? id)
        {
            objStudentWishlist = new StudentWishlist();
            objStudentWishlist = _unitOfWork.StudentWishlist.GetById(id);

            if (objStudentWishlist == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            var objStudentWishlist = _unitOfWork.StudentWishlist.GetById(id);
            if (objStudentWishlist == null)
            {
                return NotFound();
            }


            _unitOfWork.StudentWishlist.Delete(objStudentWishlist);
            TempData["success"] = "Product Deleted Successfully";
            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
