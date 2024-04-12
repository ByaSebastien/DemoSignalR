using DemoSignalR.Datas;
using DemoSignalR.models;
using DemoSignalR.Models;
using DemoSignalR.Models.DTOs;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace DemoSignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            FakeData.Messages.Add(message);
            await Clients.All.SendAsync("allMessage",FakeData.Messages);
        }

        public async override Task OnConnectedAsync() 
        {
            await Clients.Caller.SendAsync("allMessage", FakeData.Messages);
            await Clients.Caller.SendAsync("allConversation", FakeData.Conversations);
        }

        public async Task CreateConversation(ConversationFormsDTO form)
        {
            Conversation conversation = form.ToEntity();
            conversation.users.Add(form.Username);
            FakeData.Conversations.Add(conversation);
            await Groups.AddToGroupAsync(Context.ConnectionId, conversation.Id.ToString());
            await Clients.All.SendAsync("allConversation", FakeData.Conversations);
        }

        public async Task JoinConversation(Guid conversationId, string username)
        {
            Conversation? conversation = FakeData.Conversations.SingleOrDefault(c => c.Id == conversationId);
            if(conversation != null)
            {
                conversation.users.Add(username);
                await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString());
                Message message = new Message
                {
                    username = username,
                    content = $"{username} joins the conversation."
                };
                conversation.messages.Add(message);
                await Clients.Group(conversationId.ToString()).SendAsync("currentConversation",conversation);
            }
        }

        public async Task sendGroupMessage(Guid conversationId, Message message)
        {
            Conversation? conversation = FakeData.Conversations.SingleOrDefault(c => c.Id == conversationId);
            if (conversation != null)
            {
                conversation.messages.Add(message);
                await Clients.Group(conversationId.ToString()).SendAsync("currentConversation", conversation);
            }
        }
    }
}
