using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")] 
    public class AuthorizeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthorizeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet] 
        public IActionResult Login()
        {
            return View();
        }


        [AllowAnonymous] 
        [HttpPost] 
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO) 
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDTO.Password, userLoginDTO.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = " " }); 
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Check Your Email Address or Password!"); 
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please Check Your Email Address or Password!"); 
                    return View();
                }
            }
            else
            {
                return View(); 
            }


        }

        [Authorize] 
        [HttpGet]
        public async Task<IActionResult> Logout(UserLoginDTO userLoginDTO) 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" }); 
        }



        [Authorize] 
        [HttpGet]
        public async Task<IActionResult> AccessDenied() 
        {

            return View();
        }
    }
}
