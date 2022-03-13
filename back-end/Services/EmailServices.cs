using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace store_server_main.Services
{
    public class EmailServices
    {

        public void SenEmailConf(string to ,string msg){

var message = new MimeMessage();
message.From.Add(MailboxAddress.Parse("doctor2022.net.123457@gmail.com"));
message.To.Add(MailboxAddress.Parse(to));

message.Subject = "état de rendez-vous";
BodyBuilder bodyBuilder = new BodyBuilder();
bodyBuilder.HtmlBody = "<h1>"+msg+ "</h1>";
 message.Body = bodyBuilder.ToMessageBody();
SmtpClient client = new SmtpClient();
client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
client.Authenticate("doctor2022.net.123457@gmail.com", ".net.netproject");
client.Send(message);
client.Disconnect(true);
client.Dispose();





        }
        
    }
}