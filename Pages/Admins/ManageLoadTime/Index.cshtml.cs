using CASPAR.Infrastructure.Models;
using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManageLoadTime
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public List<ApplicationUser> objInstructorList { get; set; }
        public List<InstructorLoad> objInstructorLoad { get; set; }
        public List<SemesterType> objSemesterType { get; set; }

        public IndexModel(UnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            objInstructorList = new List<ApplicationUser>();
        }

        public async void OnGet()
        {
            var instructors = _userManager.GetUsersInRoleAsync("Instructor").Result;
            foreach (var instructor in instructors)
            {
                objInstructorList.Add(instructor);
            }

            objInstructorList = objInstructorList.OrderBy(x => x.FirstName).ToList();

            foreach (var semesterType in _unitOfWork.SemesterType.GetAll())
            {
                foreach (var instructor in objInstructorList)
                {
                    if (_unitOfWork.InstructorLoad.Get(c => (c.ApplicationUserId == instructor.Id && c.SemesterTypeId == semesterType.SemesterTypeId)) == null)
                    {
                        InstructorLoad toAdd = new InstructorLoad() { ApplicationUserId = instructor.Id, SemesterTypeId = semesterType.SemesterTypeId };
                        _unitOfWork.InstructorLoad.Add(toAdd);
                    }
                }
            }

            objInstructorLoad = _unitOfWork.InstructorLoad.GetAll().ToList();
            objSemesterType = _unitOfWork.SemesterType.GetAll().ToList();
        }
    }
}
