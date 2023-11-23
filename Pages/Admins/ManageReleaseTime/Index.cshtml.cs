using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Utility;
using System.ComponentModel;
using CASPAR.Pages.Admins.InstructorReleaseTimes;

namespace CASPAR.Pages.Admins.ManageReleaseTime
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public List<ApplicationUser> objInstructorList { get; set; }
        public List<InstructorRelease> objInstructorRelease { get; set; }
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
                    if(_unitOfWork.InstructorRelease.Get(c => (c.ApplicationUserId == instructor.Id && c.SemesterTypeId == semesterType.SemesterTypeId)) == null)
                    {
                        InstructorRelease toAdd = new InstructorRelease() { ApplicationUserId = instructor.Id, SemesterTypeId = semesterType.SemesterTypeId};
                        _unitOfWork.InstructorRelease.Add(toAdd);
                    }
                }
            }

            objInstructorRelease = _unitOfWork.InstructorRelease.GetAll().ToList();
            objSemesterType = _unitOfWork.SemesterType.GetAll().ToList();
        }

    }
}
