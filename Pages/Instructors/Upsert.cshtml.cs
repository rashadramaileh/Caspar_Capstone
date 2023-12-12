using CASPAR.Infrastructure.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Pages.Instructors
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
        public InstructorWishlistDetails objInstructorWishlistDetails { get; set; }
        public InstructorWishlistModality objInstructorWishlistModality { get; set; }
        public List<InstructorTime> objInstructorTime { get; set; }
        public List<CheckBoxItem> modalityCheck { get; set; }

    }

    public class UpsertModel : PageModel
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public InstructorWishlist objInstructorWishlist { get; set; }
        [BindProperty]
        public InstructorWishlistDetails objInstructorWishlistDetails { get; set; }
        [BindProperty]
        public InstructorWishlistModality objInstructorWishlistModality { get; set; }
        [BindProperty]
        public List<InstructorTime> objInstructorTime { get; set; }
        //public List<CheckBoxItem> modalityCheck { get; set; } = new List<CheckBoxItem>();


        public IEnumerable<SelectListItem> InstructorList { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }
        public IEnumerable<SelectListItem> FormatList { get; set; }
        public IEnumerable<SelectListItem> TimeList { get; set; }
        public IEnumerable<SelectListItem> CampusList { get; set; }
        public IEnumerable<SelectListItem> MeetingList { get; set; }
        [BindProperty]
        public List<CheckBoxItem> modalityCheck { get; set; }

        public int? saveId;

        public UpsertModel(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            objInstructorWishlist = new InstructorWishlist();
            objInstructorWishlistDetails = new InstructorWishlistDetails();
            objInstructorWishlistModality = new InstructorWishlistModality();
            InstructorList = new List<SelectListItem>();
            CourseList = new List<SelectListItem>();
            TimeList = new List<SelectListItem>();
            MeetingList = new List<SelectListItem>();
            CampusList = new List<SelectListItem>();
            _webHostEnvironment = webHostEnvironment;
            modalityCheck = new List<CheckBoxItem>();
            objInstructorTime = new List<InstructorTime>();

        }
        public IActionResult OnGet(int? id, int? wishlist)
        {
            //modalityCheck = (List<CheckBoxItem>)_unitOfWork.Modality.GetAll()
            //    .Select(x => new CheckBoxItem
            //    {
            //       Text = x.ModalityName, 
            //       Value = x.ModalityId,
            //    });

            foreach (var item in _unitOfWork.Modality.GetAll().OrderBy(x => x.ModalityName))
            {
                CheckBoxItem toAdd = new CheckBoxItem { Text = item.ModalityName, Value = item.ModalityId, AdditionalInfo = item.AdditionalWishlistInfo };
                modalityCheck.Add(toAdd);

                if (item.AdditionalWishlistInfo == true)
                {
                    InstructorTime toAddTime = new InstructorTime();
                    objInstructorTime.Add(toAddTime);
                }
            }

            CourseList = _unitOfWork.Course.GetAll().Where(x => x.IsActive == 1).OrderBy(x => x.CoursePrefix).ThenBy(x => x.CourseNumber).ThenBy(x => x.CourseName)
                .Select(x => new SelectListItem
                {
                    Text = x.CoursePrefix + x.CourseNumber + " " + x.CourseName,
                    Value = x.CourseId.ToString(),
                });

            TimeList = _unitOfWork.DayBlock.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.DayName,
                   Value = x.DaysBlockId.ToString(),
               });

            MeetingList = _unitOfWork.MeetingTime.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.meetingTimeName,
                   Value = x.meetingTimeId.ToString(),
               });

            CampusList = _unitOfWork.Campus.GetAll()
               .Select(x => new SelectListItem
               {
                   Text = x.CampusName,
                   Value = x.CampusId.ToString(),
               });

            if (wishlist != null)
            {
                objInstructorWishlist = _unitOfWork.InstructorWishlist.GetById(wishlist);
            }

            if (id == null)
            {
                id = 0;
            }
            saveId = id;

            if (id > 0)
            {
                objInstructorWishlist = _unitOfWork.InstructorWishlist.GetById(wishlist);
            }

            if(objInstructorWishlist.InstructorWishlistId == null)
            {
                return NotFound();
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
                objInstructorWishlistDetails = _unitOfWork.InstructorWishlistDetails.GetById(id);
                foreach (var item in modalityCheck)
                {
                    foreach (var modality in   _unitOfWork.InstructorWishlistModality.GetAll(c => c.InstructorWishListDetailsId == id))
                    {
                        if (item.Value == modality.ModalityId)
                        {
                            modalityIds.Add(modality.InstructorWishlistModalityId);
                            item.Checked = true;

                            if (_unitOfWork.InstructorTime.GetAll(c => c.InstructorWishlistModalityId == modality.InstructorWishlistModalityId).FirstOrDefault() != null)
                            {
                                objInstructorTime[count] = _unitOfWork.InstructorTime.GetAll(c => c.InstructorWishlistModalityId == modality.InstructorWishlistModalityId).FirstOrDefault();
                                objInstructorTime[count].InstructorWishlistModalityId = (int)modality.ModalityId;
                                count++;
							}
                        }
                    }
                    if(item.AdditionalInfo == true)
                    {
                        if(count == previouscount)
                        {
                            count++;
                        }
                    }
                    previouscount = count;
                }

                foreach (var item in modalityIds)
                {
                    if (_unitOfWork.InstructorTime.GetAll(c => c.InstructorWishlistModalityId == item).Skip(1) != null)
                    {
                        foreach (var time in _unitOfWork.InstructorTime.GetAll(c => c.InstructorWishlistModalityId == item).Skip(1))
                        {
                            time.InstructorWishlistModalityId = (int)_unitOfWork.InstructorWishlistModality.GetById(item).ModalityId;
                            objInstructorTime.Add(time);
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
            if (objInstructorWishlistDetails.InstructorWishlistDetailsId == 0)
            {

                foreach (var item in objInstructorTime)
                {
                    if (item.InstructorWishlistModalityId == -1)
                    {
                        item.InstructorWishlistModalityId = 0;
                        item.InstructorTimeId = -1;
                    }
                }

                objInstructorWishlistDetails.InstructorWishlistId = objInstructorWishlist.InstructorWishlistId;
                // Validate against duplicates in the database
                if (IsDuplicateRanking(objInstructorWishlistDetails.InstructorRanking, objInstructorWishlistDetails.InstructorWishlistId))
                {
                    // Handle the duplicate case, e.g., return an error message or redirect to the form
                    TempData["error"] = "Duplicate value. Please enter a different value.";
                    return RedirectToPage(new { id = objInstructorWishlistDetails.InstructorWishlistDetailsId.ToString(), wishlist = objInstructorWishlistDetails.InstructorWishlistId.ToString() });
                }
                _unitOfWork.InstructorWishlistDetails.Add(objInstructorWishlistDetails);
                foreach (var item in modalityCheck)
                {
                    objInstructorWishlistModality.InstructorWishListDetailsId = objInstructorWishlistDetails.InstructorWishlistDetailsId;
                    objInstructorWishlistModality = new InstructorWishlistModality { InstructorWishlistModalityId = 0, InstructorWishListDetailsId = objInstructorWishlistModality.InstructorWishListDetailsId, ModalityId = objInstructorWishlistModality.ModalityId };
                    if (item.Checked == true)
                    {
                        objInstructorWishlistModality.ModalityId = item.Value;
                        InstructorWishlistModality toAdd = objInstructorWishlistModality;
                        _unitOfWork.InstructorWishlistModality.Add(toAdd);

                        foreach (var time in objInstructorTime)
                        {
                            if (time.InstructorWishlistModalityId == item.Value && time.InstructorWishlistModalityId != -1)
                            {
                                time.InstructorWishlistModalityId = _unitOfWork.InstructorWishlistModality.Get(c => c.InstructorWishlistModalityId == objInstructorWishlistModality.InstructorWishlistModalityId).InstructorWishlistModalityId;    //objInstructorWishlistModality.InstructorWishlistModalityId;
                                _unitOfWork.InstructorTime.Add(time);
                            }
                        }
                    }
                }

                TempData["Success"] = "Wishlist Added Successfully";
            }
            

            //Updating an existing wishlist (edit)
            else
            {
                // Validate against duplicates in the database
                if (IsDuplicateRanking(objInstructorWishlistDetails.InstructorRanking, objInstructorWishlistDetails.InstructorWishlistId))
                {
                    // Handle the duplicate case, e.g., return an error message or redirect to the form
                    TempData["error"] = "Duplicate value. Please enter a different value.";
                    return RedirectToPage(new { id = objInstructorWishlistDetails.InstructorWishlistDetailsId.ToString(), wishlist = objInstructorWishlistDetails.InstructorWishlistId.ToString() });
                }
                //Updates class change on details page
                _unitOfWork.InstructorWishlistDetails.Update(objInstructorWishlistDetails);

                //Get list of old modalities and times to check against
                List<InstructorWishlistModality> oldValues = new List<InstructorWishlistModality>();
                List<InstructorTime> oldTimes = new List<InstructorTime>();
                List<int> toIgnore = new List<int>();

                //load the lists
                foreach (var item in _unitOfWork.InstructorWishlistModality.GetAll(c => c.InstructorWishListDetailsId == objInstructorWishlistDetails.InstructorWishlistDetailsId))
                {
                    oldValues.Add(item);
                }

                foreach (var item in oldValues)
                {
                    foreach (var time in _unitOfWork.InstructorTime.GetAll(c => c.InstructorWishlistModalityId == item.InstructorWishlistModalityId).ToList())
                    {
                        oldTimes.Add(time);
                    }
                }

                foreach (var item in objInstructorTime)
                {
                    if(item.InstructorWishlistModalityId == -1)
                    {
                        item.InstructorWishlistModalityId = 0;
                        item.InstructorTimeId = -1;
                    }
                }

                //Check new modalities against old modalities
                foreach (var modality in modalityCheck)
                {
                    if (modality.Checked == true)
                    {
                        //Modality is new, was not in previous edit / create
                        if (oldValues.Find(c => c.ModalityId == modality.Value) == null)
                        {
                            objInstructorWishlistModality = new InstructorWishlistModality() { InstructorWishlistModalityId = 0, ModalityId = modality.Value, InstructorWishListDetailsId = objInstructorWishlistDetails.InstructorWishlistDetailsId };
                            _unitOfWork.InstructorWishlistModality.Add(objInstructorWishlistModality);
                            oldValues.Add(objInstructorWishlistModality);
                        }
                        //If it exists already, no need to update since there is no new information being added.
                    }
                    else
                    {
                        //If value is no longer checked, but is in the database, it needs to be deleted.
                        if (oldValues.Find(c => c.ModalityId == modality.Value) != null)
                        {
                            objInstructorWishlistModality = _unitOfWork.InstructorWishlistModality.GetById(oldValues.Find(c => c.ModalityId == modality.Value).InstructorWishlistModalityId);

                            //Have to delete all times since they have a foreign key to InstructorWishlistModalityId first.
                            foreach (var time in _unitOfWork.InstructorTime.GetAll(c => c.InstructorWishlistModalityId == objInstructorWishlistModality.InstructorWishlistModalityId))
                            {
                                _unitOfWork.InstructorTime.Delete(time);
                                toIgnore.Add(time.InstructorTimeId);
                            }
                            _unitOfWork.InstructorWishlistModality.Delete(objInstructorWishlistModality);
                        }
                    }
                }

                //If  time from a modality is deleted, but not the whole modality, we need to check that its in the db, in old values, but not in new values, then delete.
                foreach (var item in oldTimes)
                {
                    if (objInstructorTime.Find(c => c.InstructorTimeId == item.InstructorTimeId) == null && _unitOfWork.InstructorTime.GetById(item.InstructorTimeId) != null)
                    {
                        _unitOfWork.InstructorTime.Delete(item);
                        toIgnore.Add(item.InstructorTimeId);
                    }
                }

                for (int i = 0; i < oldTimes.Count; i++)
                {
                    if (!toIgnore.Contains(oldTimes[i].InstructorTimeId))
                    {
                        oldTimes[i].CampusId = objInstructorTime.Find(c => c.InstructorTimeId == oldTimes[i].InstructorTimeId).CampusId;
                        oldTimes[i].DaysBlockId = objInstructorTime.Find(c => c.InstructorTimeId == oldTimes[i].InstructorTimeId).DaysBlockId;
                    }
                }

                //Adding / Editing times

                for (int i = 0; i < objInstructorTime.Count; i++)
                {
                    if (!toIgnore.Contains(objInstructorTime[i].InstructorTimeId) && objInstructorTime[i].CampusId != 0 && objInstructorTime[i].DaysBlockId != 0)
                    {
                        if (objInstructorTime[i].InstructorTimeId != -1)
                        {
							if (objInstructorTime[i].InstructorTimeId == 0)
							{
								objInstructorTime[i].InstructorWishlistModalityId = oldValues.Find(c => c.ModalityId == objInstructorTime[i].InstructorWishlistModalityId).InstructorWishlistModalityId;
								_unitOfWork.InstructorTime.Add(objInstructorTime[i]);
							}
							//Update if its id != 0
							else
							{
								InstructorTime toadd = oldTimes.Find(c => c.InstructorTimeId == objInstructorTime[i].InstructorTimeId);
								_unitOfWork.InstructorTime.Update(toadd);
							}
						}  
                    }
                }

                TempData["success"] = "Wishlist Successfully Updated";
            }

            //Save changes to Database
            _unitOfWork.Commit();

            int semesterIdValue = _unitOfWork.InstructorWishlist.GetById(objInstructorWishlistDetails.InstructorWishlistId).SemesterId;

            //redirect to the products page
            return RedirectToPage("/Instructors/InstructorWishlistHome", new { semesterId = semesterIdValue });
        }

        private bool IsDuplicateRanking(int ranking, int? wishlistId)
        {
            List<int> ranks = new List<int>();
            ranks.Add(0);
            IEnumerable<InstructorWishlistDetails> objWishlistDetails = _unitOfWork.InstructorWishlistDetails.GetAll(x => x.InstructorWishlistId == wishlistId && x.InstructorWishlistDetailsId != objInstructorWishlistDetails.InstructorWishlistDetailsId);
            foreach (InstructorWishlistDetails i in objWishlistDetails)
            {
                ranks.Add(i.InstructorRanking);
            }
            // Check for duplicate ranking excluding the current record

            // If list of ranks contains the ranking, return true
            return ranks.Contains(ranking);
        }
    }
}
