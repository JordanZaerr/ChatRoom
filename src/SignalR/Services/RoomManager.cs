using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;

namespace ChatRoom.Services
{
    public class RoomManager : IRoomManager
    {
        private readonly IHubContext _context;

        private readonly List<string> _rooms = new List<string>
        {
            "Lobby",
            "Break Room",
            "Team 1"
        };

        public RoomManager(IHubContext context)
        {
            _context = context;
        }

        public void AddRoom(string roomName)
        {
            _rooms.Add(roomName);
            _context.Clients.All.roomCreated(roomName);
        }

        public void RemoveRoom(string roomName)
        {
            _rooms.Remove(roomName);
        }

        public List<string> Rooms 
        {
            get { return _rooms.ToList(); }
        }
    }
}