using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Students
{
    public class CheckBoxItem
    {
        [BindProperty]
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Value { get; set; }
    }

    public class WishlistVM
    {
        [BindProperty]
        public StudentWishlistDetails objStudentWishlistDetails { get; set; }
        public StudentWishlistModality objStudentWishlistModality { get; set; }
        public List<StudentTime> objStudentTime { get; set; }
        public List<CheckBoxItem> modalityCheck { get; set; }
        
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
        public List<StudentTime> objStudentTime { get; set; }
        //public List<CheckBoxItem> modalityCheck { get; set; } = new List<CheckBoxItem>();


        public IEnumerable<SelectListItem> StudentList { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }
        public IEnumerable<SelectListItem> FormatList { get; set; }
        public IEnumerable<SelectListItem> TimeList { get; set; }
        public IEnumerable<SelectListItem> CampusList { get; set; }
        [BindProperty]
        public List<CheckBoxItem> modalityCheck { get; set; }

        public UpsertModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            objStudentWishlist = new StudentWishlist();
            objStudentWishlistDetails = new StudentWishlistDetails();
			objStudentWishlistModality = new StudentWishlistModality();
            StudentList = new List<SelectListItem>();
            CourseList = new List<SelectListItem>();
            TimeList = new List<SelectListItem>();
            CampusList = new List<SelectListItem>();
            _webHostEnvironment = webHostEnvironment;
            modalityCheck = new List<CheckBoxItem>();
            objStudentTime = new List<StudentTime>();

	    }
        public IActionResult OnGet(int? id, int? wishlist)
        {
            //modalityCheck = (List<CheckBoxItem>)_unitOfWork.Modality.GetAll()
            //    .Select(x => new CheckBoxItem
            //    {
            //       Text = x.ModalityName, 
            //       Value = x.ModalityId,
            //    });

            foreach (var item in _unitOfWork.Modality.GetAll())
            {
                CheckBoxItem toAdd = new CheckBoxItem { Text = item.ModalityName, Value = item.ModalityId };
                modalityCheck.Add(toAdd);
            }

            foreach (var item in _unitOfWork.TimeBlock.GetAll())
            {
                StudentTime toAdd = new StudentTime();
                objStudentTime.Add(toAdd);
            }

            //modalityCheck = 
            //{
            //	new CheckBoxItem { Text = "Face to Face", Value = "FaceToFace" },
            //	new CheckBoxItem { Text = "Online", Value = "Online" },
            //	new CheckBoxItem { Text = "Hybrid", Value = "Hybrid" },
            //	new CheckBoxItem { Text = "Flex", Value = "Flex" },
            //	new CheckBoxItem { Text = "In Person", Value = "InPerson" },
            //};

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

            if(wishlist != null)
            {
				objStudentWishlist = _unitOfWork.StudentWishlist.GetById(wishlist);
			}

            // Are we in Create mode?
            if (id == null || id == 0)
            {
                return Page();
            }

            // Edit mode
            if (id != 0)
            {
                objStudentWishlistDetails = _unitOfWork.StudentWishlistDetails.GetById(id);
                objStudentWishlistModality = _unitOfWork.StudentWishlistModality.GetById(id);
                objStudentTime = (List<StudentTime>)_unitOfWork.StudentTime.GetAll();
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
            if (objStudentWishlistDetails.StudentWishlistDetailsId == 0)
            {
                objStudentWishlistDetails.StudentWishlistId = objStudentWishlist.StudentWishlistId;
                _unitOfWork.StudentWishlistDetails.Add(objStudentWishlistDetails);
				foreach (var item in modalityCheck)
				{
                    objStudentWishlistModality.StudentWishListDetailsId = objStudentWishlistDetails.StudentWishlistDetailsId;
                    objStudentWishlistModality = new StudentWishlistModality { StudentWishlistModalityId = 0, StudentWishListDetailsId = objStudentWishlistModality.StudentWishListDetailsId, ModalityId = objStudentWishlistModality.ModalityId };
                    if (item.Checked == true)
                    {
                        objStudentWishlistModality.ModalityId = item.Value;
                        StudentWishlistModality toAdd = objStudentWishlistModality;
                        _unitOfWork.StudentWishlistModality.Add(toAdd);

                        foreach (var time in objStudentTime)
                        {
                            if (time.StudentWishlistModalityId == item.Value)
                            {
                                time.StudentWishlistModalityId = _unitOfWork.StudentWishlistModality.Get(c => c.StudentWishlistModalityId == objStudentWishlistModality.StudentWishlistModalityId).StudentWishlistModalityId;    //objStudentWishlistModality.StudentWishlistModalityId;
                                _unitOfWork.StudentTime.Add(time);
                            }
                        }
                    }
				}
                
            }
            //Save changes to Database
            _unitOfWork.Commit();

            //redirect to the products page
            return RedirectToPage("/Students/StudentWishlistHome");
        }
    }
}
