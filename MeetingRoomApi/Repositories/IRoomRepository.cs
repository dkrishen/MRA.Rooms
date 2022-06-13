using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;

namespace MeetingRoomApi.Repositories
{
    public interface IRoomRepository
    {
        public IEnumerable<Room> GetRooms();
        public IEnumerable<Room> GetRoomsByIds(IEnumerable<Guid> ids);
        public Room GetRoomById(Guid id);
    }
}
