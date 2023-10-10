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

        public IEnumerable<SelectListItem> StudentList { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }
        public IEnumerable<SelectListItem> FormatList { get; set; }
        public IEnumerable<SelectListItem> DayList { get; set; }
        public IEnumerable<SelectListItem> TimeList { get; set; }
        public IEnumerable<SelectListItem> SemesterList { get; set; }

        public UpsertModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            objStudentWishlist = new StudentWishlist();
            StudentList = new List<SelectListItem>();
            CourseList = new List<SelectListItem>();
            FormatList = new List<SelectListItem>();
            DayList = new List<SelectListItem>();
            TimeList = new List<SelectListItem>();
            SemesterList = new List<SelectListItem>();
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

            FormatList = _unitOfWork.CourseType.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.CourseTypeName,
                   Value = x.CourseTypeId.ToString(),
               });
            DayList = _unitOfWork.DayBlock.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.DayName,
                   Value = x.DaysBlockId.ToString(),
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

            // Are we in Create mode?
            if (id == null || id == 0)
            {
                return Page();
            }

            // Edit mode
            if (id != 0)
            {
                objStudentWishlist = _unitOfWork.StudentWishlist.GetById(id);
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
            if (objStudentWishlist.StudentWishListId == 0)
            {
                _unitOfWork.StudentWishlist.Add(objStudentWishlist);
            }
            //Save changes to Database
            _unitOfWork.Commit();

            //redirect to the products page
            return RedirectToPage("./Index");
        }
    }
}
