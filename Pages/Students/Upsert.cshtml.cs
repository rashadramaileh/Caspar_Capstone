using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Students
{
    public class UpsertModel : PageModel
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public StudentWishlist objStudentWishlist { get; set; }
        [BindProperty]
        public StudentWishlistDetails objStudentWishlistDetails { get; set; }
        [BindProperty]
        public StudentWishlistModality objStudentWishlistModality { get; set; }
        [BindProperty]
        public StudentTime objStudentTime { get; set; }


        public IEnumerable<SelectListItem> StudentList { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }
        public IEnumerable<SelectListItem> FormatList { get; set; }
        public IEnumerable<SelectListItem> TimeList { get; set; }
        public IEnumerable<SelectListItem> SemesterList { get; set; }
        public IEnumerable<SelectListItem> CampusList { get; set; }

        public UpsertModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            objStudentWishlist = new StudentWishlist();
            StudentList = new List<SelectListItem>();
            CourseList = new List<SelectListItem>();
            FormatList = new List<SelectListItem>();
            
            TimeList = new List<SelectListItem>();
            SemesterList = new List<SelectListItem>();
            CampusList = new List<SelectListItem>();
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int? id)
        {
            StudentList = _unitOfWork.Student.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.StudentId.ToString(),
                   Value = x.StudentId.ToString(),
               });
            CourseList = _unitOfWork.Course.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.CourseName,
                    Value = x.CourseId.ToString(),
                });

            FormatList = _unitOfWork.Modality.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.ModalityName,
                   Value = x.ModalityId.ToString(),
               });
           
            TimeList = _unitOfWork.TimeBlock.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.TimeName,
                   Value = x.TimeBlockId.ToString(),
               });
            SemesterList = _unitOfWork.Semester.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.SemesterName,
                   Value = x.SemesterId.ToString(),
               });
            CampusList = _unitOfWork.Campus.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.CampusName,
                   Value = x.CampusId.ToString(),
               });

            // Are we in Create mode?
            if (id == null || id == 0)
            {
                return Page();
            }

            // Edit mode
            if (id != 0)
            {
                objStudentWishlist = _unitOfWork.StudentWishlist.GetById(id);
                objStudentWishlistDetails = _unitOfWork.StudentWishlistDetails.GetById(id);
                objStudentWishlistModality = _unitOfWork.StudentWishlistModality.GetById(id);
                objStudentTime = _unitOfWork.StudentTime.GetById(id);
            }

            //assuming I'm in create mode
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            //Determine Root Path of wwwroot
            string webRootPath = _webHostEnvironment.WebRootPath;
            //Retrieve the files [array]
            var files = HttpContext.Request.Form.Files;

            //if the product is new (create)
            if (objStudentWishlist.StudentWishlistId == 0)
            {
                _unitOfWork.StudentWishlist.Add(objStudentWishlist);

                objStudentWishlistDetails.StudentWishlistId = objStudentWishlist.StudentWishlistId;
                _unitOfWork.StudentWishlistDetails.Add(objStudentWishlistDetails);

                //setting wishlistdetails id from wishlist details to studentwishlistModality
                objStudentWishlistModality.StudentWishListDetailsId = objStudentWishlistDetails.StudentWishlistDetailsId;
                _unitOfWork.StudentWishlistModality.Add(objStudentWishlistModality);

                objStudentTime.StudentWishlistModalityId = (int)objStudentWishlistModality.StudentWishlistModalityId;
                _unitOfWork.StudentTime.Add(objStudentTime);
            }
            //Save changes to Database
            _unitOfWork.Commit();

            //redirect to the products page
            return RedirectToPage("/Students/Index");
        }
    }
}
