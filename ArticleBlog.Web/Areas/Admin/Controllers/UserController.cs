using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager; //Rollere ulaşmak için kendiliğinden gelen RoleManager<AppRole> AppRole sınıfını ekledik.

        public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager)
        {
            this._userManager = userManager;
            this._mapper = mapper;
            this._roleManager = roleManager;
        }


        public async Task<IActionResult> Index()//kullanıcıları rollerine göre gösteririz.
        {

            var users = await _userManager.Users.ToListAsync();
            var map = _mapper.Map<List<UserDTO>>(users); //***Bu map işlemini görebilmesi için BLL-AutoMapper klasöründe kendi sınıfadıyla olan klasörün içinde de AutoMapper tanıtırız.

            foreach (var item in map) //önce tüm userları dönelim ki önce userı bulup ıd sine göre role belirleyelim.
            {
                var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await _userManager.GetRolesAsync(findUser)); //GetRolesAsync çoğunluk olduğu için sıkıntı olur ama biz burada bunu manipule edeceğiz string.Join("", ) metodu ile ve aşağıdaki eşitleme yaptımız role (sağ taraftaki) türü liste olduğu için artık bizden liste istemeyecek string değer olmuş olacak çünkü soldaki Role strin bir propdur UserDTO da.

                item.Role = role;
            }
            return View(map);
        }


        [HttpGet]
        public async Task<IActionResult> Add() //kullanıcıekleriz.
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return View(new UserAddDTO { Roles = roles });//kullanıcıdan gelen rolü dto daki Roles e atamış olduk. oluşturmuş olduk.
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDTO userAddDTO)
        {
            var map = _mapper.Map<AppUser>(userAddDTO); //mapleyerek userAddDTO yu AppUser a döndürdü
            var roles = await _roleManager.Roles.ToListAsync();
            if (ModelState.IsValid)
            {
                map.UserName = userAddDTO.Email; //email aslında bizim kullanııcı adımız olduğu için map yardımıla emaili username e eşitledik
                var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDTO.Password) ? "" : userAddDTO.Password); //CreateAsync metodu hem bir değişken hem de bir string pasword istiyor. çünkü hashleme işlemi için gerekiyor user eklerken. string.IsNullOrEmpt ile kayıt esnasında boş geçsek şifreyi bize programın çalışma hatasını göstermemiş oluruz. Yani şifre null veya boşsa bize TRUE ifade döndürür ve hata verdirmez. Paralo girersekte girdiğimizi kayıt eder.


                if (result.Succeeded) //NOT: ******HATALARI BURADAKİ RESULT YAPISINDAN DİREKT ALIYORUZ. YANİ AYRI BİR HATA ALMADIK.
                {
                    var findRole = await _roleManager.FindByIdAsync(userAddDTO.RoleId.ToString());//kullanıcın seçtiği rolü buluyoruz
                    await _userManager.AddToRoleAsync(map, findRole.ToString());//sonra bu rolü  oluşturduğumuz user a eklemiş olduk.
                    return RedirectToAction("Index", "User", new { Area = "Admin" }); //işlem başarılıysa ana sayfaya gönderir. 
                }
                else
                {
                    foreach (var errors in result.Errors)//başarısız olursa
                    {
                        ModelState.AddModelError("", errors.Description);

                        return View(new UserAddDTO { Roles = roles });//ekleyemezse gene ekleme sayfasında kalsın
                    }
                }

            }
            return View(new UserAddDTO { Roles = roles });//tüm işlem başarısız olursa gene ekleme sayfasında kalsın
        }



    }
}
