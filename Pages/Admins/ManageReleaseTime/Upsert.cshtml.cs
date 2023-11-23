using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.ManageReleaseTime
{

	public class UpsertModel : PageModel
	{
        public ApplicationUser objInstructor { get; set; }
        [BindProperty]
        public List<InstructorRelease> objRelease { get; set; }
        public List<SemesterType> objsemesterTypes { get; set; }
        private readonly UnitOfWork _unitOfWork;
		public UpsertModel(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			objInstructor = new ApplicationUser();
			objsemesterTypes = new List<SemesterType>();
			objRelease = new List<InstructorRelease>();
		}

		public IActionResult OnGet(string id)
		{
			objInstructor = _unitOfWork.ApplicationUser.Get(c => c.Id == id);
			objsemesterTypes = _unitOfWork.SemesterType.GetAll().ToList();
			foreach (var semesterType in objsemesterTypes) 
			{
				objRelease.Add(_unitOfWork.InstructorRelease.Get(c => (c.ApplicationUserId == id && c.SemesterTypeId == semesterType.SemesterTypeId)));
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

            foreach (var release in objRelease)
			{
				_unitOfWork.InstructorRelease.Update(release);
			}

            TempData["success"] = "Instructor Release Updated Successfully";

			_unitOfWork.Commit();
			return RedirectToPage("./Index");
		}
	}
}
