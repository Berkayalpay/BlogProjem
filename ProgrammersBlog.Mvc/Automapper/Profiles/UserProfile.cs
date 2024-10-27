using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Automapper.Profiles
{
    public class UserProfile:Profile
    {

        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto>(); // başlangıc değerimiz user bize gelicek değer userUpdateDto
            CreateMap<UserUpdateDto, User>();

        }
    }
}
