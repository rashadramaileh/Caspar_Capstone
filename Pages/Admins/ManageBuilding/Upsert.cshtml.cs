using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.ManageBuilding
{
    public class UpsertModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWork _unitOfWork;
        public List<SelectListItem> isActiveList { get; set; }

        [BindProperty]
        public Building objBuilding { get; set; }

        public IEnumerable <SelectListItem> CampusList { get; set; }
        public UpsertModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            objBuilding = new Building();
            _webHostEnvironment = webHostEnvironment;
            CampusList = new List<SelectListItem>();
            isActiveList = new List<SelectListItem>();

        }
        public IActionResult OnGet(int? id)
        {
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

            CampusList = _unitOfWork.Campus.GetAll().Where(c => c.IsActive == 1)
                .Select(c => new SelectListItem
                {
                    Text = c.CampusName,
                    Value = c.CampusId.ToString()
                });
            //assuming am i in edit mode:
            if (id != 0)
            {
                objBuilding = _unitOfWork.Building.GetById(id);
            }
            if (objBuilding == null) //nothing found in database
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
            if (objBuilding.BuildingId == 0)
            {
                _unitOfWork.Building.Add(objBuilding);    //not saved to database yet.
                TempData["success"] = "Building added successfully.";
            }

            //if exists
            else
            {
                _unitOfWork.Building.Update(objBuilding);
                TempData["success"] = "Building updated successfully.";
            }

            _unitOfWork.Commit();  //saves changes to database.
            return RedirectToPage("./Index");
        }
    }
}
