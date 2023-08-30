using ArticleBlog.Entitiy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.DTOs.Users
{
    public class UserAddDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public ICollection<AppRole> Roles { get; set; }

        public UserAddDTO()
        {
            Roles=new HashSet<AppRole>();
        }
    }
}
