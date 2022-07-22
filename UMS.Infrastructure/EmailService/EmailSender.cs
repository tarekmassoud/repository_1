﻿using EmailServiceTools;
using MailKit.Net.Smtp;
using MimeKit;
using NETCore.MailKit.Core;
using UMS.Infrastructure.Abstraction.EmailSenderInterface;

namespace UMS.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;
    private IEmailSender _emailSenderImplementation;

    public EmailSender(EmailConfiguration emailConfig)
    {
        _emailConfig = emailConfig;

        MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        async Task SendEmailAsync(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            await SendAsync(emailMessage);
        }
    }

    public Task SendEmailAsync(Message message)
    {
        throw new NotImplementedException();
    }
}