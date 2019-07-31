using Application.Models.User;
using Application.Command;
using System.Linq;
using AutoMapper;

namespace Application.Actions.User
{
    public class NewUserAction : ICommand
    {
        private IMotoDBContext Context { get; set; }
        private IMapper mapper { get; set; }
        private NewUserModel User { get; set; }

        public NewUserAction(Transport<NewUserModel> transport)
        {
            Context = transport.Dependencies.Context;
            mapper = transport.Dependencies.Mapper;
            User = transport.Data;
        }

        public bool Result = false;

        public void Execute()
        {
            var data = Context.Users.Where(_ => _.UserName == User.UserName).FirstOrDefault();

            if (data == null && 
                User != null && 
                !string.IsNullOrEmpty(User.UserName) &&
                !string.IsNullOrEmpty(User.Password) &&
                !string.IsNullOrEmpty(User.Surname) &&
                !string.IsNullOrEmpty(User.Name))
            {
                Context.Users.Add(mapper.Map<Domain.Entities.User>(User));

                Context.SaveChanges();
                Result = true;
            }

            Log.Write<NewUserAction, DatabaseLog>(Result);
        }

        object[] ICommand.Result()
        {
            return new object[] { Result };
        }
    }
}
