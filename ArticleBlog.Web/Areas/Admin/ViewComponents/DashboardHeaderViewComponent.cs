using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArticleBlog.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent:ViewComponent //Aktif kullanıcı adını sayfada belirtmek için yaparız.
    {
        private readonly UserManager<AppUser> _userManager; //Giriş yapan kullanıcı adına erişmek için kullanırız.
        private readonly IMapper _mapper; //Giriş yapanın rolünü bulmak için kullanırız.

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager,IMapper mapper )
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
            var map = _mapper.Map<UserDTO>(loggedInUser); //loggedInUser ı UserDTO ya gönderdi.


            var role = string.Join("", await _userManager.GetRolesAsync(loggedInUser)); //GetRolesAsync çoğunluk olduğu için sıkıntı olur ama biz burada bunu manipule edeceğiz string.Join("", ) metodu ile ve aşağıdaki eşitleme yaptımız role (sağ taraftaki) türü liste olduğu için artık bizden liste istemeyecek string değer olmuş olacak çünkü soldaki Role strin bir propdur UserDTO da.
            map.Role = role; //map ile userDTO ya değeri taşımış olduk. çünkü yukarıda map işleminde loggedInUser ı UserDTO ya gönderdi.




            return View(map); //giriş yapan kullanıcıyı id den çektik.
            
        }
    }
}
