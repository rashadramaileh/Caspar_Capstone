using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Instructors
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public InstructorWishlist objInstructorWishlist { get; set; }
        [BindProperty]
        public InstructorWishlistDetails objInstructorWishlistDetails { get; set; }
        [BindProperty]
        public List<InstructorWishlistModality> objInstructorWishlistModality { get; set; }
        [BindProperty]
        public List<InstructorTime> objInstructorTime { get; set; }


        public DeleteModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            objInstructorWishlist = new InstructorWishlist();
            objInstructorWishlistDetails = new InstructorWishlistDetails();
            objInstructorWishlistModality = new List<InstructorWishlistModality>();
            objInstructorTime = new List<InstructorTime>();

        }

        public IActionResult OnGet(int? id, int? wishlist)
        {
            objInstructorWishlist = _unitOfWork.InstructorWishlist.GetById(wishlist);
            objInstructorWishlistDetails = _unitOfWork.InstructorWishlistDetails.GetById(id);
            objInstructorWishlistDetails.Course = _unitOfWork.Course.GetById(objInstructorWishlistDetails.CourseId);

            foreach (var item in _unitOfWork.InstructorWishlistModality.GetAll(c => c.InstructorWishListDetailsId == id))
            {
                item.Modality = _unitOfWork.Modality.GetById(item.ModalityId);
                objInstructorWishlistModality.Add(item);
            }

            foreach (var item in objInstructorWishlistModality)
            {
                foreach (var time in _unitOfWork.InstructorTime.GetAll(c => c.InstructorWishlistModalityId == item.InstructorWishlistModalityId))
                {
                    time.Campus = _unitOfWork.Campus.GetById(time.CampusId);
                    time.DayBlock = _unitOfWork.DayBlock.GetById(time.DaysBlockId);
                    time.MeetingTime = _unitOfWork.MeetingTime.GetById(time.MeetingTimeId);
                    objInstructorTime.Add(time);
                }
            }


            if (objInstructorWishlist == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            var InstructorWishlistDetails = _unitOfWork.InstructorWishlistDetails.GetById(objInstructorWishlistDetails.InstructorWishlistDetailsId);
            List<InstructorWishlistModality> modalities = new List<InstructorWishlistModality>();
            List<InstructorTime> times = new List<InstructorTime>();

            foreach (var modality in _unitOfWork.InstructorWishlistModality.GetAll(c => c.InstructorWishListDetailsId == InstructorWishlistDetails.InstructorWishlistDetailsId))
            {
                modalities.Add(modality);
            }

            foreach (var modality in modalities)
            {
                foreach (var time in _unitOfWork.InstructorTime.GetAll(c => c.InstructorWishlistModalityId == modality.InstructorWishlistModalityId))
                {
                    times.Add(time);
                }
            }

            foreach (var time in times)
            {
                _unitOfWork.InstructorTime.Delete(time);
            }

            foreach (var modality in modalities)
            {
                _unitOfWork.InstructorWishlistModality.Delete(modality);
            }

			int semesterId = _unitOfWork.InstructorWishlist.GetById(InstructorWishlistDetails.InstructorWishlistId).SemesterId;
			_unitOfWork.InstructorWishlistDetails.Delete(InstructorWishlistDetails);

            TempData["success"] = "Product Deleted Successfully";
            _unitOfWork.Commit();
            return RedirectToPage("./InstructorWishlistHome", new { semesterId = semesterId });
        }
    }
}
