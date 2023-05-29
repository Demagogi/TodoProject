using Microsoft.AspNetCore.SignalR;

namespace TodoProject.Hubs
{
    public class UserHub: Hub
    {
        public async Task NotifyUser()
        {
            await Clients.Caller.SendAsync("notifyTaskStatus"); 
        }

    }
}
