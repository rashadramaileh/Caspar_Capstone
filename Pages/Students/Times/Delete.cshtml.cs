using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Students.Times
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public StudentTime objTimeList { get; set; }
        public Campus objCampus { get; set; }
        public TimeBlock objTimeBlock { get; set; }
        public DeleteModel(UnitOfWork unitOfWOrk)
        {
            _unitOfWork = unitOfWOrk;
            objTimeList = new StudentTime();
            objCampus = new Campus();
            objTimeBlock = new TimeBlock();
        }
        public IActionResult OnGet(int? id)
        {
            if (id != 0)
            {
                objTimeList = _unitOfWork.StudentTime.GetById(id);
                objCampus = _unitOfWork.Campus.GetById(objTimeList.CampusId);
                objTimeBlock = _unitOfWork.TimeBlock.GetById(objTimeList.TimeBlockId);

            }

            if (objTimeList == null)
            {
                return NotFound();
            }

            

            return Page();

        }

        public IActionResult OnPost()
        {
            string redirect = "./Index?id=" + objTimeList.StudentWishlistModalityId;

            if (!ModelState.IsValid)
            {
                TempData["error"] = "Data Error unable to connect to DB";
                return Page();
            }
            else
            {
                _unitOfWork.StudentTime.Delete(objTimeList);
                TempData["success"] = "Modality Deleted Successfully";
            }

            _unitOfWork.Commit();
            return Redirect(redirect);
        }
    }
}
