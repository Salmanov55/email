﻿namespace Pustok.Database.DomainModels
{
    public class MailRequest
    {
        public string Name { get; set; }
        public string SenderMail { get; set; }
        public string RecieverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Password { get; set; }
    }
}
