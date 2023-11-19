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
        public Instructor instructor { get; set; }


        public IActionResult OnGet(int id)
        {



            return Page();
        }
    }
}
