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
        public IEnumerable<CourseSemester> objCourseList;
        public TermCourseModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objSemesterType = new SemesterType();
            objCourseList = new List<CourseSemester>();
        }

        public IActionResult OnGet(int? id)
        {
            objSemesterType = _unitOfWork.SemesterType.GetById(id);
            objCourseList = _unitOfWork.CourseSemester.GetAll(null, null, "Course,SemesterType").Where(cs => cs.SemesterTypeId == id);
            return Page();
        }
    }
}
