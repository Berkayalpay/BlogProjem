using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class UserWithRolesViewModel
    {
        //Kullanıcıyı ve Kullanıcı Rolunu buradakı modelımız ıcerısınde tutabılırız sizlerle
        public User User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
