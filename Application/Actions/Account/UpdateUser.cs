using Application.Command;
using Application.Models.Account;
using System;
using System.Linq;

namespace Application.Actions.Account
{
    public class UpdateUser : ICommand
    {
        private IMotoDBContext Context { get; set; }
        private UpdateUserModel User { get; set; }

        public string ProcessMessage = "";
        public bool Status = false;

        public UpdateUser(IMotoDBContext context, UpdateUserModel user)
        {
            Context = context;
            User = user;
        }

        public void Execute()
        {
            if (User.NewPassword != User.NewPasswordAgain)
            {
                ProcessMessage = "Şifreler uyuşmuyor!";
                return;
            }

            var data = Context.Users.Where(_ => _.Password == User.OldPassword && _.UserName == User.UserName).FirstOrDefault();

            if (data == null)
            {
                ProcessMessage = "Kayıt bulunamadı! Eski şifreinizi doğru yazdığınızdan emin olun.";
                return;
            }
            else
            {
                try
                {
                    data.Name = User.Name;
                    data.Surname = User.Surname;
                    data.Password = User.NewPassword;
                    data.Email = User.Email;

                    Context.Users.Update(data);

                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ProcessMessage = "Beklenmedik bir sorun oluştu.";
                    return;
                }

                Status = true;
            }
        }

        public object[] Result()
        {
            return new object[] { Status, ProcessMessage };
        }
    }
}
