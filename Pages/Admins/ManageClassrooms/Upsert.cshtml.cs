using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.ManageClassrooms
{
    public class UpsertModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWork _unitOfWork;

        [BindProperty]
        public Classroom objClassroom { get; set; }
        //public IEnumerable<SelectListItem> RoomConfigList { get; set; }
        public IEnumerable<SelectListItem> BuildingList { get; set; }
        public List<SelectListItem> isActiveList { get; set; }

        public UpsertModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            objClassroom = new Classroom();
            _webHostEnvironment = webHostEnvironment;
            //RoomConfigList = new List<SelectListItem>();
            BuildingList = new List<SelectListItem>();
            isActiveList = new List<SelectListItem>();

        }
        public IActionResult OnGet(int? id)
        {
            BuildingList = _unitOfWork.Building.GetAll().Where(c => c.IsActive == 1)
                .Select(c => new SelectListItem
                {
                    Text = c.BuildingName,
                    Value = c.BuildingId.ToString()
                });

            var active = new SelectListItem
            {
                Text = "Active",
                Value = 1.ToString()
            };
            var inActive = new SelectListItem
            {
                Text = "Inactive",
                Value = 0.ToString()
            };
            isActiveList.Add(inActive);
            isActiveList.Add(active);

            //assuming am i in edit mode:
            if (id != 0)
            {
                objClassroom = _unitOfWork.Classroom.GetById(id);
            }
            if (objClassroom == null) //nothing found in database
            {
                return NotFound();  //built in page.
            }

            //assuming im in create mode:
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Data incomplete.";
                return Page();
            }

            //if this is a new category
            if (objClassroom.ClassroomId == 0)
            {
                _unitOfWork.Classroom.Add(objClassroom);    //not saved to database yet.
                TempData["success"] = "Campus added successfully.";
            }

            //if exists
            else
            {
                _unitOfWork.Classroom.Update(objClassroom);
                TempData["success"] = "Campus updated successfully.";
            }

            _unitOfWork.Commit();  //saves changes to database.
            return RedirectToPage("./Index");
        }
    }
}
