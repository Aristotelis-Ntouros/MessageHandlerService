using MessageHandlerService.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MessageHandlerService.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IHubContext<MessageHub> _hubContext;

    public MessageController(IHubContext<MessageHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] MessageDto message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.User, message.Text);
        return Ok();
    }
}

public class MessageDto
{
    public string? User { get; set; }
    public string? Text { get; set; }
}