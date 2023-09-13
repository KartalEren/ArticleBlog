using Microsoft.AspNetCore.Identity;

namespace ArticleBlog.Entitiy.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ConfirmCode { get; set; }
        public Image? Image { get; set; }
        public int? ImageId { get; set; }
        public ICollection<Article> Articles { get; set; }

        public AppUser()
        {
            Articles = new HashSet<Article>();
        }
    }
}