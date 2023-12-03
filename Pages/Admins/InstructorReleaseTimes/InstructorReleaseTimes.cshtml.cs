using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity; // Add this for UserManager and ApplicationUser
using System.Security.Claims;
using System.Linq;

namespace CASPAR.Pages.Admins.InstructorReleaseTimes
{
    public class InstructorReleaseTimeModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public IEnumerable<Instructor> objInstructorList { get; set; }
        public IEnumerable<InstructorCurrentLoad> objReleaseList { get; set; }
        public int UserId { get; set; } = 1;

        public int SemesterId { get; set; }
        public IEnumerable<SelectListItem> SemesterList { get; set; }
        public Semester objSemester { get; set; }

        public InstructorReleaseTimeModel(UnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            SemesterList = new List<SelectListItem>();
            objSemester = new Semester();
        }

        public void OnGet()
        {
            GetInstructorsAndReleaseData(null);
        }

        public void OnPost()
        {
            GetInstructorsAndReleaseData(SemesterId);
        }

        private void GetInstructorsAndReleaseData(int? semesterId)
        {
            // Get the current user's id
            var currentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Fetch the user's roles
            var userRoles = HttpContext.User.FindAll(ClaimTypes.Role).Select(r => r.Value);

            // Fetch instructors for the current user and role
            objInstructorList = _unitOfWork.Instructor.GetAll(instructor =>
                instructor.Id == currentUserId && userRoles.Contains("YourRole"));

            // Fetch semesters for the dropdown
            SemesterList = _unitOfWork.Semester.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.SemesterName,
                    Value = x.SemesterId.ToString(),
                });

            if (semesterId != null && semesterId != 0)
            {
                //objReleaseList = _unitOfWork.InstructorRelease.GetAll(c => c.SemesterId == semesterId);
            }
            else
            {
                //objReleaseList = _unitOfWork.InstructorRelease.GetAll(c => c.SemesterId == _unitOfWork.Semester.GetById(1).SemesterId);
            }

            TempData["success"] = "Semester Filtered Successfully";
        }
    }
}
