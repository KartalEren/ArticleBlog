using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Concreate
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor; 
        private readonly ClaimsPrincipal _user;
        private readonly IMapper _mapper; 
        private readonly UserManager<AppUser> _userManager; 
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager; 

        public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            this._unitOfWork = unitOfWork;
            this._httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User; 
            this._mapper = mapper;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        public async Task<List<UserDTO>> GetAllUsersWithRoleAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var map = _mapper.Map<List<UserDTO>>(users); 

            foreach (var item in map) 
            {
                var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await _userManager.GetRolesAsync(findUser)); 

                item.Role = role;
            }
            return map;
        }



        public async Task<List<AppRole>> GetAllRolesAsync() 
        {
            return await _roleManager.Roles.ToListAsync();
        }



        public async Task<IdentityResult> CreateUserAsync(UserAddDTO userAddDTO)  
        {
            var map = _mapper.Map<AppUser>(userAddDTO); 
            map.UserName = userAddDTO.Email; 
            var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDTO.Password) ? "" : userAddDTO.Password); 


            if (result.Succeeded)
            {
                var findRole = await _roleManager.FindByIdAsync(userAddDTO.RoleId.ToString());
                await _userManager.AddToRoleAsync(map, findRole.ToString());
                return result;

            }
            else
            {
                return result;
            }
        }



        public async Task<AppUser> GetAppUserByIdAsync(int id) 
        {
            return await _userManager.FindByIdAsync(id.ToString()); 
        }

        public async Task<string> GetUserRoleAsync(AppUser user) 
        {
            return string.Join("", await _userManager.GetRolesAsync(user));  
        }


        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDTO userUpdateDTO) 
        {
            var user = await GetAppUserByIdAsync(userUpdateDTO.Id);
            var userRole = await GetUserRoleAsync(user); 
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await _roleManager.FindByIdAsync(userUpdateDTO.RoleId.ToString());
                await _userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }

        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(int id)
        {

            var user = await GetAppUserByIdAsync(id);
            var result = await _userManager.DeleteAsync(user); 

            if (result.Succeeded)
            {
                return (result, user.Email); 
            }
            else
            {
                return (result, null);
            }
        }



        public async Task<UserProfileDTO> GetUserProfileAsync() 
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);
            var map = _mapper.Map<UserProfileDTO>(user);

            return map;
        }


        public async Task<bool> UserProfileUpdateAsync(UserProfileDTO userProfileDTO)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId); 
            var isVerified = await _userManager.CheckPasswordAsync(user, userProfileDTO.CurrentPassword);

            if (isVerified && userProfileDTO.NewPassword != null) 

            {
                var result = await _userManager.ChangePasswordAsync(user, userProfileDTO.CurrentPassword, userProfileDTO.NewPassword); 
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    await _signInManager.SignOutAsync();
                    await _signInManager.PasswordSignInAsync(user, userProfileDTO.NewPassword, true, false);

                    _mapper.Map(userProfileDTO, user);


                    await _userManager.UpdateAsync(user);


                    await _unitOfWork.SaveAsync();

                    return true;
                }
                else
                {
                    return false;

                }
            }
            else if (isVerified)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                _mapper.Map(userProfileDTO, user);


                await _userManager.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
                return false;


        }
    }

}
    
