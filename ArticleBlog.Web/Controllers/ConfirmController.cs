using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Controllers
{
    public class ConfirmController : Controller
    {
        private readonly UserManager<AppUser> _userManager; //

        public ConfirmController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index() 
        {
            var value = TempData["Mail"];
            @ViewBag.userEmail = value;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult>  Index(UserConfirmMailDTO userConfirmMailDTO)
        {

            var user = await _userManager.FindByEmailAsync(userConfirmMailDTO.Email);  


            if (user.ConfirmCode==userConfirmMailDTO.ConfirmCode) 
            {
                user.EmailConfirmed = true; 
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Login","Authorize", new { Area = "Admin" });
            }

                return View();
        }
    }
}
