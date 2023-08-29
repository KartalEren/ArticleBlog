using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.Extensions
{
    //Login yapan kişileri Controllerda yazmak yerine buradaki Extension da yazarak daha temiz bir kod yapısına sahip oluruz. Ve buradakileri yazdıktan sonra Gene Extension-ServisLayerExtension classına da eklememz lazım.
    public static class LoggedInUserExtensions //Her seferinde new lenmeyeceği için static calss yapılır.
    {
        //hem mail hem id tutarız giriş için

        public static int GetLoggedInUserId(this ClaimsPrincipal principal) //ClaimsPrincipal yapısından bu giriş işlemierini yaparız
        {
            return Convert.ToInt32(principal.FindFirstValue(ClaimTypes.NameIdentifier)); //FindFirstValue metodu ClaimsPrincipal yapısından gelir. NameIdentifier ifadei ise ID sidir.
        }


        public static string GetLoggedInEmail(this ClaimsPrincipal principal) //ClaimsPrincipal yapısından bu giriş işlemierini yaparız
        {
            return principal.FindFirstValue(ClaimTypes.Email); //FindFirstValue metodu ClaimsPrincipal yapısından gelir. Email ifadei ise kullanaıcı Email dir.
        }
    }
}
