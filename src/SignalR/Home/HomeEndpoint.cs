using ChatRoom.Home.Models;
using ChatRoom.Services;

namespace ChatRoom.Home
{
    public class HomeEndpoint
    {
        private readonly IRoomManager _roomManager;

        public HomeEndpoint(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        public HomeViewModel Index()
        {
            return new HomeViewModel();
        }

        public RoomResponseModel get_Rooms(RoomRequestInputModel model)
        {
            return new RoomResponseModel {Rooms = _roomManager.Rooms};
        }

        public void post_CreateRoom(CreateRoomInputModel model)
        {
            _roomManager.AddRoom(model.RoomName);
        }
    }
}