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
        private readonly IUserService _userService;// _userService imdeki metotlara ulaşmak için yapıldı.
    


        public UserController(IUserService userService)
        {
            this._userService = userService;
         
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
