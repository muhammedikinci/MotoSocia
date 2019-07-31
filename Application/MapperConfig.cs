using Application.Models.User;
using AutoMapper;
using Domain.Entities;

namespace Application
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, NewUserModel>();
            CreateMap<NewUserModel, User>();
        }
    }
}
