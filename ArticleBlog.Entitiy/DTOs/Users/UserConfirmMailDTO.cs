using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.Entitiy.DTOs.Users
{
    public class UserConfirmMailDTO
    {
        public string Email { get; set; }
        public int ConfirmCode { get; set; }
    }
}
