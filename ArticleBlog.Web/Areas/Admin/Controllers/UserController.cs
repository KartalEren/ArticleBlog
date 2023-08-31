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
        private readonly IUserService _userService; // _userService imdeki metotlara ulaşmak için yapıldı.
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager; //Rollere ulaşmak için kendiliğinden gelen RoleManager<AppRole> AppRole sınıfını ekledik.
        private readonly IValidator<AppUser> _validator; //fluent validation ları kullanabilmek için çağırdık.
        private readonly SignInManager<AppUser> _signInManager; //profile actionundaki şifres değişikliğinde kullancıyı tekrardan sistemden çıkarıp girş yapabilmesi adına bu class ı kullanıyoruz.
       
       

        public UserController(IUserService userService, UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IValidator<AppUser> validator, SignInManager<AppUser> signInManager)
        {
            this._userService=userService;
            this._userManager = userManager;
            this._mapper = mapper;
            this._roleManager = roleManager;
            this._validator = validator;
            this._signInManager = signInManager;                    
        }


        [Authorize(Roles = "SuperAdmin,Admin")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> Index()//kullanıcıları rollerine göre gösteririz.
        {
            var result=await _userService.GetAllUsersWithRoleAsync(); //Rolleriyle beraber Users ı Index te listelemek için yapıldı.

            return View(result);
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> Add() //kullanıcıekleriz.
        {
            var roles = await _userService.GetAllRolesAsync();  //GetAllRolesAsync _userService de Tüm roller getirmek yapıldı.

            return View(new UserAddDTO { Roles = roles });//kullanıcıdan gelen rolü dto daki Roles e atamış olduk. oluşturmuş olduk.
        }



        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> Add(UserAddDTO userAddDTO)
        {
            var map = _mapper.Map<AppUser>(userAddDTO); //mapleyerek userAddDTO yu AppUser a döndürdü

            var validation = await _validator.ValidateAsync(map);//sonra map sonucuna göre hata mesajı ver veya verme
            var roles = await _userService.GetAllRolesAsync(); // Tüm roller getirmek yapıldı.
            if (ModelState.IsValid)
            {

                var result = await _userService.CreateUserAsync(userAddDTO); //_userService GELEN BİR IDENTITYRESULT DÖNDÜRDÜK, EĞER BAŞARLIYSA ALTTAKİ İF E GİRER.

                if (result.Succeeded) //NOT: ******HATALARI BURADAKİ RESULT YAPISINDAN DİREKT ALIYORUZ. YANİ AYRI BİR HATA ALMADIK.
                {
                   
                    return RedirectToAction("Index", "User", new { Area = "Admin" }); //işlem başarılıysa ana sayfaya gönderir. 
                }
                else//başarısız olursa _userServisten gelen CreateUserAsync metodunun olumsuz olmasıyla buraya girecektir.
                {
                    
                    
                        result.AddToIdentityModelState(this.ModelState);//bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner 
                        validation.AddToModelState(this.ModelState); //bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner 
                        return View(new UserAddDTO { Roles = roles });//ekleyemezse gene ekleme sayfasında kalsın
                    
                }

            }
            return View(new UserAddDTO { Roles = roles });//tüm işlem başarısız olursa gene ekleme sayfasında kalsın
        }




        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> Update(int id)  //Kullanıcının bilgilerini ekrana GETirir
        {
            var user = await _userService.GetAppUserByIdAsync(id); //_userServicedeki metotlardandır ID ye göre kullanıcı buluruz.

            var roles= await _userService.GetAllRolesAsync(); //GetAllRolesAsync _userService de Tüm roller getirmek yapıldı.

            var map=_mapper.Map<UserUpdateDTO>(user); //mapleyerek UserUpdateDTO yu AppUser a döndürdü
            map.Roles= roles;

            return View(map);
        }




        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> Update(UserUpdateDTO userUpdateDTO)  //Kullanıcının bilgilerini ekrana GETirir
        {
            var user = await _userService.GetAppUserByIdAsync(userUpdateDTO.Id); //_userServicedeki metotlardandır ID ye göre kullanıcı buluruz.


            if (user != null) //user boş değilse
            {
                
                var roles = await _userService.GetAllRolesAsync(); //GetAllRolesAsync _userService de Tüm roller getirmek yapıldı.

                if (ModelState.IsValid)//eğer işlem başarılı olursa _userManager ile getirdiğim User tabloma girilen yeni değerleri eşle dedik
                {
                    var map=_mapper.Map(userUpdateDTO, user); //burada aşağıda yorum satırındaki işlerin aynısını mapper ile yapmış oluruz.
                    //user.FirstName = userUpdateDTO.FirstName;
                    //user.LastName = userUpdateDTO.LastName;
                    //user.Email = userUpdateDTO.Email;

                     var validation = await _validator.ValidateAsync(map);//sonra map sonucuna göre hata mesajı ver veya verme

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDTO.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString(); //aynı anda girişlerde sıkıntı olmasın diye farklı id vermesi için
                        var result = await _userService.UpdateUserAsync(userUpdateDTO);  //_userServicedeki metotlardandır Kullanıcı güncellemek için yapıldı.

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "User", new { Area = "Admin" }); //işlem başarılıysa ana sayfaya gönderir. 
                        }
                        else//başarısız olursa
                        {    
                                result.AddToIdentityModelState(this.ModelState);//bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner
                                return View(new UserAddDTO { Roles = roles });//ekleyemezse gene ekleme sayfasında kalsın                            
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState); //bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner 

                        return View(new UserAddDTO { Roles = roles });//ekleyemezse gene ekleme sayfasında kalsın
                    }                   
                }
            }
            return NotFound();       
        }




        [Authorize(Roles = "SuperAdmin,Admin")] //***Bu sayfaya kimlerin erişebileceğini ayarladık. Bunu da WEB-Admin-Controllers-AuthorizeController içinde ayarladık buradaya Attribute ekledik. Ama önce bunu yapabilmek için DB kurma aşamasında ilk başlarken Program.cs de app.UseAuthentication(); ve  app.UseAuthorization(); altalta bu sırayla eklememiz gerekiyor.
        public async Task<IActionResult> Delete(int id)
        {          
            var result = await _userService.DeleteUserAsync(id); // _userServicedeki metotlardandır Kullanıcı silmek için yapıldı.

            if (result.identityResult.Succeeded)
            {
                return RedirectToAction("Index", "User", new { Area = "Admin" }); //işlem başarılıysa ana sayfaya gönderir. 
            }
            else//başarısız olursa
            {
               
                result.identityResult.AddToIdentityModelState(this.ModelState);//bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner
            }
            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Profile() //Kullanıcı profilini GETirme action ı
        {
            var profile = await _userService.GetUserProfileAsync(); //Kullanıcıyı içindeki metotlardan çeker buluruz.

            return View(profile);

        }


        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDTO userProfileDTO) //Kullanıcıdan gelen bilgileri kayıt ederiz.
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);//giriş yapan kullanıcıyı çektik

            //if (ModelState.IsValid)//modelstate varsa result isteyen bir yapı vardır. result.success gibi
            //{
            //    var isVerified = await _userManager.CheckPasswordAsync(user, userProfileDTO.CurrentPassword); //kullanıcı doğrulaması yaparız. CheckPasswordAsync metodu _userManager classından geliyor.

            //    if (isVerified && userProfileDTO.NewPassword!=null)  //***Eğer opsiyonel olan yeni şifre oluşturmayı da girirsek bu if içinden devam edecek aksi halde else if den devam edecek parolada güncellemezsek.

            //    {
            //        var result = await _userManager.ChangePasswordAsync(user, userProfileDTO.CurrentPassword, userProfileDTO.NewPassword); //şifres değişikli sonucunu alırız. userProfileDTO.CurrentPassword eski şifreyi userProfileDTO.NewPassword yeni şifreyle _userManager classından gelen ChangePasswordAsync metotla değiştiririz.
            //        if (result.Succeeded)
            //        {
            //            await _userManager.UpdateSecurityStampAsync(user);
            //            await _signInManager.SignOutAsync();//şifre değişikliğinden sonra sistemden çıkardık.
            //            await _signInManager.PasswordSignInAsync(user,userProfileDTO.NewPassword,true,false);//şifre değişikliğinden tekrardan şifreyle giriş yapması için yapıldı. true kişiyi hatırlama sorması için yapldı., false ise çok fazla yanlış giriş yapınca hesabı kitlenmemesi adına yapıldı. Bunların hepsi _signInManager classından gelen metodun istediği parametrelerdir.

            //            //burada da değişiklikleri _userManager dan çektiğimiz appuser tablomuzdaki değerlere user bağlantısıyla atarız.
            //            user.FirstName = userProfileDTO.FirstName;
            //            user.LastName = userProfileDTO.LastName;
            //            user.PhoneNumber = userProfileDTO.PhoneNumber;


            //            await _userManager.UpdateAsync(user); //değişikliğide kaydetmiş olduk.


            //            return View(nameof(Index));
            //        }
            //        else
            //        {
            //            result.AddToIdentityModelState(this.ModelState);//bizim BLL-Extension-FluentValidationExtensions de yaptığımız hatayı döner
            //            return View();
            //        }
            //    }

            //    else if (isVerified)//****doğrulama da doğruysa işlemi yap. Parola güncellemeden normal bilgileri sadece güncellemek istesek buraya girer.

            //    {
            //        await _userManager.UpdateSecurityStampAsync(user);
            //        //burada da değişiklikleri _userManager dan çektiğimiz appuser tablomuzdaki değerlere user bağlantısıyla atarız.
            //        user.FirstName = userProfileDTO.FirstName;
            //        user.LastName = userProfileDTO.LastName;
            //        user.PhoneNumber = userProfileDTO.PhoneNumber;                   


            //        await _userManager.UpdateAsync(user); //değişikliğide kaydetmiş olduk.

            //        return View(nameof(Index));
            //    }
            //    else
            //    {
            //        return View();
            //    }
            //}

            //return View(nameof(Index));


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
