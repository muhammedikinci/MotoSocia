using Application.Command;
using Application.Models.Group;
using Application.Models.User;
using Application.Models.Values;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Actions.Group
{
    public class CreateGroupAction : ICommand
    {
        private IMotoDBContext Context { get; set; }
        private IMapper mapper { get; set; }
        private NewUserModel UserData;
        private CreateGroupModel GroupData;
        private List<MediaLink> MediaLinks;
        private bool Success = false;

        public CreateGroupAction(Transport<object[]> transport)
        {
            Context = transport.Dependencies.Context;
            mapper = transport.Dependencies.Mapper;

            UserData = (NewUserModel)transport.Data[0];
            GroupData = (CreateGroupModel)transport.Data[1];
            MediaLinks = (List<MediaLink>)transport.Data[2];
        }

        public void Execute()
        {
            GroupData.GroupOwnerID = UserData._id;
            GroupData.CreatedDate = DateTime.Now;

            var entity = mapper.Map<Domain.Entities.Group>(GroupData);
            entity.MediaLinks = mapper.Map<List<Domain.ValueObjects.MediaLink>>(MediaLinks);

            try
            {
                Context.Groups.Add(entity);
                Context.SaveChanges();

                Success = true;
            }
            catch (Exception)
            {

            }
        }

        public object[] Result()
        {
            return new object[] { Success };
        }
    }
}
