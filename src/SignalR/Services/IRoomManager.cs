using System.Collections.Generic;

namespace ChatRoom.Services
{
    public interface IRoomManager
    {
        List<string> Rooms { get; }
        void AddRoom(string roomName);
        void RemoveRoom(string roomName);
    }
}