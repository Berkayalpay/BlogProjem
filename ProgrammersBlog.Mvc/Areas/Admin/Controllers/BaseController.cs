using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.Helpers.Abstract;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        
        protected UserManager<User> UserManager { get; }

        public BaseController(UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper)
        {
            UserManager = userManager;
            Mapper = mapper;
            ImageHelper = imageHelper;
        }

        protected IMapper Mapper { get; }
        protected IImageHelper ImageHelper { get; }
        protected User LoggedInUser => UserManager.GetUserAsync(HttpContext.User).Result;
        //Farklı bir sınıfın bunu değiştirmesini istemiyoruz !
        //Result burada asenkron yapidan dolayı kaynaklanıyor! LoggedInUser kısmı sayesinde kullanıcı adınına gore yapılıyor işlemler






    }
}
