using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Models;

namespace UsersApi.Services 
{
public class EmailService
{

    private IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendEmail(string[] receiver, string subject, int userId, string code)
    {
        Message message = new Message(receiver, subject, userId, code);

        var emailMessage = CreateEmail(message);
        Send(emailMessage);
    }

       private void Send(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    const string Key = "EmailSettings:SmtpServer";
                    client.Connect(_configuration.GetValue<string>(Key),
                        _configuration.GetValue<int>("EmailSettings:Port"), true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(emailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }


    //message body
    private MimeMessage CreateEmail(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Sender",
              _configuration.GetValue<string>("EmailSettings:From")));
        emailMessage.To.AddRange(message.Receiver);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = message.Content
        };

        return emailMessage;
    }
 }
}