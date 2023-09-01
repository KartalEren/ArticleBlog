using ArticleBlog.BLL.Extensions;
using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using FluentValidation;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace ArticleBlog.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager; //Identity Kütüphanesi içerisinde usermanager var.
        private readonly IValidator<AppUser> _validator; //hata mesajlarını vermek için oluşturduk.

        public RegisterController(UserManager<AppUser> userManager, IValidator<AppUser> validator)
        {
            _userManager = userManager;
            this._validator = validator;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterDTO userRegisterDTO)
        {

            Random rnd = new Random();      //aktivasyon için maile gönderdiğimiz random kod oluşturduk.
            int code = rnd.Next(100000, 1000000); //rastgele kod gönder.


            if (ModelState.IsValid) //Bu yapıyla fluent valdationdan önce geçirmek gerekir.
            {
                AppUser user = new AppUser()//yeni bir kayıt için app user newleriz kullanıcıdan userregisterdtodan aldığımız bilgileri appuser a dahil ederiz.
                {
                    FirstName = userRegisterDTO.FirstName,
                    LastName = userRegisterDTO.LastName,
                    UserName = userRegisterDTO.Email,
                    Email = userRegisterDTO.Email,
                    PhoneNumber = userRegisterDTO.PhoneNumber,
                    //ConfirmCode = code
                };

                if (userRegisterDTO.ConfirmPassword == null || userRegisterDTO.ConfirmPassword != userRegisterDTO.Password) //Burayı şifreyi onaylamayınca kaydettiği için kaydetmemesi adına bir kontrol amacıyla yaptık.
                {
                    return View(userRegisterDTO);
                }


                var validation = await _validator.ValidateAsync(user);//Hatalı girişlerde BLL\FluentValidations\UserValidator.cs daki uyarıları vermesi için oluşturduk burada tanımlamadığımız diğer prop hataları için diğer email vs gibi kısımlar için kendiliğindeki hata kodlarını veriyor.
                var result = await _userManager.CreateAsync(user, string.IsNullOrEmpty(userRegisterDTO.Password) ? "" : userRegisterDTO.Password);    //Şifreyi girmeyince hata fırlatıyordu. Ternary If kullanarak şifre boşsa null getirdik. Böylece validasyon hatasına gittik.

                //var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);//yeni kullanıcı yaratırken appuserdaki bilgilerle, userRegisterDTO dan gelen passwordu al dedik.

                if (result.Succeeded) //şifreyle giriş başarılı ise onay ekranına göndermek için aşağıdaki işlemler yapılır
                {
                    MimeMessage mimeMessage = new MimeMessage(); //***Bu MimeMessage ı WEB Katmanında  nugget (NETCore.MailKit) olarak indirdik. Mailimize kayot olurken onay için doğrulama kodu göndersin diye. Burada işlem başarılı olduğu için yeni bir mail kit yarattık.
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Article Blog", "erenkartal1992@gmail.com"); //Doğrulama maili kimden ve hangi mailden gelecektir.
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email); //Mailin kime gideceğini ve kayıt esnasında yeni bir ppUser ın user değişkenin mail adresine yönlendirme yapacağız.

                    mimeMessage.From.Add(mailboxAddressFrom);//mailin kimden gideceiğini ekledik
                    mimeMessage.To.Add(mailboxAddressTo);//mailin kime gönderileceğini ekledik.

                    var bodyBuilder=new BodyBuilder(); //yeni bir BodyBuilder() yaratıp nesnesini alıyoruz.
                    bodyBuilder.TextBody = "Your confirmation code to complete the registration process" + " " + code; //Kayıt ooacak kişinin mail adresine "Kayıt işlemini tamamlamak için onay kodunuz" gibi mesaj ile birlikte yukarıda tanımladığımız 100000, 1000000 arasında oluşacak random code değişkenini de ekleriz.
                    mimeMessage.Body = bodyBuilder.ToMessageBody(); //mesajı mimeMessage ile yollamış olduk.

                    mimeMessage.Subject = "Article Blog Confirm Code"; //Buda gönderilen onay kodu mailinin konusudur.

                    SmtpClient smtpClient = new SmtpClient(); //Buradan bir client örneği oluşturduk.
                    smtpClient.Connect("smtp.gmail.com", 587, false); //iletişim kuracağı mail uzantısı, mailin Türkiye'deki kodu, va güvenliği sağlamaması için false dedik başka şekilde sağlayacağız çünkü.
                    smtpClient.Authenticate("erenkartal1992@gmail.com", "sfefytpaobfollld"); //burada gönderen mailin adresi ve şifresini istiyor. Bunu almak için Gmail hesabına git/Güvenlik ayarlarından 2 adımlı doğrulamayı etkinleştir./google hesabınızı yönet sayfasına geri gel/arama çubuğuna "Uygulama şifreleri yaz"/Uygulama şifresi oluşturmak istediğiniz uygulamayı ve cihazı seçin. kısmından Diğer  seçeneğini seç ve oraya ArticleBlog yaz ve oluştur dedikten sonra 16 haneli şifreyi kopyala ve tamam de ve o şifreyi buraya yapıştır diğer parametre olarak Bu bizim uygulama için gmailimizi kullanabilmesi için şifremiz olacak "sfefytpaobfollld".
                    smtpClient.Send(mimeMessage); //mimeMessageden gelen maili gönder.
                    smtpClient.Disconnect(true); //mail gönderildekten sonra mailden çıkış yap.

                  


                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                }

            }

            return View(); // hata alırsa aynı sayfada kalsın
        }
    }
}
