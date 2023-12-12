using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.ProgramCoordinator
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
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
        public IEnumerable<Section> listSectionCourses { get; set; }

        public UpsertModel(UnitOfWork unit, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _unitOfWork = unit;
            objSection = new Section();
            listSectionCourses = new List<Section>();
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
            objSection.Course = _unitOfWork.Course.GetById(objSection.CourseId);
            
            //populate dropdown lists.
            var instructorList = new List<ApplicationUser>();
            var instructors = _userManager.GetUsersInRoleAsync("Instructor").Result;
            foreach (var instructor in instructors)
            {
                instructorList.Add(instructor);
            }

            instructorList = instructorList.OrderBy(x => x.FullName).ToList();
            
            //TODO map each of the courses that are assigned to an instructor. 
            var dictInstructor = new Dictionary<string, string>();
            listSectionCourses = _unitOfWork.Section.GetAll(x => x.SemesterId == id, null, "Course");
            foreach (var instructor in instructorList)
            {
                dictInstructor.Add(instructor.Id, instructor.FullName);
            }

            foreach (var section in listSectionCourses)
            {
                if (dictInstructor.ContainsKey(section.ApplicationUserId))
                {
                    dictInstructor[section.ApplicationUserId] = (dictInstructor[section.ApplicationUserId] + ", " + section.Course.CoursePrefix + section.Course.CourseNumber);
                }
                
            }

            //TODO populate the list with instructor and the 
            listUsers = instructorList
                .Select(c => new SelectListItem
                {
                    Text = dictInstructor[c.Id],
                    Value = c.Id
                });
            
            listClassrooms = _unitOfWork.Classroom.GetAll(null, null, "Building")
                .Select(c => new SelectListItem
                {
                    Text = c.RoomNumber + " " + c.Building.BuildingName,
                    Value = c.ClassroomId.ToString()
                });
            listCourses = _unitOfWork.Course.GetAll(c => c.CourseId == objSection.CourseId)
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
