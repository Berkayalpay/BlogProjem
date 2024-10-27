using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.Areas.Admin.Models;

namespace ProgrammersBlog.Mvc.Areas.Admin.ViewComponents
{
    public class AdminMenuViewComponent:ViewComponent
    {
        //Bu viewComponent hangi sayfa uzerınde calısıcagını nereden bilecek ?? 

        //Her bir ViewComponent ın bir invoke metoduna ihtiyacı vardır.
        private readonly UserManager<User> _userManager;
        public AdminMenuViewComponent(UserManager<User> usermanager)
        {
            _userManager = usermanager;
        }
        public ViewViewComponentResult Invoke() //Kullanıcı ve ROLLERİNİ alıp bunu UserWithRolesViewModel a gönderir.
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var roles = _userManager.GetRolesAsync(user).Result;

            return View(new UserWithRolesViewModel
            {
                User =user,
                Roles = roles
            });
            //Invoke ViewComponent ı nÇalışmasını sağlar.
        }
    }
}
