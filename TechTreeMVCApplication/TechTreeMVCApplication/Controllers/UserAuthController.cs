using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TechTreeMVCApplication.Data;
using TechTreeMVCApplication.Entities;
using TechTreeMVCApplication.Models;

namespace TechTreeMVCApplication.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _sigInManager;
        private readonly ApplicationDbContext _context;

        public UserAuthController(ApplicationDbContext context,
                                   UserManager<ApplicationUser> userManager,
                                   SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _sigInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            loginModel.LoginInValid = "true";

            if(ModelState.IsValid)
            {
                var result = await _sigInManager.PasswordSignInAsync(loginModel.Email,
                                                                    loginModel.Password,
                                                                    loginModel.RememberMe,
                                                                    lockoutOnFailure : false);
                
                if (result.Succeeded)
                {
                    loginModel.LoginInValid = "";
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                }
             
            }
            return PartialView("_UserLoginPartial",loginModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _sigInManager.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegistrationModel registrationModel)
        {
            registrationModel.RegistrationInValid = "true";

            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = registrationModel.Email,
                    Email = registrationModel.Email,
                    PhoneNumber = registrationModel.PhoneNumber,
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    Address1 = registrationModel.Address1,
                    Address2 = registrationModel.Address2,
                    PostCode = registrationModel.PostCode
                };

                var result = await _userManager.CreateAsync(user, registrationModel.Password);

                if (result.Succeeded)
                {
                    registrationModel.RegistrationInValid = "";

                    await _sigInManager.SignInAsync(user, isPersistent: false);

                    if(registrationModel.CategoryId != 0)
                    {
                       await AddCategoryToUser(user.Id, registrationModel.CategoryId);
                    }

                    return PartialView("_UserRegistrationPartial",registrationModel);
                }

                AddErrorToModelState(result);

            }
            return PartialView("_UserRegistrationPartial", registrationModel);
        }

        [AllowAnonymous]
        public async Task<bool> UserNameExists(string userName)
        {
            bool userNameExit = await _context.Users.AnyAsync(x => x.UserName.ToUpper() == userName.ToUpper()); 

            if (userNameExit)
               return true;

            return false;
        }



        private void AddErrorToModelState(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private async Task AddCategoryToUser(string userId, int categoryId)
        {
            UserCategory userCategory = new UserCategory(); 
            userCategory.UserId = userId;
            userCategory.CategoryId = categoryId;
            _context.UserCategory.Add(userCategory);
            await _context.SaveChangesAsync();
        }

    }
}
