using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManageBuilding
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public List<Building> objBuilding;

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objBuilding = new List<Building>();
        }
        public IActionResult OnGet()
        {
            objBuilding = _unitOfWork.Building.GetAll().ToList();
            return Page();
        }
    }
}
