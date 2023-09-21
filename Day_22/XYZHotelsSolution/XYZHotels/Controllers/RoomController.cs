using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using XYZHotels.Interfaces;
using XYZHotels.Models;
using XYZHotels.Models.DTOs;

namespace XYZHotels.Controllers
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

        [HttpPost]
        public ActionResult Post(Room room)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _roomService.AddANewRoom(room);
                    return Created("", result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }

        [HttpPut("UpdateFacility")]
        public ActionResult PutChangeStatus(RoomDTO roomDTO)
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
    }
}
