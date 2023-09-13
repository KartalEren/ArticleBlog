using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Extensions
{
   
    public static class LoggedInUserExtensions 
    {
      

        public static int GetLoggedInUserId(this ClaimsPrincipal principal) 
        {
            return Convert.ToInt32(principal.FindFirstValue(ClaimTypes.NameIdentifier));
        }


        public static string GetLoggedInEmail(this ClaimsPrincipal principal) 
        {
            return principal.FindFirstValue(ClaimTypes.Email);  
        }
    }
}
