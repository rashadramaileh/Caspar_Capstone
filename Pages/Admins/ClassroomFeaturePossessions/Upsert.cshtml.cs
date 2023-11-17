using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.ClassroomFeaturePossessions
{
    
    public class UpsertModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWork _unitOfWork;
        public IEnumerable<SelectListItem> ClassroomList { get; set; }
        public IEnumerable<SelectListItem> FeatureList { get; set; }
        [BindProperty]
        public ClassroomFeaturePossession objClassroomFeaturePossession { get; set; }
        public UpsertModel(UnitOfWork unit, IWebHostEnvironment env)
        {
            ClassroomList = new List<SelectListItem>();
            FeatureList = new List<SelectListItem>();
            _webHostEnvironment = env;
            _unitOfWork = unit;
            objClassroomFeaturePossession = new ClassroomFeaturePossession();

        }

        public IActionResult OnGet(int? id)
        {
            ClassroomList = _unitOfWork.Classroom.GetAll()
                .Select(c => new SelectListItem
                {
                    Text =   c.RoomNumber,
                    Value = c.ClassroomId.ToString() 
                });
            FeatureList = _unitOfWork.ClassroomFeature.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.ClassroomFeatureName,
                    Value = c.ClassroomFeatureId.ToString()
                });
            // Are we in Create
            if (id == null || id == 0)
            {
                return Page();
            }

            // edit mode
            if (id != 0)
            {
                objClassroomFeaturePossession = _unitOfWork.ClassroomFeaturePossession.GetById(id);
                return Page();
            }

            return NotFound();
        }
        public IActionResult OnPost(int? id)
        {
            // if the product is new (create)
            if (objClassroomFeaturePossession.FeaturePossessionId == 0)
            {
                // add locally 
                _unitOfWork.ClassroomFeaturePossession.Add(objClassroomFeaturePossession);
            }
            else //item exists already - EDIT MODE
            {
                //update the existing product. 
                _unitOfWork.ClassroomFeaturePossession.Update(objClassroomFeaturePossession);

            }
            // save changes to db. 
            _unitOfWork.Commit();

            //redirect to another page. 

            return RedirectToPage("./Index");



        }
    }
}
