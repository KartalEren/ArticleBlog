using Microsoft.AspNetCore.Identity;

namespace ArticleBlog.Entitiy.Entities
{
    public class AppUser : IdentityUser<int>//id leri int almak için yaptık
    {
        public string FirstName { get; set; }
        public string LasttName { get; set; }
    }
}