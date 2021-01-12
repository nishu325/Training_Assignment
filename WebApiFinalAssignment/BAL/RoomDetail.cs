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
    public class RoomDetail : IRoomDetail
    {
        private readonly IRoomRepository _roomRepository;

        public RoomDetail(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public string AddRoomDetail(Room model)
        {
            return _roomRepository.AddRoomDetail(model);
        }

        public bool GetRoomAvailability(int id, DateTime date)
        {
            return _roomRepository.GetRoomAvailability(id, date);
        }

        public List<Room> GetroomDetailByParam(string city, int? pincode, int? price, string category)
        {
            return _roomRepository.GetroomDetailByParam(city, pincode, price, category);
        }
    }
}
