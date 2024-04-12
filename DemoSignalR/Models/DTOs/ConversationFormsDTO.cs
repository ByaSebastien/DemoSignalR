namespace DemoSignalR.Models.DTOs
{
    public class ConversationFormsDTO
    {
        public string Name { get; set; }
        public string Username { get; set; }

        public Conversation ToEntity()
        {
            return new Conversation { Name = Name };
        }
    }
}
