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

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessageGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceivedMessage", message);
        }
    }
}
