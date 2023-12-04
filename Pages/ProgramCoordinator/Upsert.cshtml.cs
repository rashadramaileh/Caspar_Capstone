using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.ProgramCoordinator
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public Section objSection { get; set; }
        public IEnumerable<SelectListItem> listUsers { get; set; }
        public IEnumerable<SelectListItem> listClassrooms { get; set; }
        public IEnumerable<SelectListItem> listCourses { get; set; }
        public IEnumerable<SelectListItem> listSectionStatuses { get; set; }
        public IEnumerable<SelectListItem> listWhoPayss { get; set; }
        public IEnumerable<SelectListItem> listPayModels { get; set; }
        public IEnumerable<SelectListItem> listPartOfTerms { get; set; }
        public IEnumerable<SelectListItem> listModalities { get; set; }
        public IEnumerable<SelectListItem> listMeetingTimes { get; set; }
        public IEnumerable<SelectListItem> listDayBlocks { get; set; }
        public IEnumerable<SelectListItem> listCampuss { get; set; }

        public UpsertModel(UnitOfWork unit)
        {
            _unitOfWork = unit;
            objSection = new Section();
            listUsers = new List<SelectListItem>();
            listClassrooms = new List<SelectListItem>();
            listCourses = new List<SelectListItem>();
            listSectionStatuses = new List<SelectListItem>();
            listWhoPayss = new List<SelectListItem>();
            listPayModels = new List<SelectListItem>();
            listPartOfTerms = new List<SelectListItem>();
            listModalities = new List<SelectListItem>();
            listDayBlocks = new List<SelectListItem>();
            listMeetingTimes = new List<SelectListItem>();
            listCampuss = new List<SelectListItem>();

        }
        public IActionResult OnPost(int? id)
        {
            // if the product is new (create)
            if (objSection.SectionId == 0)
            {
                // add locally 
                _unitOfWork.Section.Add(objSection);
            }
            else //item exists already - EDIT MODE
            {
                //update the existing product. 
                _unitOfWork.Section.Update(objSection);

            }
            // save changes to db. 
            _unitOfWork.Commit();

            //redirect to another page. 

            return Redirect($"./Index?id={objSection.SemesterId}");



        }

        /// <summary>
        /// Create a new section for the semster with SemesterId == id
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(int id)
        {
            objSection = _unitOfWork.Section.GetById(id);
            //populate dropdown lists. 
            listUsers = _unitOfWork.ApplicationUser.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.FullName,
                    Value = c.Id
                }); //TODO filter by role
            listClassrooms = _unitOfWork.Classroom.GetAll(null, null, "Building")
                .Select(c => new SelectListItem
                {
                    Text = c.RoomNumber + " " + c.Building.BuildingName,
                    Value = c.ClassroomId.ToString()
                });
            listCourses = _unitOfWork.Course.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.CourseName,
                    Value = c.CourseId.ToString()
                });
            listSectionStatuses = _unitOfWork.SectionStatus.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.StatusName,
                    Value = c.SectionStatusId.ToString()
                });
            listWhoPayss = _unitOfWork.WhoPays.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.WhoPaysName,
                    Value = c.WhoPaysId.ToString()
                });
            listPayModels = _unitOfWork.PayModel.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.PayType,
                    Value = c.PayModelId.ToString()
                });
            listPartOfTerms = _unitOfWork.PartOfTerm.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.PartOfTermName,
                    Value = c.PartOfTermID.ToString()
                });
            listModalities = _unitOfWork.Modality.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.ModalityName,
                    Value = c.ModalityId.ToString()
                });
            listMeetingTimes = _unitOfWork.MeetingTime.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.meetingTimeName,
                    Value = c.meetingTimeId.ToString()
                });
            listDayBlocks = _unitOfWork.DayBlock.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.DayName,
                    Value = c.DaysBlockId.ToString()
                });
            listCampuss = _unitOfWork.Campus.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.CampusName,
                    Value = c.CampusId.ToString()
                });
        }

    }
}