using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.ProgramCoordinator
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        public Section objSection { get; set; }
        //TODO add lists for all section objects. 
        IEnumerable<SelectListItem> listUsers { get; set; }

        public UpsertModel(UnitOfWork unit)
        {
            _unitOfWork = unit;
            objSection = new Section();
            listUsers = new List<SelectListItem>();
        }

        /// <summary>
        /// Create a new section for the semster with SemesterId == id
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(int id)
        {
            //populate dropdown lists. 
            listUsers = _unitOfWork.ApplicationUser.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.FullName,
                    Value = c.Id
                }); //TODO filter by role


        }

    }
}
