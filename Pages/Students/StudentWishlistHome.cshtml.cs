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
        public int StudentWishlistId { get; set; } = 8;
        public int StudentId { get; set; } = 2;
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

        public void OnGet()
        {
            GetStudentWishlistData(StudentId, null);
        }

        public void OnPost()
        {
            GetStudentWishlistData(StudentId, SemesterId);
        }

        private void GetStudentWishlistData(int studentId, int? semesterId)
        {
            SemesterList = _unitOfWork.Semester.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.SemesterName,
                    Value = x.SemesterId.ToString(),
                });

            if (semesterId != null && semesterId !=0)
            {
                objStudentWishlist = _unitOfWork.StudentWishlist.Get(x => x.StudentId == studentId && x.SemesterId == semesterId);
            }
            else
            {
                objStudentWishlist = _unitOfWork.StudentWishlist.Get(x => x.StudentId == studentId);
            }

            if(objStudentWishlist == null) 
            {
                objStudentWishlist = new StudentWishlist
                {
                    StudentId = studentId,
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

                    var studentTimes = _unitOfWork.StudentTime.GetAll(x => x.StudentWishlistModalityId == modality.StudentWishlistModalityId, null, "TimeBlock");
                    foreach (var time in studentTimes)
                    {
                        objStudentWishlistVM.objStudentTimes.Add(time);
                    }
                }
                objStudentWishlistVMs.Add(objStudentWishlistVM);
            }
        }
    }
}
