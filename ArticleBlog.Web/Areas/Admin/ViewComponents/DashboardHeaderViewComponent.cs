using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent:ViewComponent 
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper; 

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager,IMapper mapper )
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
            var map = _mapper.Map<UserDTO>(loggedInUser); 


            var role = string.Join("", await _userManager.GetRolesAsync(loggedInUser)); 
            map.Role = role; 




            return View(map); 
            
        }
    }
}
