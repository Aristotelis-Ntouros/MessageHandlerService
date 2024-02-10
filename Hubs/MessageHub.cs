using Microsoft.AspNetCore.SignalR;

namespace MessageHandlerService.Hubs;

public class MessageHub : Hub
{
    public async Task SendMessage(string user, string message, int numbers)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message, numbers);
    }
}