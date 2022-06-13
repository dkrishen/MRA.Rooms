using System;
using System.Collections.Generic;

namespace MeetingRoomApi.Models
{
    public partial class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
