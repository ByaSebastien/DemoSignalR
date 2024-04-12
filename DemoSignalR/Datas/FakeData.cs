using DemoSignalR.models;
using DemoSignalR.Models;

namespace DemoSignalR.Datas
{
    public class FakeData
    {
        public static List<Message> Messages = new List<Message>()
        {
            new Message()
            {
                username = "Seb",
                content = "Hello World!!!"
            }
        };

        public static List<Conversation> Conversations = new List<Conversation>();
    }
}
