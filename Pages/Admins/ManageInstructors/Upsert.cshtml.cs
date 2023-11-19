using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CASPAR.Pages.Admins.ManageInstructors
{
    public class UpsertModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public Instructor objInstructor { get; set; }
        public UpsertModel(UnitOfWork unit, IWebHostEnvironment env)
        {
            _webHostEnvironment = env;
            _unitOfWork = unit;
            objInstructor = new Instructor();

        }

        public IActionResult OnGet(int? id)
        {
            // Are we in Create
            if (id == null || id == 0)
            {
                return Page();
            }

            // edit mode
            if (id != 0)
            {
                objInstructor = _unitOfWork.Instructor.GetById(id);
                
                return Page();
            }

            return NotFound();
        }
        public IActionResult OnPost(int? id)
        {
            // if the product is new (create)
            if (objInstructor.InstructorId == 0)
            {
                // add locally 
                _unitOfWork.Instructor.Add(objInstructor);
                TempData["success"] = "Instructor Added Successfully";
            }
            else //item exists already - EDIT MODE
            {
                //update the existing product. 
                _unitOfWork.Instructor.Update(objInstructor);
                TempData["success"] = "Instructor Updated Successfully";

            }
            // save changes to db. 
            _unitOfWork.Commit();

            //redirect to another page. 

            return RedirectToPage("./Index");



        }
    }
}
