using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
    


        public UserController(IUserService userService)
        {
            this._userService = userService;
         
        }


        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profile = await _userService.GetUserProfileAsync(); 

            return View(profile);

        }


        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDTO userProfileDTO) 
        {
            
            if (ModelState.IsValid)
            {
                var result = await _userService.UserProfileUpdateAsync(userProfileDTO);
                if (result)
                {

                    return RedirectToAction("Index", "Home", new { Area = " " });
                }
                else
                {
                    var profile = await _userService.GetUserProfileAsync();

                    return View(profile);
                }
            }
            else
                return NotFound();


        }
    }
}
