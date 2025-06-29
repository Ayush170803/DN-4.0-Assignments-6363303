using NUnit.Framework;
using Moq;
using CustomerLibrary;

namespace CustomerLibrary.Tests
{
    public class CustomerCommTests
    {
        [Test]
        public void MailStatus()
        {
            var mockMailSender=new Mock<IMailSender>();
            mockMailSender.Setup(sender=>sender.SendMail(It.IsAny<string>(),It.IsAny<string>())).Returns(true);
            var customerComm=new CustomerComm(mockMailSender.Object);
            var result=customerComm.SendMailToCustomer();
            Assert.IsTrue(result);
        }
    }
}
