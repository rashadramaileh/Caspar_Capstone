using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CASPAR.Pages.Admins.InstructorReleaseTimes
{
    public class InstructorReleaseTimeModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        public InstructorRelease objReleaseList { get; set; }
        public int InstructorId { get; set; } = 1;

        [BindProperty]
        public int SemesterId { get; set; }
        public IEnumerable<SelectListItem> SemesterList { get; set; }

        public InstructorReleaseTimeModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            SemesterList = new List<SelectListItem>();
            objReleaseList = new InstructorRelease();
        }

        public void OnGet()
        {
            GetReleaseData(InstructorId, null);
        }

        public void OnPost() 
        {
            GetReleaseData(InstructorId, SemesterId);
        }

        private void GetReleaseData(int instructorid, int? semesterId)
        {
            SemesterList = _unitOfWork.Semester.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.SemesterName,
                    Value = x.SemesterId.ToString(),
                });

            if (semesterId != null && semesterId != 0)
            {
                objReleaseList = _unitOfWork.InstructorRelease.Get(x => x.UserId == instructorid && x.SemesterId == semesterId);
            }
            else
            {
                objReleaseList = _unitOfWork.InstructorRelease.Get(x => x.UserId == instructorid);
            }

            if(objReleaseList == null)
            {
                objReleaseList = new InstructorRelease
                {
                    UserId = instructorid,
                    SemesterId = semesterId ?? 1,
                };
                _unitOfWork.InstructorRelease.Add(objReleaseList);
            }

            var instrucorReleaseTimeDetails = _unitOfWork.InstructorRelease.GetAll(x => x.InstructorReleaseId == objReleaseList.InstructorReleaseId, null, "Instructor Name");

            foreach (var item in instrucorReleaseTimeDetails)
            {
                InstructorRelease toAdd = objReleaseList;
                _unitOfWork.InstructorRelease.Add(toAdd);
            }

            TempData["success"] = "Semester Filtered Successfully";
        }
    }
}
