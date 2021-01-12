using BAL.Interface;
using DAL.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class HotelDetail : IHotelDetail
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelDetail(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string AddHotelDetail(Hotel model)
        {
            return _hotelRepository.AddHotelDetail(model);
        }

        public List<Hotel> GetAllHotelDetail()
        {
            return _hotelRepository.GetAllHotelDetail();
        }
    }
}
