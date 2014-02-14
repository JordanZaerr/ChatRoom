using FubuMVC.Core;
using FubuMVC.StructureMap;

namespace ChatRoom
{
    public class ChatRoomAppSource : IApplicationSource
    {
        public FubuApplication BuildApplication()
        {
            return FubuApplication
                .For<ChatRoomFubuRegistry>()
                .StructureMap<ChatRoomStructureMapRegistry>();
        }
    }
}