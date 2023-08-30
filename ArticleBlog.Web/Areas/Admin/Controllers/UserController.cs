using ArticleBlog.Entitiy.DTOs.Categories;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager,IMapper mapper)
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }


        public async Task<IActionResult> Index()//kullanıcıları rollerine göre gösteririz.
        {

            var users= await _userManager.Users.ToListAsync();
            var map= _mapper.Map<List<UserDTO>>(users); //***Bu map işlemini görebilmesi için BLL-AutoMapper klasöründe kendi sınıfadıyla olan klasörün içinde de AutoMapper tanıtırız.

            foreach (var item in map) //önce tüm userları dönelim ki önce userı bulup ıd sine göre role belirleyelim.
            {
                var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("",await _userManager.GetRolesAsync(findUser)); //GetRolesAsync çoğunluk olduğu için sıkıntı olur ama biz burada bunu manipule edeceğiz string.Join("", ) metodu ile ve aşağıdaki eşitleme yaptımız role (sağ taraftaki) türü liste olduğu için artık bizden liste istemeyecek string değer olmuş olacak çünkü soldaki Role strin bir propdur UserDTO da.

                item.Role = role;
            }

            return View(map);
        }
    }
}
