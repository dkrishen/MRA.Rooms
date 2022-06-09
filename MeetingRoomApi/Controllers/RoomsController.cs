using MeetingRoomApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingRoomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        List<Room> rooms = new List<Room>
        {
            new Room
            {
                Id = Guid.Parse("1DDA7260-08E8-4B32-A9EE-F7E1CA69BC9C"),
                Name = "first"
            },
            new Room
            {
                Id = Guid.Parse("2DDA7260-08E8-4B32-A9EE-F7E1CA69BC9C"),
                Name = "second",
                Description = "desc"
            }
        };

        [HttpGet]
        //[Authorize(Roles = "User")]
        [Route("GetAllRooms")]
        public IActionResult GetAllRooms()
        {
            return Ok(rooms);
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        [Route("GetRoomById")]
        public IActionResult GetRoomById(string data)
        {
            Guid roomId = JsonConvert.DeserializeObject<Guid>(data);
            return Ok(rooms.Where(r => r.Id == roomId).FirstOrDefault());
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        [Route("GetRoomsByIds")]
        public IActionResult GetRoomsByIds(string data)
        {
            var roomIds = JsonConvert.DeserializeObject<IEnumerable<Guid>>(data);
            return Ok(rooms.Where(r => roomIds.Contains(r.Id)));
        }
    }
}
