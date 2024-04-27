﻿using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Client.PL.services.EmailSender
{
	public class EmailSender : IEmailSender
	{
		private readonly IConfiguration _configuration;

		public EmailSender(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public async Task SendAsync(string form, string recipents, string subject, string body)
		{
			var senderEmail = _configuration["EmailSettings:SenderEmail"];
			var senderPassword = _configuration["EmailSettings:SenderPassword"];

			var emailMessage = new MailMessage();
			emailMessage.From = new MailAddress(form);
			emailMessage.To.Add (recipents);
			emailMessage.Subject = subject;
			emailMessage.Body = body;
			//emailMessage.Body = $"<html><body>{body}</body></html>";
			//emailMessage.IsBodyHtml = true;

			var smtpClient = new SmtpClient(_configuration["EmailSettings:SmtpClientServer"], int.Parse(_configuration["EmailSettings:SmtpClientPort"]))
			{
				Credentials = new NetworkCredential(senderEmail,senderPassword),
				EnableSsl = true
			};
			await smtpClient.SendMailAsync (emailMessage);
		}
	}
}
