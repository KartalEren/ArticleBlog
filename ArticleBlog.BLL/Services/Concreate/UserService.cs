using ArticleBlog.BLL.Extensions;
using ArticleBlog.BLL.Services.Abstract;
using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Concreate
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork; //Repolara ulaşmak için burada new leriz.
        private readonly IHttpContextAccessor _httpContextAccessor;  //BLL-Extension-LoggedInUserExtensions deki ifadeleri görmesi için buraya servis ekledik. HttpContextAccessor ile kullanıcıyı bulmamızı sağlayan yapıdır.
        private readonly ClaimsPrincipal _user;//Login olan kullanıcııları bulan bir yapıdır.Bir üstteki _httpContextAccessor tanımlamak yerine kısa metotlarda olması adına _user şeklinde yapar ctor içine atarız ve _user ı kullanırız artık
        private readonly IMapper _mapper; //Liste türünde metotlarda Mapleme yapmak için burada new leriz.
        private readonly UserManager<AppUser> _userManager; //User metotlarına ulaşmak için burada new leriz.
        private readonly RoleManager<AppRole> _roleManager;//Role metotlarına ulaşmak için burada new leriz.
        private readonly SignInManager<AppUser> _signInManager; //profile actionundaki şifresi değişikliğinde kullancıyı tekrardan sistemden çıkarıp giriş yapabilmesi adına bu class ı kullanıyoruz.

        public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            this._unitOfWork = unitOfWork;
            this._httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User; //artık BLL-Extension-LoggedInUserExtensiondan login logout olan kullanıcıyı bulabiliriz.
            this._mapper = mapper;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        public async Task<List<UserDTO>> GetAllUsersWithRoleAsync() //Rolleriyle beraber Users ı Index te listelemek için yapıldı.
        {
            var users = await _userManager.Users.ToListAsync();
            var map = _mapper.Map<List<UserDTO>>(users); //***Bu map işlemini görebilmesi için BLL-AutoMapper klasöründe kendi sınıfadıyla olan klasörün içinde de AutoMapper tanıtırız.

            foreach (var item in map) //önce tüm userları dönelim ki önce userı bulup ıd sine göre role belirleyelim.
            {
                var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await _userManager.GetRolesAsync(findUser)); //GetRolesAsync çoğunluk olduğu için sıkıntı olur ama biz burada bunu manipule edeceğiz string.Join("", ) metodu ile ve aşağıdaki eşitleme yaptımız role (sağ taraftaki) türü liste olduğu için artık bizden liste istemeyecek string değer olmuş olacak çünkü soldaki Role strin bir propdur UserDTO da.

                item.Role = role;
            }
            return map;
        }



        public async Task<List<AppRole>> GetAllRolesAsync()  // Tüm roller getirmek için yapıldı.
        {
            return await _roleManager.Roles.ToListAsync();
        }



        public async Task<IdentityResult> CreateUserAsync(UserAddDTO userAddDTO)  ////IdentityResult yapısır işlemin başarılı olup olmayacağına göre result verir. Kullanıcı eklemek için yapıldı.
        {
            var map = _mapper.Map<AppUser>(userAddDTO); //mapleyerek userAddDTO yu AppUser a döndürdü
            map.UserName = userAddDTO.Email; //email aslında bizim kullanııcı adımız olduğu için map yardımıla emaili username e eşitledik
            var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDTO.Password) ? "" : userAddDTO.Password); //CreateAsync metodu hem bir değişken hem de bir string pasword istiyor. çünkü hashleme işlemi için gerekiyor user eklerken. string.IsNullOrEmpt ile kayıt esnasında boş geçsek şifreyi bize programın çalışma hatasını göstermemiş oluruz. Yani şifre null veya boşsa bize TRUE ifade döndürür ve hata verdirmez. Paralo girersekte girdiğimizi kayıt eder.


            if (result.Succeeded) //NOT: ******HATALARI BURADAKİ RESULT YAPISINDAN DİREKT ALIYORUZ. YANİ AYRI BİR HATA ALMADIK.
            {
                var findRole = await _roleManager.FindByIdAsync(userAddDTO.RoleId.ToString());//kullanıcın seçtiği rolü buluyoruz
                await _userManager.AddToRoleAsync(map, findRole.ToString());//sonra bu rolü  oluşturduğumuz user a eklemiş olduk.
                return result;

            }
            else
            {
                return result;
            }
        }



        public async Task<AppUser> GetAppUserByIdAsync(int id) // ID ye göre kullanıcı buluruz.
        {
            return await _userManager.FindByIdAsync(id.ToString()); //usermanager içinde gelen kendi metodudr sistemin
        }

        public async Task<string> GetUserRoleAsync(AppUser user) // Kullanıcının kendi rolünü string olarak getirmek için yapıldı..
        {
            return string.Join("", await _userManager.GetRolesAsync(user));  //role string e çevrildi.
        }


        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDTO userUpdateDTO) // //IdentityResult yapısır işlemin başarılı olup olmayacağına göre result verir.Kullanıcı güncellemek için yapıldı.
        {
            var user = await GetAppUserByIdAsync(userUpdateDTO.Id);// ID ye göre kullanıcı buluruz. Yukarıda yapılan metottur.
            var userRole = await GetUserRoleAsync(user); // Kullanıcının kendi rolünü string olarak getirmek için yapıldı. . Yukarıda yapılan metottur.

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await _roleManager.FindByIdAsync(userUpdateDTO.RoleId.ToString());
                await _userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }

        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(int id) //IdentityResult yapısır işlemin başarılı olup olmayacağına göre result verir. Kullanıcı silme için maile de silmek için null olabilir bir string yapı oluşturduk yapıldı.
        {

            var user = await GetAppUserByIdAsync(id); //_userServicedeki metotlardandırID ye göre kullanıcı buluruz.
            var result = await _userManager.DeleteAsync(user); // _userManagerdaki metotlardandır Kullanıcı silmek için yapıldı.

            if (result.Succeeded)
            {
                return (result, user.Email); //email silme ile birlikte işlem başarılıysa ana sayfaya gönderir. 
            }
            else//başarısız olursa
            {
                return (result, null);
            }
        }



        public async Task<UserProfileDTO> GetUserProfileAsync() //Kullanıcıyı içindeki metotlardan çeker buluruz.
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId); //giriş yapan kullanıcıyı çektik
            var map = _mapper.Map<UserProfileDTO>(user); //user ı UserProfileDTO ya eşledik

            return map;
        }


        public async Task<bool> UserProfileUpdateAsync(UserProfileDTO userProfileDTO) //Kulllanıcı profilini güncellemek için yapılmıştır.
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId); //giriş yapan kullanıcıyı çektik
            var isVerified = await _userManager.CheckPasswordAsync(user, userProfileDTO.CurrentPassword);//kullanıcı doğrulaması yaparız. CheckPasswordAsync metodu _userManager classından geliyor.

            if (isVerified && userProfileDTO.NewPassword != null)  //***Eğer opsiyonel olan yeni şifre oluşturmayı da girirsek bu if içinden devam edecek aksi halde else if den devam edecek parolada güncellemezsek.

            {
                var result = await _userManager.ChangePasswordAsync(user, userProfileDTO.CurrentPassword, userProfileDTO.NewPassword); //şifres değişikli sonucunu alırız. userProfileDTO.CurrentPassword eski şifreyi userProfileDTO.NewPassword yeni şifreyle _userManager classından gelen ChangePasswordAsync metotla değiştiririz.
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    await _signInManager.SignOutAsync();//şifre değişikliğinden sonra sistemden çıkardık.
                    await _signInManager.PasswordSignInAsync(user, userProfileDTO.NewPassword, true, false);//şifre değişikliğinden tekrardan şifreyle giriş yapması için yapıldı. true kişiyi hatırlama sorması için yapldı., false ise çok fazla yanlış giriş yapınca hesabı kitlenmemesi adına yapıldı. Bunların hepsi _signInManager classından gelen metodun istediği parametrelerdir.

                    _mapper.Map(userProfileDTO, user);//burada da değişiklikleri _userManager dan çektiğimiz appuser tablomuzdaki değerlere user bağlantısıyla atarız.
                    //user.FirstName = userProfileDTO.FirstName;
                    //user.LastName = userProfileDTO.LastName;
                    //user.PhoneNumber = userProfileDTO.PhoneNumber;


                    await _userManager.UpdateAsync(user); //değişikliğide kaydetmiş olduk.


                    await _unitOfWork.SaveAsync();

                    return true;
                }
                else
                {
                    return false;

                }
            }
            else if (isVerified)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                _mapper.Map(userProfileDTO, user);


                await _userManager.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
                return false;


        }
    }

}
    
