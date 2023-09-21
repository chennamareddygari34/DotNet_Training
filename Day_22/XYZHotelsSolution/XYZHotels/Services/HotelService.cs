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

        public Hotel UpdateFacility(HotelDTO hotel)
        {
            var myHotel = _repository.Get(hotel.HotelId);
            if (myHotel != null)
            {
                myHotel.Facility = hotel.Facility;
                return _repository.Update(myHotel);
            }
            return null;
        }
    }
}
