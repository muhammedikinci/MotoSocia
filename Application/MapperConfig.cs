using Application.Models.Group;
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
            CreateMap<Group, CreateGroupModel>();
            CreateMap<CreateGroupModel, Group>();
            CreateMap<Domain.ValueObjects.MediaLink, Models.Values.MediaLink>();
            CreateMap<Models.Values.MediaLink, Domain.ValueObjects.MediaLink>();
        }
    }
}
