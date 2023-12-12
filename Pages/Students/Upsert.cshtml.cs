using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Students
{
    public class CheckBoxItem
    {
        [BindProperty]
        public bool Checked { get; set; }
        public bool Disabled { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Value { get; set; }
        public bool AdditionalInfo { get; set; }
    }

    public class WishlistVM
    {
        [BindProperty]
        public StudentWishlistDetails objStudentWishlistDetails { get; set; }
        public StudentWishlistModality objStudentWishlistModality { get; set; }
        public List<StudentTime> objStudentTime { get; set; }
        public List<CheckBoxItem> modalityCheck { get; set; }
        
    }

        public class UpsertModel : PageModel
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public StudentWishlist objStudentWishlist { get; set; }
        [BindProperty]
        public StudentWishlistDetails objStudentWishlistDetails { get; set; }
        [BindProperty]
        public StudentWishlistModality objStudentWishlistModality { get; set; }
        [BindProperty]
        public List<StudentTime> objStudentTime { get; set; }
        //public List<CheckBoxItem> modalityCheck { get; set; } = new List<CheckBoxItem>();


        public IEnumerable<SelectListItem> StudentList { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }
        public IEnumerable<SelectListItem> FormatList { get; set; }
        public IEnumerable<SelectListItem> TimeList { get; set; }
        public IEnumerable<SelectListItem> CampusList { get; set; }
        [BindProperty]
        public List<CheckBoxItem> modalityCheck { get; set; }

        public UpsertModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            objStudentWishlist = new StudentWishlist();
            objStudentWishlistDetails = new StudentWishlistDetails();
			objStudentWishlistModality = new StudentWishlistModality();
            StudentList = new List<SelectListItem>();
            CourseList = new List<SelectListItem>();
            TimeList = new List<SelectListItem>();
            CampusList = new List<SelectListItem>();
            _webHostEnvironment = webHostEnvironment;
            modalityCheck = new List<CheckBoxItem>();
            objStudentTime = new List<StudentTime>();

	    }
        public IActionResult OnGet(int? id, int? wishlist)
        {
            //modalityCheck = (List<CheckBoxItem>)_unitOfWork.Modality.GetAll()
            //    .Select(x => new CheckBoxItem
            //    {
            //       Text = x.ModalityName, 
            //       Value = x.ModalityId,
            //    });

            foreach (var item in _unitOfWork.Modality.GetAll())
            {
                CheckBoxItem toAdd = new CheckBoxItem { Text = item.ModalityName, Value = item.ModalityId, AdditionalInfo = item.AdditionalWishlistInfo };
                modalityCheck.Add(toAdd);

                if(item.AdditionalWishlistInfo == true)
                {
                    StudentTime toAddTime = new StudentTime();
                    objStudentTime.Add(toAddTime);
                }
            }

            CourseList = _unitOfWork.Course.GetAll().Where(x => x.IsActive == 1).OrderBy(x => x.CoursePrefix).ThenBy(x => x.CourseNumber).ThenBy(x => x.CourseName)
                .Select(x => new SelectListItem
                {
                    Text = x.CoursePrefix + x.CourseNumber + " " + x.CourseName,
                    Value = x.CourseId.ToString(),
                });

           
            TimeList = _unitOfWork.TimeBlock.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.TimeName,
                   Value = x.TimeBlockId.ToString(),
               });

            CampusList = _unitOfWork.Campus.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.CampusName,
                   Value = x.CampusId.ToString(),
               });

            if(wishlist != null)
            {
				objStudentWishlist = _unitOfWork.StudentWishlist.GetById(wishlist);
			}

            // Are we in Create mode?
            if (id == null || id == 0)
            {
                return Page();
            }

            // Edit mode
            if (id != 0)
            {
                int count = 0;
                int previouscount = 0;
                List<int> modalityIds = new List<int>();
                objStudentWishlistDetails = _unitOfWork.StudentWishlistDetails.GetById(id);
                foreach (var item in modalityCheck)
                {
                    foreach (var modality in _unitOfWork.StudentWishlistModality.GetAll(c => c.StudentWishListDetailsId == id))
                    {
                        if (item.Value == modality.ModalityId)
                        {
                            modalityIds.Add(modality.StudentWishlistModalityId);
                            item.Checked = true;

                            if (_unitOfWork.StudentTime.GetAll(c => c.StudentWishlistModalityId == modality.StudentWishlistModalityId).FirstOrDefault() != null)
                            {
                                objStudentTime[count] = _unitOfWork.StudentTime.GetAll(c => c.StudentWishlistModalityId == modality.StudentWishlistModalityId).FirstOrDefault();
                                objStudentTime[count].StudentWishlistModalityId = (int)modality.ModalityId;
                                count++;
                            }
                        }
                    }
                    if (item.AdditionalInfo == true)
                    {
                        if (count == previouscount)
                        {
                            count++;
                        }
                    }
                    previouscount = count;
                }

                foreach (var item in modalityIds)
                {
                    if(_unitOfWork.StudentTime.GetAll(c => c.StudentWishlistModalityId == item).Skip(1) != null)
                    {
                        foreach (var time in _unitOfWork.StudentTime.GetAll(c => c.StudentWishlistModalityId == item).Skip(1))
                        {
                            time.StudentWishlistModalityId = (int)_unitOfWork.StudentWishlistModality.GetById(item).ModalityId;
                            objStudentTime.Add(time);
                            count++;
                        }
                    }
                }
                
            }

            //assuming I'm in create mode
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            //Determine Root Path of wwwroot
            string webRootPath = _webHostEnvironment.WebRootPath;
            //Retrieve the files [array]
            var files = HttpContext.Request.Form.Files;

            //if the product is new (create)
            if (objStudentWishlistDetails.StudentWishlistDetailsId == 0)
            {
                foreach (var item in objStudentTime)
                {
                    if (item.StudentWishlistModalityId == -1)
                    {
                        item.StudentWishlistModalityId = 0;
                        item.StudentTimeId = -1;
                    }
                }

                objStudentWishlistDetails.StudentWishlistId = objStudentWishlist.StudentWishlistId;
                _unitOfWork.StudentWishlistDetails.Add(objStudentWishlistDetails);
				foreach (var item in modalityCheck)
				{
                    objStudentWishlistModality.StudentWishListDetailsId = objStudentWishlistDetails.StudentWishlistDetailsId;
                    objStudentWishlistModality = new StudentWishlistModality { StudentWishlistModalityId = 0, StudentWishListDetailsId = objStudentWishlistModality.StudentWishListDetailsId, ModalityId = objStudentWishlistModality.ModalityId };
                    if (item.Checked == true)
                    {
                        objStudentWishlistModality.ModalityId = item.Value;
                        StudentWishlistModality toAdd = objStudentWishlistModality;
                        _unitOfWork.StudentWishlistModality.Add(toAdd);

                        foreach (var time in objStudentTime)
                        {
                            if (time.StudentWishlistModalityId == item.Value && time.StudentTimeId != -1)
                            {
                                time.StudentWishlistModalityId = _unitOfWork.StudentWishlistModality.Get(c => c.StudentWishlistModalityId == objStudentWishlistModality.StudentWishlistModalityId).StudentWishlistModalityId;    //objStudentWishlistModality.StudentWishlistModalityId;
                                _unitOfWork.StudentTime.Add(time);
                            }
                        }
                    }
				}
                TempData["Success"] = "Wishlist Added Successfully";
            }

            //Updating an existing wishlist (edit)
            else
            {
                //Updates class change on details page
                _unitOfWork.StudentWishlistDetails.Update(objStudentWishlistDetails);

                //Get list of old modalities and times to check against
                List<StudentWishlistModality> oldValues = new List<StudentWishlistModality>(); 
                List<StudentTime> oldTimes = new List<StudentTime>();
                List<int> toIgnore = new List<int>();

                //load the lists
                foreach (var item in _unitOfWork.StudentWishlistModality.GetAll(c => c.StudentWishListDetailsId == objStudentWishlistDetails.StudentWishlistDetailsId))
                {
                    oldValues.Add(item);
                }

                foreach (var item in oldValues)
                {
                    foreach(var time in _unitOfWork.StudentTime.GetAll(c => c.StudentWishlistModalityId == item.StudentWishlistModalityId).ToList())
                    {
                        oldTimes.Add(time);
                    }
                }

                foreach (var item in objStudentTime)
                {
                    if (item.StudentWishlistModalityId == -1)
                    {
                        item.StudentWishlistModalityId = 0;
                        item.StudentTimeId = -1;
                    }
                }

                //Check new modalities against old modalities
                foreach (var modality in modalityCheck)
                {
                    if (modality.Checked == true)
                    {
                        //Modality is new, was not in previous edit / create
                        if(oldValues.Find(c => c.ModalityId == modality.Value) == null)
                        {
                            objStudentWishlistModality = new StudentWishlistModality() { StudentWishlistModalityId = 0, ModalityId = modality.Value, StudentWishListDetailsId = objStudentWishlistDetails.StudentWishlistDetailsId };
                            _unitOfWork.StudentWishlistModality.Add(objStudentWishlistModality);
                            oldValues.Add(objStudentWishlistModality);
                        }
                        //If it exists already, no need to update since there is no new information being added.
                    }
                    else 
                    { 
                        //If value is no longer checked, but is in the database, it needs to be deleted.
                        if(oldValues.Find(c => c.ModalityId == modality.Value) != null)
                        {
                            objStudentWishlistModality = _unitOfWork.StudentWishlistModality.GetById(oldValues.Find(c => c.ModalityId == modality.Value).StudentWishlistModalityId);

                            //Have to delete all times since they have a foreign key to StudentWishlistModalityId first.
                            foreach (var time in _unitOfWork.StudentTime.GetAll(c => c.StudentWishlistModalityId == objStudentWishlistModality.StudentWishlistModalityId))
                            {
                                _unitOfWork.StudentTime.Delete(time);
                                toIgnore.Add(time.StudentTimeId);
                            }
                            _unitOfWork.StudentWishlistModality.Delete(objStudentWishlistModality);
                        }
                    }
                }

                //If  time from a modality is deleted, but not the whole modality, we need to check that its in the db, in old values, but not in new values, then delete.
                foreach(var item in oldTimes)
                {
                    if(objStudentTime.Find(c => c.StudentTimeId == item.StudentTimeId) == null && _unitOfWork.StudentTime.GetById(item.StudentTimeId) != null)
                    {
                        _unitOfWork.StudentTime.Delete(item);
                        toIgnore.Add(item.StudentTimeId);
                    }
                }

                for (int i = 0; i < oldTimes.Count; i++)
                {
                    if (!toIgnore.Contains(oldTimes[i].StudentTimeId))
                    {
                        oldTimes[i].CampusId = objStudentTime.Find(c => c.StudentTimeId == oldTimes[i].StudentTimeId).CampusId;
                        oldTimes[i].TimeBlockId = objStudentTime.Find(c => c.StudentTimeId == oldTimes[i].StudentTimeId).TimeBlockId;
                    }     
                }

                //Adding / Editing times

                for(int i = 0; i < objStudentTime.Count; i++)
                {
                    if (!toIgnore.Contains(objStudentTime[i].StudentTimeId) && objStudentTime[i].CampusId != 0 && objStudentTime[i].TimeBlockId != 0)
                    {
                        if (objStudentTime[i].StudentTimeId != -1)
                        {
                            if (objStudentTime[i].StudentTimeId == 0)
                            {
                                objStudentTime[i].StudentWishlistModalityId = oldValues.Find(c => c.ModalityId == objStudentTime[i].StudentWishlistModalityId).StudentWishlistModalityId;
                                _unitOfWork.StudentTime.Add(objStudentTime[i]);
                            }
                            //Update if its id != 0
                            else
                            {
                                StudentTime toadd = oldTimes.Find(c => c.StudentTimeId == objStudentTime[i].StudentTimeId);
                                _unitOfWork.StudentTime.Update(toadd);
                            }
                        }
                    }   
                }
                TempData["success"] = "Wishlist Successfully Updated";
            }
            //Save changes to Database
            _unitOfWork.Commit();

            int semesterIdValue = _unitOfWork.StudentWishlist.GetById(objStudentWishlistDetails.StudentWishlistId).SemesterId;

            //redirect to the products page
            return RedirectToPage("/Students/StudentWishlistHome", new { semesterId = semesterIdValue });
        }
    }
}
