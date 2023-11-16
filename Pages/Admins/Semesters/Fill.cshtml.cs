using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.Semesters
{
    public class FillModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        public Semester semester { get; set; }
        public CourseSemester courseSemester { get; set; }
        public IEnumerable<CourseSemester> objCourseList;
        public Section section;

        public FillModel(UnitOfWork unit)
        {
            _unitOfWork = unit;
            semester = new Semester();
            courseSemester = new CourseSemester();
            objCourseList = new List<CourseSemester>();
            section = new Section();
        }
        public IActionResult OnGet(int? id)
        {
            semester = _unitOfWork.Semester.Get(x => x.SemesterId == id);
            semester.SemesterType = _unitOfWork.SemesterType.Get(s => s.SemesterTypeId == semester.SemesterTypeId);
            
            //Test for courses already loaded
            section = _unitOfWork.Section.Get(x => x.SemesterId == id);

            if (section != null)
            {TempData["warning"] = "Semester already has sections assigned";}
            
            return Page();

        }
        public IActionResult OnPost(int id)
        {
            //loop through the courses in the CourseSemester

            //get the semester
            semester = _unitOfWork.Semester.Get(x => x.SemesterId == id);
            //get the template courses
            objCourseList = _unitOfWork.CourseSemester.GetAll(null, null, "Course,SemesterType").Where(cs => cs.SemesterTypeId == semester.SemesterTypeId);

            //loop through each courseSemester object
            foreach (var course in objCourseList)
            {
                //loop through the quantity taught add each section
                for (int i = 0; i < course.QuantityTaught; i++)
                {
                    Section s = new Section();
                    s.SemesterId = id;
                    s.CourseId = course.CourseId;
                    _unitOfWork.Section.Add(s);
                }     
                _unitOfWork.Commit();
            }
       

            //TempData alert success
            TempData["success"] = "Semester Populated Successfully";

            return RedirectToPage("./Index");

        }
    }
}
