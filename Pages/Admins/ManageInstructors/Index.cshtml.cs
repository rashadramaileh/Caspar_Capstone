using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManageInstructors
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitofwork;
        
        [BindProperty]
        public IEnumerable<Instructor> objInstructorList { get; set; }

        public IndexModel(UnitOfWork unit)
        {
            _unitofwork = unit;
            objInstructorList = new List<Instructor>();
        }


        public IActionResult OnGet()
        {
            objInstructorList = _unitofwork.Instructor.GetAll(null,null,"User");

            return Page();
        }
    }
}
