using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Instructors.Modalities
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public IEnumerable<InstructorWishlistModality> objModalityList;
        public int? createId;
        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objModalityList = new List<InstructorWishlistModality>();
        }

        public IActionResult OnGet(int? id)
        {
            createId = id;
            objModalityList = _unitOfWork.InstructorWishlistModality.GetAll().Where(c => c.InstructorWishListDetailsId == id);
            foreach (InstructorWishlistModality obj in objModalityList)
            {
                obj.Modality = _unitOfWork.Modality.GetById(obj.ModalityId);
            }
            return Page();
        }
    }
}
