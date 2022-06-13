using MeetingRoomApi.Models;

namespace MeetingRoomApi.Repositories
{
    public class RepositoryBase
    {
        protected MeetingRoomAppRoomsContext context;
        public RepositoryBase(MeetingRoomAppRoomsContext context) 
            => this.context = context;

    }
}
