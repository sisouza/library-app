public class EmailService
    {

        public void SendEmail(string[] receiver, string subject, int userId, string code)
        {
            Message message = new Message(receiver, subject, userId, code);
        }
}