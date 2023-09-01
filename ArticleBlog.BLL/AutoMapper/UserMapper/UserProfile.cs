using ArticleBlog.Entitiy.DTOs.Users;
using ArticleBlog.Entitiy.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.AutoMapper.UserMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDTO>().ReverseMap(); //Controllerda var map=... gibi ifade yapabilmek için buraya auto map yaparız.
            CreateMap<AppUser, UserAddDTO>().ReverseMap(); //Controllerda var map=... gibi ifade yapabilmek için buraya auto map yaparız.
            CreateMap<AppUser, UserUpdateDTO>().ReverseMap(); //Controllerda var map=... gibi ifade yapabilmek için buraya auto map yaparız.
            CreateMap<AppUser, UserProfileDTO>().ReverseMap(); //Controllerda var map=... gibi ifade yapabilmek için buraya auto map yaparız.
            CreateMap<AppUser, UserRegisterDTO>().ReverseMap(); //Controllerda var map=... gibi ifade yapabilmek için buraya auto map yaparız.
        }
    }
}
