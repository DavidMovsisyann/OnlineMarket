using Microsoft.AspNetCore.SignalR;

namespace OnlineMarketApi.Chat
{
    public class ChatHub:Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send");
        }
    }
}
