using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace NotificationServiceApi
{
    public class NotificationHub : Hub
    {
        public Task JoinGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public Task LeaveGroup(string groupName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
