using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;
using HotelManagementApi.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult BookRoom(Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Invalid booking request.");
            }

            int roomId = booking.RoomId;
            DateTime checkInDate = booking.CheckInDate;
            DateTime checkOutDate = booking.CheckOutDate;

            bool isBookingSuccessful = _bookingService.BookARoom(roomId, checkInDate, checkOutDate);

            if (!isBookingSuccessful)
            {
                return BadRequest("Room booking failed. The room may be unavailable.");
            }

            return Ok("Room booked successfully!");
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var bookings = _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpPut("/checkInUpdate")]
        public IActionResult UpdateCheckInDate(CheckInDTO checkInDTO)
        {
            try
            {
                var result = _bookingService.UpdateCheckIn(checkInDTO);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/checkOutUpdate")]
        public IActionResult UpdateCheckOutDate(CheckOutDTO checkOutDTO)
        {
            try
            {
                var result = _bookingService.UpdateCheckOut(checkOutDTO);
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
        public IActionResult CancelBooking(int bookingId)
        {
            bool isCancellationSuccessful = _bookingService.CancelBooking(bookingId);

            if (isCancellationSuccessful)
            {
                return Ok("Booking canceled successfully!");
            }

            return NotFound("Booking not found or cancellation failed.");
        }
    }
}
