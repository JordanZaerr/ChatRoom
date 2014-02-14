using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ChatRoom
{
    public class ChatRoomHub : Hub
    {
        private string Name {
            get { return Clients.Caller.name; }
        }

        public void Send(string room, string message)
        {
            SendMessage(room, message, Name);
        }

        public Task JoinGroup(string group)
        {
            return Groups.Add(Context.ConnectionId, group)
                .ContinueWith(_ => SendMessage(
                    group, Name + " has entered your room", "Admin", true));
        }

        public Task LeaveGroup(string group)
        {
            return Groups.Remove(Context.ConnectionId, group)
                .ContinueWith(_ => SendMessage(
                    group, Name + " has left your room", "Admin", true));
        }

        private void SendMessage(string room, string message, string name, bool othersOnly = false)
        {
            dynamic group = othersOnly ? Clients.OthersInGroup(room) : Clients.Group(room);
            group.broadcastMessage(name, message);
        }
    }
}