using System.Collections.Generic;

public class Message
    {
        public List<?> Receiver { get; set; }
        public string Subject { get; set; }
        public string  Content { get; set; }
        public Message(IEnumerable<string> receiver, string  subject, int userId, string code)
        {
            Receiver = "";
            Subject = subject;
            Content = $"http://localhost:6000/active?UserId={userId}&ActivationCode={code}";
        }
    }