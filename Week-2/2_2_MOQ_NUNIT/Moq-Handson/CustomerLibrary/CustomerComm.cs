namespace CustomerLibrary
{
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;
        public CustomerComm(IMailSender mailSender)
        {
            _mailSender=mailSender;
        }

        public bool SendMailToCustomer()
        {
            return _mailSender.SendMail("cust123@Gmail.com","Hello Message");
        }
    }
}
