using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
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
        // ["1dda7260-08e8-4b32-a9ee-f7e1ca69bc9c","2dda7260-08e8-4b32-a9ee-f7e1ca69bc9c"]
        private readonly IRoomRepository roomRepository;

        public RoomsController(IRoomRepository roomRepository) 
            => this.roomRepository = roomRepository;

        [HttpGet]
        //[Authorize(Roles = "User")]
        [Route("GetAllRooms")]
        public IActionResult GetAllRooms()
        {
            return Ok(JsonConvert.SerializeObject(roomRepository.GetRooms()));
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        [Route("GetRoomById")]
        public IActionResult GetRoomById(string data)
        {
            Guid roomId = JsonConvert.DeserializeObject<Guid>(data);
            return Ok(JsonConvert.SerializeObject(roomRepository.GetRoomById(roomId)));
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        [Route("GetRoomsByIds")]
        public IActionResult GetRoomsByIds(string data)
        {
            var roomIds = JsonConvert.DeserializeObject<IEnumerable<Guid>>(data);
            return Ok(JsonConvert.SerializeObject(roomRepository.GetRoomsByIds(roomIds)));
        }
    }
}
