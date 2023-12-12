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
        [BindProperty]
        public StudentWishlistDetails objStudentWishlistDetails { get; set; }
        [BindProperty]
        public List<StudentWishlistModality> objStudentWishlistModality { get; set; }
        [BindProperty]
        public List<StudentTime> objStudentTime { get; set; }


        public DeleteModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            objStudentWishlist = new StudentWishlist();
            objStudentWishlistDetails = new StudentWishlistDetails();
            objStudentWishlistModality = new List<StudentWishlistModality>();
            objStudentTime = new List<StudentTime>();

        }

        public IActionResult OnGet(int? id, int? wishlist)
        {
            objStudentWishlist = _unitOfWork.StudentWishlist.GetById(wishlist);
            objStudentWishlistDetails = _unitOfWork.StudentWishlistDetails.GetById(id);
            objStudentWishlistDetails.Course = _unitOfWork.Course.GetById(objStudentWishlistDetails.CourseId);
            
            foreach(var item in _unitOfWork.StudentWishlistModality.GetAll(c => c.StudentWishListDetailsId == id))
            {
                item.Modality = _unitOfWork.Modality.GetById(item.ModalityId);
                objStudentWishlistModality.Add(item);
            }

            foreach (var item in objStudentWishlistModality)
            {
                foreach (var time in _unitOfWork.StudentTime.GetAll(c => c.StudentWishlistModalityId == item.StudentWishlistModalityId))
                {
                    time.Campus = _unitOfWork.Campus.GetById(time.CampusId);
                    time.TimeBlock = _unitOfWork.TimeBlock.GetById(time.TimeBlockId);
                    objStudentTime.Add(time);
                }
            }


            if (objStudentWishlist == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            var studentWishlistDetails = _unitOfWork.StudentWishlistDetails.GetById(objStudentWishlistDetails.StudentWishlistDetailsId);
            List<StudentWishlistModality> modalities = new List<StudentWishlistModality>();
            List<StudentTime> times = new List<StudentTime>();

            foreach (var modality in _unitOfWork.StudentWishlistModality.GetAll(c => c.StudentWishListDetailsId == studentWishlistDetails.StudentWishlistDetailsId))
            {
                modalities.Add(modality);
            }

            foreach (var modality in modalities)
            {
                foreach (var time in _unitOfWork.StudentTime.GetAll(c => c.StudentWishlistModalityId == modality.StudentWishlistModalityId))
                {
                    times.Add(time);
                }
            }

            foreach (var time in times)
            {
                _unitOfWork.StudentTime.Delete(time);
            }

            foreach (var modality in modalities)
            {
                _unitOfWork.StudentWishlistModality.Delete(modality);
            }

            int semesterId = _unitOfWork.StudentWishlist.GetById(studentWishlistDetails.StudentWishlistId).SemesterId;
            _unitOfWork.StudentWishlistDetails.Delete(studentWishlistDetails);

            TempData["success"] = "Product Deleted Successfully";
            _unitOfWork.Commit();
            return RedirectToPage("./StudentWishlistHome", new { semesterId = semesterId });
        }
    }
}
