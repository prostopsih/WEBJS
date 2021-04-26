using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLab5.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {

        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task GetToken()
        {

        }
    }
}
