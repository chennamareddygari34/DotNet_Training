using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZHotels.Interfaces;
using XYZHotels.Models;
using XYZHotels.Models.DTOs;
using XYZHotels.Services;

namespace XYZHotels.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _hotelService.GetAllHotels();
            if (result == null)
            {
                return NotFound("No Hotels are there at this moment");
            }
            return Ok(result);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public ActionResult Post(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _hotelService.AddANewHotel(hotel);
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
        public ActionResult PutChangeStatus(HotelDTO hotel)
        {
            try
            {
                var result = _hotelService.UpdateFacility(hotel);
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
