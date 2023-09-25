using XYZHotels.Interfaces;
using XYZHotels.Models;
using XYZHotels.Models.DTOs;

namespace XYZHotels.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<int, Hotel> _repository;

        public HotelService(IRepository<int, Hotel> repository)
        {
            _repository = repository;
        }
        public Hotel AddANewHotel(Hotel hotel)
        {
            return _repository.Add(hotel);
        }

        public Hotel DeletetHotel(int Id)
        {
            return _repository.Delete(Id);
        }

        public List<Hotel> GetAllHotels()
        {
            return _repository.GetAll();
        }

        public Hotel ToggleHotelStatus(int id)
        {
            var hotel = _repository.Get(id);
            if (hotel != null)
            {
                if (hotel.IsActive == null)
                {
                    hotel.IsActive = false;
                }
                hotel.IsActive = !hotel.IsActive;
                return _repository.Update(hotel);
            }
            return null;
        }

        public Hotel UpdateFacility(HotelDTO hotel)
        {
            var myHotel = _repository.Get(hotel.Id);
            if (myHotel != null)
            {
                myHotel.HotelName = hotel.HotelName;
                myHotel.Facility = hotel.Facility;
                return _repository.Update(myHotel);
            }
            return null;
        }
    }
}
