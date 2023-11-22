using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Admins.TimeBlocks
{
    public class UpsertModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWork _unitOfWork;
        public List<SelectListItem> isActiveList { get; set; }

        [BindProperty]
        public TimeBlock objTimeBlock { get; set; }
        public UpsertModel(UnitOfWork unit, IWebHostEnvironment env)
        {
            isActiveList = new List<SelectListItem>();

            _webHostEnvironment = env;
            _unitOfWork = unit;
            objTimeBlock = new TimeBlock();

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

            // Are we in Create
            if (id == null || id == 0)
            {
                return Page();
            }

            // edit mode
            if (id != 0)
            {
                objTimeBlock = _unitOfWork.TimeBlock.GetById(id);
                return Page();
            }

            return NotFound();
        }
        public IActionResult OnPost(int? id)
        {
            // if the product is new (create)
            if (objTimeBlock.TimeBlockId == 0)
            {
                // add locally 
                _unitOfWork.TimeBlock.Add(objTimeBlock);
            }
            else //item exists already - EDIT MODE
            {
                //update the existing product. 
                _unitOfWork.TimeBlock.Update(objTimeBlock);

            }
            // save changes to db. 
            _unitOfWork.Commit();

            //redirect to another page. 

            return RedirectToPage("./Index");



        }
    }
}
