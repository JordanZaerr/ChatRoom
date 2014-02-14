using FubuMVC.Core;

namespace ChatRoom
{
    public class ChatRoomFubuRegistry : FubuRegistry
    {
        public ChatRoomFubuRegistry()
        {
            Actions.IncludeClassesSuffixedWithEndpoint();
        }
    }
}