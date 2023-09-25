﻿using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;
using HotelManagementApi.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApi.Controllers
{
   // [EnableCors("MyCors")]
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
                return NotFound("No hotel are there at this moment");
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
        [HttpDelete]
        public ActionResult DeleteHotel(int id)
        {
            try
            {
                var result = _hotelService.DeleteHotel(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateHotelName")]
        public ActionResult PutChangeStatus(HotelDTO hotel)
        {
            try
            {
                var result = _hotelService.UpdateHotelName(hotel);
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