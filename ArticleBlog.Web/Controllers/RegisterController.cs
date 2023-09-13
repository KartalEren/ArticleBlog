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
        private readonly UserManager<AppUser> _userManager; 
        private readonly IValidator<AppUser> _validator; 

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

            Random rnd = new Random();     
            int code = rnd.Next(100000, 1000000); 

            if (ModelState.IsValid) 
            {
                AppUser user = new AppUser()
                {
                    FirstName = userRegisterDTO.FirstName,
                    LastName = userRegisterDTO.LastName,
                    UserName = userRegisterDTO.Email,
                    Email = userRegisterDTO.Email,
                    PhoneNumber = userRegisterDTO.PhoneNumber,
                    ConfirmCode = code
                };

                if (userRegisterDTO.ConfirmPassword == null || userRegisterDTO.ConfirmPassword != userRegisterDTO.Password) 
                {
                    return View(userRegisterDTO);
                }


                var validation = await _validator.ValidateAsync(user);
                var result = await _userManager.CreateAsync(user, string.IsNullOrEmpty(userRegisterDTO.Password) ? "" : userRegisterDTO.Password);

               

                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Article Blog", "erenkartal1992@gmail.com"); 
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder=new BodyBuilder(); 
                    bodyBuilder.TextBody = "Your confirmation code to complete the registration process" + " " + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody(); 

                    mimeMessage.Subject = "Article Blog Confirm Code"; 

                    SmtpClient smtpClient = new SmtpClient(); 
                    smtpClient.Connect("smtp.gmail.com", 587, false); 
                    smtpClient.Authenticate("erenkartal1992@gmail.com", "sfefytpaobfollld"); 
                    smtpClient.Send(mimeMessage); 
                    smtpClient.Disconnect(true); 



                    TempData["Mail"] = userRegisterDTO.Email;


                    return RedirectToAction("Index", "Confirm");
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                }

            }

            return View(); 
        }
    }
}
