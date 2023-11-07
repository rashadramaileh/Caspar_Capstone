using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Students
{
    public class CheckBoxItem
    {
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class WishlistVM
    {
        [BindProperty]
        public StudentWishlist objStudentWishlist { get; set; }
        public StudentWishlistDetails objStudentWishlistDetails { get; set; }
        public StudentWishlistModality objStudentWishlistModality { get; set; }
        public StudentTime objStudentTime { get; set; }
        
    }

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
        public List<CheckBoxItem> modalityCheck { get; set; } = new List<CheckBoxItem>();


        public IEnumerable<SelectListItem> StudentList { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }
        public IEnumerable<SelectListItem> FormatList { get; set; }
        public IEnumerable<SelectListItem> TimeList { get; set; }
        public IEnumerable<SelectListItem> CampusList { get; set; }

        public UpsertModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {

           modalityCheck = new List<CheckBoxItem>
            {
                new CheckBoxItem {Text = "Face to Face", Value = "FaceToFace"},
                new CheckBoxItem {Text = "Online", Value = "Online"},
                new CheckBoxItem {Text = "Hybrid", Value = "Hybrid"},
                new CheckBoxItem {Text = "Flex", Value = "Flex"},
                new CheckBoxItem {Text = "In Person", Value = "InPerson"},
            };

            _unitOfWork = unitOfWork;
            
            objStudentWishlist = new StudentWishlist();
            StudentList = new List<SelectListItem>();
            CourseList = new List<SelectListItem>();
            
            TimeList = new List<SelectListItem>();
            CampusList = new List<SelectListItem>();
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int? id)
        {
            StudentList = _unitOfWork.Student.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.User.ToString(),
                    Value = x.StudentId.ToString(),
                });
            CourseList = _unitOfWork.Course.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.CourseName,
                    Value = x.CourseId.ToString(),
                });
           
            TimeList = _unitOfWork.TimeBlock.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.TimeName,
                   Value = x.TimeBlockId.ToString(),
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
                _unitOfWork.StudentWishlistDetails.Add(objStudentWishlistDetails);
                _unitOfWork.StudentWishlistModality.Add(objStudentWishlistModality);
                _unitOfWork.StudentTime.Add(objStudentTime);
            }
            //Save changes to Database
            _unitOfWork.Commit();

            //redirect to the products page
            return RedirectToPage("/Students/StudentWishlistHome");
        }
    }
}
