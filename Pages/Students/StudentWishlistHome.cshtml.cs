using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.Linq;

namespace CASPAR.Pages.Students
{
    public class StudentWishlistVM
    {
        [BindProperty]
        public StudentWishlistDetails objStudentWishlistDetails { get; set; } //this is not a list anymore !
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


        public StudentWishlishtHomeModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objStudentWishlist = new StudentWishlist();
            objStudentWishlistVMs = new List<StudentWishlistVM>();

            SemesterList = new List<SelectListItem>();
            ListStudentWishlist = new List<StudentWishlist>();
        }

        public void OnGet()
        {
            SemesterList = _unitOfWork.Semester.GetAll()
              .Select(x => new SelectListItem
              {
                  Text = x.SemesterName,
                  Value = x.SemesterId.ToString(),
              });



            ListStudentWishlist = _unitOfWork.StudentWishlist.GetAll(x => x.StudentId == 2 , null, "Wishlist");// needs to find all wishlists for a given student
            //objStudentWishlist = _unitOfWork.StudentWishlist.Get(x => x.StudentWishlistId == 8); //find an existing student wishlist
            //var studentWishlistDetails = _unitOfWork.StudentWishlistDetails.GetAll(x => x.StudentWishlistId == objStudentWishlist.StudentWishlistId, null, "Course");


            foreach (var objStudentWishlist in ListStudentWishlist)
            {//outer loop
                var studentWishlistDetails = _unitOfWork.StudentWishlistDetails.GetAll(x => x.StudentWishlistId == objStudentWishlist.StudentWishlistId, null, "Course");


                foreach (var details in studentWishlistDetails)
                {
                    var objStudentWishlistVM = new StudentWishlistVM
                    {
                        objStudentWishlistDetails = details,
                        objStudentWishlistModalities = new List<StudentWishlistModality>(),
                        objStudentTimes = new List<StudentTime>(),

                    };

                    var studentSemester = _unitOfWork.StudentWishlist.GetAll(x => x.SemesterId == details.StudentWishlist.SemesterId, null, "Semester");
                    foreach (var semesterName in studentSemester)
                    {
                        
                    }

                    var studentWishlistModalities = _unitOfWork.StudentWishlistModality.GetAll(x => x.StudentWishListDetailsId == details.StudentWishlistDetailsId, null, "Modality");

                    foreach (var modality in studentWishlistModalities)
                    {
                        objStudentWishlistVM.objStudentWishlistModalities.Add(modality);

                        var studentTimes = _unitOfWork.StudentTime.GetAll(x => x.StudentWishlistModalityId == modality.StudentWishlistModalityId, null, "TimeBlock");
                        foreach (var time in studentTimes)
                        {
                            objStudentWishlistVM.objStudentTimes.Add(time);
                        }
                    }
                    objStudentWishlistVMs.Add(objStudentWishlistVM);
                }
            }//end outer loop
        }
    }
}
