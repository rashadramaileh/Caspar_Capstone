using CASPAR.Infrastructure.Models;
using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManageLoadTime
{
    public class UpsertModel : PageModel
    {
        public ApplicationUser objInstructor { get; set; }
        [BindProperty]
        public List<InstructorLoad> objLoad { get; set; }
        public List<SemesterType> objsemesterTypes { get; set; }
        private readonly UnitOfWork _unitOfWork;
        public UpsertModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            objInstructor = new ApplicationUser();
            objsemesterTypes = new List<SemesterType>();
            objLoad = new List<InstructorLoad>();
        }

        public IActionResult OnGet(string id)
        {
            objInstructor = _unitOfWork.ApplicationUser.Get(c => c.Id == id);
            objsemesterTypes = _unitOfWork.SemesterType.GetAll().ToList();
            foreach (var semesterType in objsemesterTypes)
            {
                objLoad.Add(_unitOfWork.InstructorLoad.Get(c => (c.ApplicationUserId == id && c.SemesterTypeId == semesterType.SemesterTypeId)));
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {

            if (!ModelState.IsValid)
            {
                TempData["error"] = "Data Incomplete";
                return Page();
            }

            foreach (var Load in objLoad)
            {
                _unitOfWork.InstructorLoad.Update(Load);
            }

            TempData["success"] = "Instructor Load Updated Successfully";

            _unitOfWork.Commit();
            return RedirectToPage("./Index");
        }
    }
}
