using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Instructors
{
	public class InstructorWishlistVM
	{
		[BindProperty]
		public InstructorWishlistDetails objInstructorWishlistDetails { get; set; }
		public List<InstructorWishlistModality> objInstructorWishlistModalities { get; set; }
		public List<InstructorTime> objInstructorTimes { get; set; }
	}

	public class InstructorWishlistHomeModel : PageModel
	{
		private readonly UnitOfWork _unitOfWork;
		public InstructorWishlist objInstructorWishlist { get; set; }

		public List<InstructorWishlistVM> objInstructorWishlistVMs { get; set; }
		public IEnumerable<SelectListItem> SemesterList { get; set; }
		public IEnumerable<InstructorWishlist> ListInstructorWishlist { get; set; }
		[BindProperty]
		public int InstructorWishlistId { get; set; } = 36;
		public int InstructorId { get; set; } = 1;
		[BindProperty]
		public int SemesterId { get; set; }

		public InstructorWishlistHomeModel(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			objInstructorWishlist = new InstructorWishlist();
			objInstructorWishlistVMs = new List<InstructorWishlistVM>();

			SemesterList = new List<SelectListItem>();
			ListInstructorWishlist = new List<InstructorWishlist>();
		}

		public void OnGet()
		{
			GetInstructorWishlistData(InstructorId, null);
		}

		public void OnPost()
		{
			GetInstructorWishlistData(InstructorId, SemesterId);
		}

		private void GetInstructorWishlistData(int instructorId, int? semesterId)
		{
			SemesterList = _unitOfWork.Semester.GetAll()
			   .Select(x => new SelectListItem
			   {
				   Text = x.SemesterName,
				   Value = x.SemesterId.ToString(),
			   });

			if (semesterId != null && semesterId != 0)
			{
				objInstructorWishlist = _unitOfWork.InstructorWishlist.Get(x => x.InstructorId == instructorId && x.SemesterId == semesterId);
			}
			else
			{
				objInstructorWishlist = _unitOfWork.InstructorWishlist.Get(x => x.InstructorId == instructorId);
			}

			if (objInstructorWishlist == null)
			{
				objInstructorWishlist = new InstructorWishlist
				{
					InstructorId = InstructorId,
					SemesterId = semesterId ?? 1,
				};
				_unitOfWork.InstructorWishlist.Add(objInstructorWishlist);
			}

			var InstructorWishlistDetails = _unitOfWork.InstructorWishlistDetails.GetAll(x => x.InstructorWishlistId == objInstructorWishlist.InstructorWishlistId, null, "Course");

			foreach (var details in InstructorWishlistDetails)
			{
				var objInstructorWishlistVM = new InstructorWishlistVM
				{
					objInstructorWishlistDetails = details,
					objInstructorWishlistModalities = new List<InstructorWishlistModality>(),
					objInstructorTimes = new List<InstructorTime>(),
				};

				var InstructorWishlistModalities = _unitOfWork.InstructorWishlistModality.GetAll(x => x.InstructorWishListDetailsId == details.InstructorWishlistDetailsId, null, "Modality");

				foreach (var modality in InstructorWishlistModalities)
				{
					objInstructorWishlistVM.objInstructorWishlistModalities.Add(modality);

					var InstructorTimes = _unitOfWork.InstructorTime.GetAll(x => x.InstructorWishlistModalityId == modality.InstructorWishlistModalityId, null, "DayBlock,MeetingTime,Campus");
					foreach (var time in InstructorTimes)
					{
						objInstructorWishlistVM.objInstructorTimes.Add(time);

					}

				}
				objInstructorWishlistVMs.Add(objInstructorWishlistVM);
			}
		}
	}
}
