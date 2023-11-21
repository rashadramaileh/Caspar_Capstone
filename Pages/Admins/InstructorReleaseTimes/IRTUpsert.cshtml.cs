using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public IRTUpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objinstructorRelease = new InstructorRelease();
            objsemester = new Semester();
            objReleaseAmount = new List<InstructorRelease>();
        }

        public IActionResult OnGet(int? id)
        {
            


            return Page();
        }
    }
}
