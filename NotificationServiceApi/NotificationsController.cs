using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


namespace NotificationServiceApi
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private readonly IHubContext<NotificationHub> hubContext;

        public NotificationsController(IHubContext<NotificationHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpPost("{username}")]
        public async Task<IActionResult> PostNotification(string username, [FromBody] string payload)
        {
            await hubContext.Clients.Group(username).SendAsync("ReceiveNotification", payload);
            return Ok();
        }
    }
}
