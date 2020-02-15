﻿using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chatter.WebUI.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task Echo(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}
