using DemoSignalR.models;

namespace DemoSignalR.Models
{
    public class Conversation
    {
        public Conversation() 
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public List<string> users = new List<string>();
        public List<Message> messages = new List<Message>();
    }
}
