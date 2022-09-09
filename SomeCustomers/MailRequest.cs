namespace SomeCustomers
{
    internal class MailRequest
    { 

        public string Subject { get; set; }
        public string Body { get; set; }
        public object Attachments { get; set; }
        public string RecepientEmail { get; set; }
    }
}