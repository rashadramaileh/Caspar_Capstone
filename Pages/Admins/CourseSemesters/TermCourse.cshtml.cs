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
        public TermCourseModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objSemesterType = new SemesterType();
        }

        public IActionResult OnGet(int? id)
        {
            objSemesterType = _unitOfWork.SemesterType.GetById(id);
            return Page();
        }
    }
}
