using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.CourseSemesters
{
    public class UpsertModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public CourseSemester objCourseSemester { get; set; }
        public SemesterType objSemesterType { get; set; }
        public IEnumerable<SelectListItem> objCourseList { get; set; }

        public UpsertModel(UnitOfWork unit, IWebHostEnvironment env)
        {
            _webHostEnvironment = env;
            _unitOfWork = unit;
            objSemesterType = new SemesterType();
            objCourseList = new List<SelectListItem>();
            objCourseSemester = new CourseSemester();

        }

        public IActionResult OnGet(int? id, int? sid)
        {
            objCourseList = _unitOfWork.Course.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.CoursePrefix + c.CourseNumber + " " + c.CourseName,
                    Value = c.CourseId.ToString()
                });
            objSemesterType = _unitOfWork.SemesterType.GetById(sid);
            objCourseSemester.SemesterType = objSemesterType;
            objCourseSemester.SemesterTypeId = objSemesterType.SemesterTypeId;

            // Are we in Create
            if (id == null || id == 0)
            {
                return Page();
            }

            // edit mode
            if (id != 0)
            {
                objCourseSemester = _unitOfWork.CourseSemester.GetById(id);
                
                return Page();
            }

            return NotFound();
        }
        public IActionResult OnPost(int? id)
        {
            // if the product is new (create)
            if (objCourseSemester.CourseSemesterId == 0)
            {
                // add locally 
                _unitOfWork.CourseSemester.Add(objCourseSemester);
            }
            else //item exists already - EDIT MODE
            {
                //update the existing product. 
                _unitOfWork.CourseSemester.Update(objCourseSemester);

            }
            // save changes to db. 
            _unitOfWork.Commit();

            //redirect to another page. 

            return Redirect($"./TermCourse?id={objCourseSemester.SemesterTypeId}");

        }
    }
}
