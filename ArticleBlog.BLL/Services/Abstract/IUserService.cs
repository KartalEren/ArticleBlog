using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Services.Abstract
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersWithRoleAsync(); //Rolleriyle beraber Users ı Index te listelemek için yapıldı.

        Task<List<AppRole>> GetAllRolesAsync(); // Tüm roller getirmek için yapıldı.

        Task<IdentityResult> CreateUserAsync(UserAddDTO userAddDTO); ////IdentityResult yapısır işlemin başarılı olup olmayacağına göre result verir. Kullanıcı eklemek için yapıldı.
        Task<IdentityResult> UpdateUserAsync(UserUpdateDTO userUpdateDTO); ////IdentityResult yapısır işlemin başarılı olup olmayacağına göre result verir. Kullanıcı güncellemek için yapıldı.
        Task<(IdentityResult identityResult,string? email)> DeleteUserAsync(int id); ////IdentityResult yapısır işlemin başarılı olup olmayacağına göre result verir. Kullanıcı silme için maile de silmek için null olabilir bir string yapı oluşturduk yapıldı.
        Task<AppUser> GetAppUserByIdAsync(int id); // ID ye göre kullanıcı buluruz.
        Task<string> GetUserRoleAsync(AppUser user); // Kullanıcının kendi rolünü string olarak getirmek için yapıldı..
        Task<UserProfileDTO> GetUserProfileAsync(); //Kullanıcıyı içindeki metotlardan çeker buluruz..
        Task<bool> UserProfileUpdateAsync(UserProfileDTO userProfileDTO);
    }
}
