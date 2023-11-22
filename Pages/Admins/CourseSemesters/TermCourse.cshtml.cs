using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.CourseSemesters
{
    public class TermCourseModel : PageModel
    {

        private readonly UnitOfWork _unitOfWork;

        public SemesterType objSemesterType;
        public IEnumerable<SemesterType> objAllSemesterTypes;
        public IEnumerable<CourseSemester> objCourseList;
        public IEnumerable<Course> objAllCourses;
        public int? savedId;

        public TermCourseModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objSemesterType = new SemesterType();
            objCourseList = new List<CourseSemester>();
            objAllSemesterTypes = new List<SemesterType>();
            objAllCourses = new List<Course>();
        }

        public IActionResult OnGet(int? id)
        {
            savedId = id;
            objSemesterType = _unitOfWork.SemesterType.GetById(id);
            objCourseList = _unitOfWork.CourseSemester.GetAll(null, null, "Course,SemesterType").Where(cs => cs.SemesterTypeId == id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            savedId = id;
            objAllCourses = _unitOfWork.Course.GetAll().Where(x => x.IsActive == 1).ToList();
            //objAllSemesterTypes = _unitOfWork.SemesterType.GetAll().Where(x => x.IsActive == 1).ToList();
            objSemesterType = _unitOfWork.SemesterType.GetById(id);
            objCourseList = _unitOfWork.CourseSemester.GetAll(null, null, "Course,SemesterType").Where(cs => cs.SemesterTypeId == id);

            Populate();
            TempData["success"] = "Successfully populated the template";
            
            return RedirectToPage(new {id = savedId.ToString() });
        }

        private void Populate()
        {

            foreach (var course in objAllCourses)
            {
                _unitOfWork.CourseSemester.Add(new CourseSemester()
                {
                    CourseId = course.CourseId,
                    SemesterTypeId = objSemesterType.SemesterTypeId,
                    QuantityTaught = 0
                });
            }
            _unitOfWork.Commit();


        }
    }
}
