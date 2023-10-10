using HotelManagementApi.Interfaces;
using HotelManagementApi.Models;
using HotelManagementApi.Models.DTOs;

namespace HotelManagementApi.Services
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

        public Hotel UpdateName(HotelDTO hotel)
        {
            var myHotel = _repository.Get(hotel.Id);
            if (myHotel != null)
            {
                myHotel.HotelName = hotel.HotelName;
                return _repository.Update(myHotel);
            }
            return null;
        }
    }
}
