using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace CASPAR.Pages.Students
{
    public class StudentWishlistVM
    {
        [BindProperty]
        public StudentWishlistDetails objStudentWishlistDetails { get; set; }
        public List<StudentWishlistModality> objStudentWishlistModalities { get; set; }
        public List<StudentTime> objStudentTimes { get; set; }
        //public IEnumerable<StudentWishlist> ListStudentWishlist { get; set; }
    }

    public class StudentWishlishtHomeModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        public StudentWishlist objStudentWishlist { get; set; }
        
        public List<StudentWishlistVM> objStudentWishlistVMs { get; set; }
        public IEnumerable<SelectListItem> SemesterList { get; set; }
        public IEnumerable<StudentWishlist> ListStudentWishlist { get; set; }
        [BindProperty] 
        public int SemesterId { get; set; }


        public StudentWishlishtHomeModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objStudentWishlist = new StudentWishlist();
            objStudentWishlistVMs = new List<StudentWishlistVM>();

            SemesterList = new List<SelectListItem>();
            ListStudentWishlist = new List<StudentWishlist>();
        }

        public void OnGet(int? semesterId)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            GetStudentWishlistData(claim.Value, semesterId);
        }

        public void OnPost()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            GetStudentWishlistData(claim.Value, SemesterId);
            TempData["Success"] = "Wishlist Filtered Successfully";
        }

        private void GetStudentWishlistData(string applicationUser, int? semesterId)
        {
            SemesterList = _unitOfWork.Semester.GetAll().OrderBy(x => x.EndDate)
                .Select(x => new SelectListItem
                {
                    Text = x.SemesterName,
                    Value = x.SemesterId.ToString(),
                });

            if (semesterId != null && semesterId !=0)
            {
                objStudentWishlist = _unitOfWork.StudentWishlist.Get(x => x.ApplicationUserId == applicationUser && x.SemesterId == semesterId);
            }
            else
            {
                return;
                objStudentWishlist = _unitOfWork.StudentWishlist.Get(x => x.ApplicationUserId == applicationUser);
            }

            if(objStudentWishlist == null) 
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                objStudentWishlist = new StudentWishlist
                {
                    ApplicationUserId = claim.Value,
                    SemesterId  = semesterId??1,
                };
                _unitOfWork.StudentWishlist.Add(objStudentWishlist);
            }

            var studentWishlistDetails = _unitOfWork.StudentWishlistDetails.GetAll(x => x.StudentWishlistId == objStudentWishlist.StudentWishlistId, null, "Course");

            foreach (var details in studentWishlistDetails)
            {
                var objStudentWishlistVM = new StudentWishlistVM
                {
                    objStudentWishlistDetails = details,
                    objStudentWishlistModalities = new List<StudentWishlistModality>(),
                    objStudentTimes = new List<StudentTime>(),
                };

                var studentWishlistModalities = _unitOfWork.StudentWishlistModality.GetAll(x => x.StudentWishListDetailsId == details.StudentWishlistDetailsId, null, "Modality");

                foreach (var modality in studentWishlistModalities)
                {
                    objStudentWishlistVM.objStudentWishlistModalities.Add(modality);

                    var studentTimes = _unitOfWork.StudentTime.GetAll(x => x.StudentWishlistModalityId == modality.StudentWishlistModalityId, null, "TimeBlock,Campus");
                    foreach (var time in studentTimes)
                    {
                        objStudentWishlistVM.objStudentTimes.Add(time);
                        
                    }
                    
                }
                objStudentWishlistVMs.Add(objStudentWishlistVM);
            }
            //TempData["Success"] = "Wishlist Filtered Successfully";
        }
    }
}
