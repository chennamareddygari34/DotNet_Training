using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;
using HotelManagementApi.Models.DTOs;
using HotelManagementApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApi.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public ActionResult Get()

        {
            var result = _roomService.GetAllRooms();
            if (result == null)
            {
                return NotFound("No Rooms are available at this moment");
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddRoom([FromBody] Room room)
        {
            bool isRoomAdded = _roomService.AddANewRoom(room);

            if (isRoomAdded)
            {
                return Ok("Room added successfully!");
            }

            return BadRequest("Room addition failed. The room may already exist.");
        }

        [HttpPut]
        public ActionResult Update(RoomDTO roomDTO)
        {
            try
            {
                var result = _roomService.UpdatePrice(roomDTO);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteHotel(int id)
        {
            try
            {
                var result = _roomService.DeleteRoom(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
