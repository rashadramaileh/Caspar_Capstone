// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CASPAR.Infrastructure.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CASPAR.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public List<SelectListItem> GraduationList { get; set; }
        public List<SelectListItem> MajorList { get; set; }
        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            GraduationList = new List<SelectListItem>();
            MajorList = new List<SelectListItem>();
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Graduation Year")]
            public string GraduationYear { get; set; }

            public string Major { get; set; }   
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var graduationyear = user.GraduationYear; 
            var major = user.Major; 
            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                GraduationYear = graduationyear,
                Major = major
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var Spring2024 = new SelectListItem
            {
                Text = "Spring 2024",
                Value = "Spring 2024"
            };
            var Summer2024 = new SelectListItem
            {
                Text = "Summer 2024",
                Value = "Summer 2024"
            };
            var Fall2024 = new SelectListItem
            {
                Text = "Fall 2024",
                Value = "Fall 2024"
            };
            var Spring2025 = new SelectListItem
            {
                Text = "Spring 2025",
                Value = "Spring 2025"
            };
            var Summer2025 = new SelectListItem
            {
                Text = "Summer 2025",
                Value = "Summer 2025"
            };
            var Fall2025 = new SelectListItem
            {
                Text = "Fall 2025",
                Value = "Fall 2025"
            };
            GraduationList.Add(Spring2025);
            GraduationList.Add(Spring2024);
            GraduationList.Add(Fall2025);
            GraduationList.Add(Fall2024);
            GraduationList.Add(Summer2025);
            GraduationList.Add(Summer2024);


            var ComputerScience = new SelectListItem
            {
                Text = "Computer Science",
                Value = "Computer Science"
            };
            var WebUX = new SelectListItem
            {
                Text = "WebUX",
                Value = "WebUX"
            };
            var InformationTechnology = new SelectListItem
            {
                Text = "Information Technology",
                Value = "Information Technology"
            };

            MajorList.Add(ComputerScience);
            MajorList.Add(WebUX);
            MajorList.Add(InformationTechnology);

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }


            var graduationYear = user.GraduationYear;
            if (Input.GraduationYear != graduationYear)
            {

                user.GraduationYear = Input.GraduationYear; await LoadAsync(user);
            }

            var major = user.Major;
            if (Input.Major != major)
            {
                user.Major = Input.Major; await LoadAsync(user);

            }
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
