using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Students.Modalities
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public IEnumerable<StudentWishlistModality> objModalityList;
        public int? createId;
        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objModalityList = new List<StudentWishlistModality>();
        }

        public IActionResult OnGet(int? id)
        {
            createId = id;
            objModalityList = _unitOfWork.StudentWishlistModality.GetAll().Where(c => c.StudentWishListDetailsId == id);
            foreach(StudentWishlistModality obj in  objModalityList)
            {
                obj.Modality = _unitOfWork.Modality.GetById(obj.ModalityId);
            }
            return Page();
        }
    }
}
