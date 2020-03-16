using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Chatter.WebUI.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public async Task SendMessageGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("MessageReceived", message);
        }

        public async Task DeleteMessageGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("MessageDeleted", message);
        }

        public async Task UpdateMessageGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("MessageUpdated", message);
        }

        public async Task JoinChat(int chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        }

        public async Task LeaveChat(int chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
        }
    }
}
