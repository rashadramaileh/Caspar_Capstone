using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.InstructorReleaseTimes
{
    public class IRTUpsertModel : PageModel
    {

        private readonly UnitOfWork _unitOfWork;

        [BindProperty]
        public InstructorRelease objinstructorRelease { get; set; }
        [BindProperty]
        public Semester objsemester { get; set; }
        [BindProperty]
        public List<InstructorRelease> objReleaseAmount { get; set; }
        public IEnumerable<SelectListItem> InstructorNameList { get; set; }
        public IEnumerable<InstructorRelease> releaseList { get; set; }
        public int InstructorReleaseId { get; set; }
        public int SemesterId { get; set; } = 1;

        public IRTUpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objinstructorRelease = new InstructorRelease();
            objsemester = new Semester();
            objReleaseAmount = new List<InstructorRelease>();
            InstructorNameList = new List<SelectListItem>();
        }

        public void OnGet()
        {
            /*InstructorNameList = _unitOfWork.InstructorRelease.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.ReleaseTimeName,
                    Value = x.SemesterId.ToString(),
                });

            releaseList = _unitOfWork.InstructorRelease.GetAll();*/
            

        }
    }
}
