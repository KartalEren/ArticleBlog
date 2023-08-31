namespace ArticleBlog.Web.Consts
{
    public static class RoleConsts //Burada controller larımızda hangi Action un hangi kullanıcı tarafından görülmesini(Authorize) istediğimiz bir yapı oluşturmak için bu sınıfı oluşturduk. Örnek için;  [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")] gibi Attribute yapısını yazarız ActionResult üstlerine
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
