namespace Infrastructure.Email
{
    public abstract class MailType
    {
        public string subject { get; set; }
        public string plainTextContent { get; set; }
        public string htmlContent { get; set; }
    }

    public class ConfirmMail : MailType
    {
        public ConfirmMail()
        {
            subject = "MotoSocia | Confirm Mail";
            plainTextContent = "MotoSocia | Confirm Mail";
            htmlContent = "<strong><button>Confirm</button></strong>";
        }
    }
}
