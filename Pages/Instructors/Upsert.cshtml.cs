using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Instructors
{
    public class UpsertModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public InstructorWishlist objInstructorWishlist { get; set; }
        [BindProperty]
        public InstructorWishlistDetails objInstructorWishlistDetails { get; set; }
        [BindProperty]
        public InstructorWishlistModality objInstructorWishlistModality { get; set; }
        [BindProperty]
        public InstructorTime objInstructorTime { get; set; }
        [BindProperty]
        public Instructor objInstructor { get; set; }


        public IEnumerable<SelectListItem> InstructorList { get; set; }
        public IEnumerable<SelectListItem> RankingList { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }
        public IEnumerable<SelectListItem> FormatList { get; set; }
        public IEnumerable<SelectListItem> DayList { get; set; }
        public IEnumerable<SelectListItem> TimeList { get; set; }
        public IEnumerable<SelectListItem> SemesterList { get; set; }
        public IEnumerable<SelectListItem> CampusList { get; set; }
        

        public UpsertModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            objInstructorWishlist = new InstructorWishlist();
            InstructorList = new List<SelectListItem>();
            RankingList = new List<SelectListItem>();
            CourseList = new List<SelectListItem>();
            FormatList = new List<SelectListItem>();
            DayList = new List<SelectListItem>();
            TimeList = new List<SelectListItem>();
            SemesterList = new List<SelectListItem>();
            CampusList = new List<SelectListItem>();
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int? id)
        {
            InstructorList = _unitOfWork.Instructor.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.User.ToString(),
                    Value = x.InstructorId.ToString(),
                });
            RankingList = _unitOfWork.Ranking.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.Rank.ToString(),
                    Value = x.RankingId.ToString(),
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
                   Value = x.ModalityName.ToString(),
               });
            DayList = _unitOfWork.DayBlock.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.DayName,
                   Value = x.DaysBlockId.ToString(),
               });
            TimeList = _unitOfWork.MeetingTime.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.meetingTimeName,
                   Value = x.meetingTimeId.ToString(),
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
            InstructorList = _unitOfWork.Instructor.GetAll()
              .Select(x => new SelectListItem
              {
                  Text = x.InstructorId.ToString(),
                  Value = x.InstructorId.ToString(),
              });
            // Are we in Create mode?
            if (id == null || id == 0)
            {
                return Page();
            }

            // Edit mode
            if (id != 0)
            {
                objInstructorWishlist = _unitOfWork.InstructorWishlist.GetById(id);
                objInstructorWishlistDetails = _unitOfWork.InstructorWishlistDetails.GetById(id);
                objInstructorWishlistModality = _unitOfWork.InstructorWishlistModality.GetById(id);
                objInstructorTime = _unitOfWork.InstructorTime.GetById(id);
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
            if (objInstructorWishlist.InstructorWishlistId == 0)
            {
                _unitOfWork.InstructorWishlist.Add(objInstructorWishlist);
                _unitOfWork.InstructorWishlistDetails.Add(objInstructorWishlistDetails);
                _unitOfWork.InstructorWishlistModality.Add(objInstructorWishlistModality);
                _unitOfWork.InstructorTime.Add(objInstructorTime);
            }
            //Save changes to Database
            _unitOfWork.Commit();

            //redirect to the products page
            return RedirectToPage("/Instructors/Index");
        }
    }
}
