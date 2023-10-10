using HotelManagementApi.Contexts;
using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;
using HotelManagementApi.Models.DTOs;

namespace HotelManagementApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<int, Booking> _repository;
        private readonly IRepository<int, Room> _roomRepository;
        private readonly HotelContext _context;

        public BookingService(IRepository<int, Booking> repository, IRepository<int, Room> roomRepository,
            HotelContext context)
        {
            _repository = repository;
            _roomRepository = roomRepository;
            _context = context;
        }
        public bool BookARoom(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            Room room = _roomRepository.Get(roomId);

            if (room == null)
            {
                return false;
            }

            bool isRoomAvailable = IsRoomAvailable(room, checkInDate, checkOutDate);

            if (!isRoomAvailable)
            {
                return false;
            }

            Booking newBooking = new Booking
            {
                RoomId = room.Id,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate
            };

            _repository.Add(newBooking);

            return true;
        }

        private bool IsRoomAvailable(Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            var overlappingBookings = GetOverlappingBookings(room.Id, checkInDate, checkOutDate);

            return overlappingBookings.Count == 0;
        }

        List<Booking> GetOverlappingBookings(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            return _context.bookings
                .Where(b => b.RoomId == roomId &&
                            b.CheckInDate < checkOutDate &&
                            b.CheckOutDate > checkInDate)
                .ToList();
        }

        public bool CancelBooking(int Id)
        {
            Booking booking = _repository.Get(Id);

            if (booking == null)
            {
                return false;
            }
            Room room = _roomRepository.Get(booking.RoomId);

            if (room != null)
            {
                room.IsBooked = false;
                _roomRepository.Update(room);
            }
            _repository.Delete(booking.Id);

            return true;
        }

        public List<Booking> GetAllBookings()
        {
            return _repository.GetAll();
        }

        public Booking UpdateCheckIn(CheckInDTO checkInDTO)
        {
            var myBooking = _repository.Get(checkInDTO.Id);
            if (myBooking != null)
            {
                myBooking.CheckInDate = checkInDTO.CheckInDate;
                return _repository.Update(myBooking);
            }
            return null;
        }

        public Booking UpdateCheckOut(CheckOutDTO checkOutDTO)
        {
            var myBooking = _repository.Get(checkOutDTO.Id);
            if (myBooking != null)
            {
                myBooking.CheckInDate = checkOutDTO.CheckOutDate;
                return _repository.Update(myBooking);
            }
            return null;
        }
    }
}
