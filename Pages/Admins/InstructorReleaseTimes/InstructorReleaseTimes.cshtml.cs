using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.InstructorReleaseTimes
{
    public class InstructorReleaseTimeModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        public InstructorRelease objRelease { get; set; }
        public IEnumerable<InstructorRelease> objReleaseList { get; set; }
        public int UserId { get; set; } = 1;

        public int SemesterId { get; set; }
        public IEnumerable<SelectListItem> SemesterList { get; set; }
        public Semester objSemester { get; set; }

        public InstructorReleaseTimeModel(UnitOfWork unitOfWork)
        {
            objRelease = new InstructorRelease();
            _unitOfWork = unitOfWork;
            SemesterList = new List<SelectListItem>();
            objReleaseList = new List<InstructorRelease>();
            objSemester = new Semester();

        }

        public void OnGet()
        {
            GetReleaseData(null);
            //SemesterList = _unitOfWork.Semester.GetAll()
            //    .Select(x => new SelectListItem
            //    {
            //        Text = x.SemesterName,
            //        Value = x.SemesterId.ToString(),
            //    });
            //objReleaseList = _unitOfWork.InstructorRelease.GetAll();

        }

        public void OnPost()
        {
            GetReleaseData(SemesterId);
        }

        private void GetReleaseData(int? semesterId)
        {
            SemesterList = _unitOfWork.Semester.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.SemesterName,
                    Value = x.SemesterId.ToString(),
                });     

            if (semesterId != null && semesterId != 0)
            {
                objReleaseList = _unitOfWork.InstructorRelease.GetAll(c => c.SemesterId == semesterId);
            }
            else
            {
                objReleaseList = _unitOfWork.InstructorRelease.GetAll(c => c.SemesterId == _unitOfWork.Semester.GetById(1).SemesterId);

            }

            //if (objRelease == null)
            //{
            //    objRelease = new InstructorRelease
            //    {
            //        UserId = instructorId,
            //        SemesterId = semesterId ?? 1,
            //    };
            //    _unitOfWork.InstructorRelease.Add(objRelease);
            //}

            //var instrucorReleaseTimeDetails = _unitOfWork.InstructorRelease.GetAll(x => x.InstructorReleaseId == objRelease.InstructorReleaseId, null, null);

            //foreach (var item in instrucorReleaseTimeDetails)
            //{
            //    InstructorRelease toAdd = objRelease;
            //    _unitOfWork.InstructorRelease.Add(toAdd);
            //}

            TempData["success"] = "Semester Filtered Successfully";
        }
    }
}