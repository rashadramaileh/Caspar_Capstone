using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManageCampus
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public List<Campus> objCampus;

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objCampus = new List<Campus>();
        }
        public IActionResult OnGet()
        {
            objCampus = _unitOfWork.Campus.GetAll().ToList();
            return Page();
        }
    }
}
