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
        public List<string> users { get; set; } = new List<string>();
        public List<Message> messages { get; set; } = new List<Message>();
    }
}
