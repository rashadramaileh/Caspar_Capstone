using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.CourseSemesters
{
    public class IndexModel : PageModel
    {
        /*
        private readonly UnitOfWork _unitOfWork;

        public IEnumerable<Infrastructure.Models.CourseSemester> objCourseSemesterList;
        public IEnumerable<Course> objCourseList;
        public IEnumerable<SemesterType> objSemesterTypeList;
        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objCourseList = new List<Course>();
            objSemesterTypeList = new List<SemesterType>();
            objCourseSemesterList = new List<Infrastructure.Models.CourseSemester>();
        }

        public IActionResult OnGet(int? id)
        {
            objCourseList = _unitOfWork.Course.GetAll();
            objSemesterTypeList = _unitOfWork.SemesterType.GetAll();
            objCourseSemesterList = _unitOfWork.CourseSemester.GetAll();
            /*
            foreach (StudentWishlistModality obj in objModalityList)
            {
                obj.Modality = _unitOfWork.Modality.GetById(obj.ModalityId);
            }
            
            return Page();
        }*/
    }
 }
