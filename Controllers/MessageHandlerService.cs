using MessageHandlerService.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MessageHandlerService.Models;

namespace MessageHandlerService.Controllers;

[ApiController]
[Route("[controller]")]
public class MockWebSocketController : ControllerBase
{
    private readonly IHubContext<MessageHub> _hubContext;

    public MockWebSocketController(IHubContext<MessageHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost]
    [Route("SendMockMessage")]
    public async Task<IActionResult> SendMockMessage([FromBody] MockMessageDto message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.User, message.Text, message.Numbers);
        return Ok();
    }
}