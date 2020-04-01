using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TestHubWebApi.Models;

namespace TestHubWebApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendOrder(Order order)
        {
            await Clients.All.SendAsync(
                "ReceiveOrder",
                order
            );
        }
    }
}