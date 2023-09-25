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
                return NotFound("No rooms are there at this moment");
            }
            return Ok(result);
        }
      
        [HttpPost]
        public ActionResult Post(Room hotel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _roomService.AddNewRoom(hotel);
                    return Created("", result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }

        [HttpPut("UpdatePrice")]
        public ActionResult PutChangeStatus(RoomDTO price)
        {
            try
            {
                var result = _roomService.UpdateRoomPrice(price);
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
