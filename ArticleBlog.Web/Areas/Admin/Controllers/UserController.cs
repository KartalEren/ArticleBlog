using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Helpers.Images;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.BLL.Services.Concreate;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Articles;
using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using ArticleBlog.Entitiy.Enums;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;


namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager; 
        private readonly IValidator<AppUser> _validator; 
        private readonly SignInManager<AppUser> _signInManager;
       
       

        public UserController(IUserService userService, UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IValidator<AppUser> validator, SignInManager<AppUser> signInManager)
        {
            this._userService=userService;
            this._userManager = userManager;
            this._mapper = mapper;
            this._roleManager = roleManager;
            this._validator = validator;
            this._signInManager = signInManager;                    
        }


        [Authorize(Roles = "SuperAdmin,Admin")] 
        public async Task<IActionResult> Index()
        {
            var result=await _userService.GetAllUsersWithRoleAsync(); 

            return View(result);
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Add() 
        {
            var roles = await _userService.GetAllRolesAsync();  

            return View(new UserAddDTO { Roles = roles });
        }



        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")] 
        public async Task<IActionResult> Add(UserAddDTO userAddDTO)
        {
            var map = _mapper.Map<AppUser>(userAddDTO); 

            var validation = await _validator.ValidateAsync(map);
            var roles = await _userService.GetAllRolesAsync();
            if (ModelState.IsValid)
            {

                var result = await _userService.CreateUserAsync(userAddDTO);

                if (result.Succeeded) 
                {
                   
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    
                    
                        result.AddToIdentityModelState(this.ModelState); 
                        validation.AddToModelState(this.ModelState); 
                        return View(new UserAddDTO { Roles = roles });
                    
                }

            }
            return View(new UserAddDTO { Roles = roles });
        }




        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")] 
        public async Task<IActionResult> Update(int id)  
        {
            var user = await _userService.GetAppUserByIdAsync(id); 

            var roles= await _userService.GetAllRolesAsync();

            var map=_mapper.Map<UserUpdateDTO>(user); 
            map.Roles= roles;

            return View(map);
        }




        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")] 
        public async Task<IActionResult> Update(UserUpdateDTO userUpdateDTO) 
        {
            var user = await _userService.GetAppUserByIdAsync(userUpdateDTO.Id); 


            if (user != null) 
            {
                
                var roles = await _userService.GetAllRolesAsync(); 

                if (ModelState.IsValid)
                {
                    var map=_mapper.Map(userUpdateDTO, user); 

                     var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDTO.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString(); 
                        var result = await _userService.UpdateUserAsync(userUpdateDTO); 

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "User", new { Area = "Admin" }); 
                        }
                        else
                        {    
                                result.AddToIdentityModelState(this.ModelState);
                                return View(new UserAddDTO { Roles = roles });                        
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);  

                        return View(new UserAddDTO { Roles = roles });
                    }                   
                }
            }
            return NotFound();       
        }




        [Authorize(Roles = "SuperAdmin,Admin")] 
        public async Task<IActionResult> Delete(int id)
        {          
            var result = await _userService.DeleteUserAsync(id);

            if (result.identityResult.Succeeded)
            {
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
               
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
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
                    
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
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
