using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Bus.DomainModels.Models;
using BusReservationSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BusReservationSystem.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            [RegularExpression(@"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{3}$", ErrorMessage = "Email format is incorrect")]
            public string Email { get; set; }

            [Required]
            [StringLength(8, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
           

            [Display(Name = "First Name")]
            [StringLength(30)]
            [Required(ErrorMessage = "Enter your First Name")]
            [MinLength(3)]

            [RegularExpression(@"^([A-z][A-Za-z]*\s*[A-Za-z]*)$", ErrorMessage = "Please enter a valid name with min 3 and max 30 characters.")]
            public string Name { get; set; }

            [Display(Name = "Lane No. and Street Address")]
            [StringLength(40)]
            [Required(ErrorMessage = "Address Line  is required")]
            [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Address should contain alphabets and digits with max 40 characters.")]
            public string Address { get; set; }

            [Display(Name = "City")]
            [StringLength(20)]
            [Required(ErrorMessage = "City is required, please enter city")]
            [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "City should contain alphabets with max 20 characters")]
            public string City { get; set; }

            [Display(Name = "State")]
            [StringLength(20)]
            [Required(ErrorMessage = "State is required, please enter State")]
            [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "State should contain alphabets with max 20 characters")]
            public string State { get; set; }

            [Display(Name = "Country")]
            [StringLength(20)]
            [Required(ErrorMessage = "Country is required, please enter Country")]
            [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Country should contain alphabets with max 20 characters")]
            public string Country { get; set; }
            [Required(ErrorMessage = "Pincode is required, please enter Pincode")]
            [RegularExpression(@"^[1-9]{1}[0-9]{2}\s{0,1}[0-9]{3}$", ErrorMessage = "Pincode should contain digits with 6 characters")]
            public int PinCode { get; set; }

            [Required(ErrorMessage = "Age is required, please enter Age")]
            public int Age { get; set; }
            //[DataType(DataType.PhoneNumber)]


            [Display(Name = "Phone Number")]
            [Required(ErrorMessage = "Enter Phone Number")]
            [RegularExpression(@"^[7-9][0-9]{9}$", ErrorMessage = "Phone number should start with 7 or 8 or 9 and should be max 10 characters. ")]
            public string PhoneNumber { get; set; }

            //public string Role { get; set; }

            //[Required(ErrorMessage = "Enter Date of Birth")]
            //[RegularExpression("^([1-9]0[1 - 9][12][0 - 9]3[01])[-/.] ([1 - 9]0[1-9]1[012])[- /.] [0-9]{4}$"
            //, ErrorMessage = "Invalid Date of Birth")]
            public DateTime DateOfBirth { get; set; }

            //[Required(ErrorMessage = "Enter Customer Type")]
            //public CustomerType CustomerType { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Register
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Name = Input.Name,
                    Address = Input.Address,
                    City = Input.City,
                    State = Input.State,
                    Country = Input.Country,
                    Pincode=Input.PinCode,
                    Age=Input.Age,
                    PhoneNumber = Input.PhoneNumber,
                    //Role = Input.Role,
                    DateOfBirth = Input.DateOfBirth,
                    //CustomerType = Input.CustomerType
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
