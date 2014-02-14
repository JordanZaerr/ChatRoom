using ChatRoom.Services;
using Microsoft.AspNet.SignalR;
using StructureMap.Configuration.DSL;

namespace ChatRoom
{
    public class ChatRoomStructureMapRegistry : Registry
    {
        public ChatRoomStructureMapRegistry()
        {
            ForSingletonOf<IRoomManager>()
                .Use(new RoomManager(
                    GlobalHost.ConnectionManager.GetHubContext<ChatRoomHub>()));
        }
    }
}