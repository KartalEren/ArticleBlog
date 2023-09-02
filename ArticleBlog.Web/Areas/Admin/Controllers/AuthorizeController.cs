using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace ArticleBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")] //Bunu yazarak diyoruz ki... Ben Area içindeki Authorize Controller olarak çalışacağım diyorum.
    public class AuthorizeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthorizeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) //Authorize için bir eşleme yapacağız. Bu yüzden bu kotrollerı oluşturmalıydık AppUser ı otomatik Identity içinde gelen UserManager ve SignInManager sınıfının içinde tanımlarız
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet] //Login ekranı açıldığında önümüze gelen ilk ekran Get ekranıdır.
        public IActionResult Login()
        {
            return View();
        }


        [AllowAnonymous] //Home da [Authorize] attributunu koyduğumuz için Home a hiç erişemiyorduk ama login sayfasına ulaşabilmek adına [AllowAnonymous] attribute ile ulaşmak için izin vermiş oluyoruz burada.
        [HttpPost] //Login ekranı açıldığında önümüze gelen ilk ekran Get ekranıdır.
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO) //Post da ekleme yapacağımız yer kullanıcıya gösteriğimiz DTO olduğu için o parametreleri veririz.
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDTO.Password, userLoginDTO.RememberMe, false); //***Giriş için PasswordSignInAsync metodunu ve user, userdtodaki passwor, userdto daki rememberme proplarını attık, eğer bunların eşleşip başarılı bir şekilde return olursa giriş başarılı yapmamız lazım. False ise hata olursa geriye hata mesajı vermesi için yaptık. Metodun kendi yapısına göre uyarladık.
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = " " }); //Eğer işlem başarılıysa return olarak  controllerın Home-Index ine yönlendirdik.
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Check Your Email Address or Password!"); // Burada email hatası için yaptık.
                        return View();//Tekrar Login e dönmüş oluruz başarısız giriş olduğu için. Yani aynı sayfada bırakırız tekrar giriş yapabilmesi için.
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please Check Your Email Address or Password!"); //Burada password hatası için yaptık ama hata adını aynı bıraktık.
                    return View();//Tekrar Login e dönmüş oluruz başarısız giriş olduğu için. Yani aynı sayfada bırakırız tekrar giriş yapabilmesi için.
                }
            }
            else
            {
                return View(); //Burasıda kullanıcı bulunamazsa döndürüleceği sayfa gene aynı login view dır.
            }


        }

        [Authorize] //Logout olmak için önce Login olmak gerekli onun için bu attribute u kullanırız.
        [HttpGet]
        public async Task<IActionResult> Logout(UserLoginDTO userLoginDTO) //Buranın yönlendirmesini Admin Area daki genel _Layout sayfasında Logut Butonunda yazdık.
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" }); //******Area nın boş yapmamızın nedeni bizin Identity içindeki Home değil de En genel makalelerin bulunduğu AREA DIŞINDAKİ Home-Index e gitmesini isteriz.
        }



        [Authorize] //Logout olmak için önce Login olmak gerekli onun için bu attribute u kullanırız.
        [HttpGet]
        public async Task<IActionResult> AccessDenied() //Giriş kısıtlamak için kullanırız
        {

            return View(); //yetkisiz kullanıcıları view a döndürürüz.
        }
    }
}
