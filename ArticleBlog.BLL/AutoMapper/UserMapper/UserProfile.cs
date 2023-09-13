using ArticleBlog.Entitiy.DTOs.Authors;
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
            CreateMap<AppUser, UserDTO>().ReverseMap(); 
            CreateMap<AppUser, UserAddDTO>().ReverseMap(); 
            CreateMap<AppUser, UserUpdateDTO>().ReverseMap(); 
            CreateMap<AppUser, UserProfileDTO>().ReverseMap(); 
            CreateMap<AppUser, UserRegisterDTO>().ReverseMap(); 
            CreateMap<AppUser, UserConfirmMailDTO>().ReverseMap();
            CreateMap<AppUser, AuthorDetailDTO>().ReverseMap(); 
        }
    }
}
