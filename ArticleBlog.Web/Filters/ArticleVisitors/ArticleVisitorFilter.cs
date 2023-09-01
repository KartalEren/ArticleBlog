using ArticleBlog.DAL.UnitOfWorks;
using ArticleBlog.Entitiy.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ArticleBlog.Web.Filters.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter //FİLTRELEME İŞLEMİ İÇİN YAPARIZ. SİTEYE İLK GİREN İNSANLARIN BİLGİLERİNİ KAYDEDECEĞİZ****
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleVisitorFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {


            List<Visitor> visitors = _unitOfWork.GetRepository<Visitor>().GetAllAsync().Result;//TÜM VİSİTORLERİ LİSTE OLARAK _unitOfWork YAPISIYLA ÇAĞIRDIK.


            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();// MapToIPv4 de kullanıcının id kısmı olduğu için aldık ve stringe çevirdik
            string getUserAgent = context.HttpContext.Request.Headers["User-Agent"]; //BU VE ÜSTTEKİ YAPILARLA ARTIK KULLANICININ SİSTEME NASIL BAĞLANDIĞI BİLGİLERİNİ BİLİYORUZ. 

            Visitor visitor = new(getIp, getUserAgent); //BURADA SİTEYİ ZİYARET EDEN VE YUKARIDA BİLGİLERİNİ ÇEKTİĞİMİZ YENİ BİR ZİYARETÇİ OLUŞTURDUK YUKARIDAKİ BİLGİLERİ İÇEREN PARAMETRELERLE



            if (visitors.Any(x => x.IpAddress == visitor.IpAddress))// YUKARIDAKİ BİLGİLERE GÖRE SİTEYE BİRİ GİRİŞ YAPINCA NEW OLAN visitor BURADA KONTROL EDİLİR. EĞER BÖYLE x.IpAddress == visitor.IpAddress OLUP DAHA ÖNCEDEN HİÇ VAR MI BU KULLANICI DİYE IP ADRESİNDEN BAKARIZ
            {
                return next(); //EĞER KULLANICI DAHA ÖNCEDEN VAR İSE KAYIT YAPMADAN DEVAM ET.
            }


            else //EĞER BÖYLE BİR KULLANICI YOKSA _unitOfWork İLE GetRepository<Visitor>() METODU İLE YANİ VİSİTOR TABLOMA, AddAsync(visitor); METODU İLE VİSİTOR BİLGİLERİ KAYDET DERİZ.
            {
                _unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
                _unitOfWork.Save();
            }
            return next();
        }
    }
}
