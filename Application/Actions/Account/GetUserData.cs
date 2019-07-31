using Application.Command;
using Application.Models.User;
using AutoMapper;
using System.Linq;

namespace Application.Actions.Account
{
    public class GetUserData : ICommand
    {
        private IMotoDBContext context;
        private IMapper mapper;
        private NewUserModel user;

        public NewUserModel FullData;

        public GetUserData(Transport<NewUserModel> transport)
        {
            context = transport.Dependencies.Context;
            mapper = transport.Dependencies.Mapper;
            user = transport.Data;
        }

        public void Execute()
        {
            if (context == null || user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.UserName))
                return;

            var userData = context.Users.Where(_ => _.Email == user.Email && _.UserName == user.UserName).FirstOrDefault();

            if (userData != null &&
                !string.IsNullOrEmpty(userData.UserName) &&
                !string.IsNullOrEmpty(userData.Email) &&
                !string.IsNullOrEmpty(userData.Name))
            {
                FullData = mapper.Map<NewUserModel>(userData);
                //FullData = new NewUserModel() {
                //    Name= userData.Name,
                //    Surname= userData.Surname,
                //    Email= userData.Email,
                //    UserName= userData.UserName
                //};
            }
        }

        public object[] Result()
        {
            return new object[] { FullData };
        }
    }
}
