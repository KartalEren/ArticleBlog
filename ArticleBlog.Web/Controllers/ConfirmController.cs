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
        public IActionResult Index() //***Bir önceki sayfadan yani Register sayfasından bu yeni kullanıcı Mail ini çekmeliyiz bunu da TEMPDATA YAPISIYLA YAPACAĞIZ. REGİSTER CONTROLLERININ İNDEX-POST UNDA EĞER BAŞARILIYSA BU SAYFAYA YÖNLENDİRİYORDUK VE ORADAKİ RETURUN ÜN ÜSTÜNDE TempData["Mail"] = userRegisterDTO.Email; şeklinde userRegisterDTO daki maili TemData["Mail"] ile buraya çekmiş olduk.
                                           //TEMPDATA[""] YAPISI İLE CONTROLLER ARASI VERİLER TAŞINIR....
        {
            var value = TempData["Mail"];
            @ViewBag.userEmail = value; //Yukarıdaki Register Controller dan taşıdığımız mail adresinin bulunduğu değişkeni, bu actionun cshtml sayfasında taşımak için  @ViewBag.userEmail veri taşıma modeline attık.

            return View();
        }


        [HttpPost]
        public async Task<IActionResult>  Index(UserConfirmMailDTO userConfirmMailDTO)
        {

            var user = await _userManager.FindByEmailAsync(userConfirmMailDTO.Email);  //_userManager clasındaki kendinden gelen FindByEmailAsync metoduyla kullanıcının mailini almış olduk


            if (user.ConfirmCode==userConfirmMailDTO.ConfirmCode) //eğer bu kullanıcın girdiği ConfirmCode ile user daki confirm code ile eşleiyorsa
            {
                user.EmailConfirmed = true; //user değişkenine tanımladığımız _userManager daki kendinden gelen EmailConfirmed doğrula dedik
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Login","Authorize", new { Area = "Admin" }); //Sonra bizi işlem başarılı olursa Area da bulunan Authorize Controllerdaki Login actionuna döndür girş yapmak için dedik.
            }

                return View();
        }
    }
}
