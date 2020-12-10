﻿using System;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace KursachV2.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MimeMessage mes = new MimeMessage();
            mes.From.Add(new MailboxAddress("Адміністрація сайту", "borith2801@gmail.com"));
            mes.To.Add(new MailboxAddress("", email));
            mes.Subject = subject;
            mes.Body = new TextPart(MimeKit.Text.TextFormat.Html) {Text = message};
            using(SmtpClient sm = new SmtpClient())
            {
                await sm.ConnectAsync("smtp.gmail.com", 587, false);
                await sm.AuthenticateAsync("borith2801@gmail.com", "IgOr2801");
                await sm.SendAsync(mes);
                await sm.DisconnectAsync(true);
            }
        }
    }
}
