using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly Database.WebApiProjectEntities _dbContext;

        public RoomRepository()
        {
            _dbContext = new Database.WebApiProjectEntities();
        }
        public string AddRoomDetail(Room model)
        {
            try
            {
                Database.Room room = new Database.Room();
                if (model != null)
                {
                    room.Hotel_Id = model.Hotel_Id;
                    room.RoomCategory = model.RoomCategory;
                    room.RoomPrice = model.RoomPrice;
                    room.IsActive = model.IsActive;
                    room.CreatedDate = DateTime.Now;
                    room.CreatedBy = model.CreatedBy;
                    room.RoomNo = model.RoomNo;
                    _dbContext.Rooms.Add(room);
                    _dbContext.SaveChanges();

                    return "New room added !";
                }

                return "Model is empty !";

            }

            catch (Exception ex)
            {
                return "Error" + ex;
            }
        }

        public bool GetRoomAvailability(int id, DateTime date)
        {
            var room_id = _dbContext.Bookings.Any(x => x.RoomId == id);

            var booking_date_id = _dbContext.Bookings.Any(x => x.RoomId == id && x.BookingDate == date);

            if (room_id == true)
            {
                if (booking_date_id == true)
                    return false;
                else
                    return true;

            }
            else
            {
                return false;
            }
        }

        public List<Room> GetroomDetailByParam(string city, int? pincode, int? price, string category)
        {
            if (city != null || pincode != null)
            {
                var hotelId = _dbContext.Hotels.Where(m => m.City == city || m.pincode == pincode).Select(m => m.Id);
                List<Room> rooms = new List<Room>();
                foreach (var hid in hotelId)
                {
                    var roomdata = _dbContext.Rooms.Where(x => x.Hotel_Id == hid).ToList();
                    foreach (var rgp in roomdata)
                    {
                        Room model = new Room();
                        model.Id = rgp.Id;
                        model.CreatedDate = rgp.CreatedDate;
                        model.CreatedBy = rgp.CreatedBy;
                        model.UpdatedDate = rgp.UpdatedDate;
                        model.UpdatedBy = rgp.UpdatedBy;
                        model.RoomCategory = rgp.RoomCategory;
                        model.IsActive = rgp.IsActive;
                        model.RoomNo = rgp.RoomNo;
                        model.RoomPrice = rgp.RoomPrice;
                        model.Hotel_Id = rgp.Hotel_Id;
                        model.Hotel = new Hotel()
                        {

                            City = rgp.Hotel.City,
                            Address = rgp.Hotel.Address,
                            Pincode = rgp.Hotel.pincode,
                            ContactNumber = rgp.Hotel.ContactNumber,
                            Name = rgp.Hotel.name,
                            Id = rgp.Hotel.Id,
                            ContactPerson = rgp.Hotel.ContactPerson,
                            Website = rgp.Hotel.Website,
                            Facebook = rgp.Hotel.Facebook,
                            Twitter = rgp.Hotel.Twitter,
                            ISActive = rgp.Hotel.IsActive,
                            CreatedDate = rgp.Hotel.CreatedDate,
                            CreatedBy = rgp.Hotel.CreatedBy,
                            UpdatedDate = rgp.Hotel.UpdatedDate,
                            UpdatedBy = rgp.Hotel.UpdatedBy


                        };
                        rooms.Add(model);

                    }
                }
                return rooms.OrderBy(m => m.RoomPrice).ToList();
            }

            else if (price != null)
            {
                List<Room> rooms = new List<Room>();
                var roomprice = _dbContext.Rooms.Where(x => x.RoomPrice == price).ToList();
                foreach (var rgp in roomprice)
                {
                    Models.Room model = new Models.Room();
                    model.Id = rgp.Id;
                    model.CreatedDate = rgp.CreatedDate;
                    model.CreatedBy = rgp.CreatedBy;
                    model.UpdatedDate = rgp.UpdatedDate;
                    model.UpdatedBy = rgp.UpdatedBy;
                    model.RoomCategory = rgp.RoomCategory;
                    model.IsActive = rgp.IsActive;
                    model.RoomNo = rgp.RoomNo;
                    model.RoomPrice = rgp.RoomPrice;
                    model.Hotel_Id = rgp.Hotel_Id;

                    model.Hotel = new Hotel()
                    {

                        City = rgp.Hotel.City,
                        Address = rgp.Hotel.Address,
                        Pincode = rgp.Hotel.pincode,
                        ContactNumber = rgp.Hotel.ContactNumber,
                        Name = rgp.Hotel.name,
                        Id = rgp.Hotel.Id,
                        ContactPerson = rgp.Hotel.ContactPerson,
                        Website = rgp.Hotel.Website,
                        Facebook = rgp.Hotel.Facebook,
                        Twitter = rgp.Hotel.Twitter,
                        ISActive = rgp.Hotel.IsActive,
                        CreatedDate = rgp.Hotel.CreatedDate,
                        CreatedBy = rgp.Hotel.CreatedBy,
                        UpdatedDate = rgp.Hotel.UpdatedDate,
                        UpdatedBy = rgp.Hotel.UpdatedBy
                    };
                    rooms.Add(model);

                }
                return rooms.OrderBy(m => m.RoomPrice).ToList();

            }

            else if (category != null)
            {
                List<Room> rooms = new List<Room>();
                var roomCategory = _dbContext.Rooms.Where(x => x.RoomCategory == category).ToList();
                foreach (var rgp in roomCategory)
                {
                    Models.Room model = new Models.Room();
                    model.Id = rgp.Id;
                    model.CreatedDate = rgp.CreatedDate;
                    model.CreatedBy = rgp.CreatedBy;
                    model.UpdatedDate = rgp.UpdatedDate;
                    model.UpdatedBy = rgp.UpdatedBy;
                    model.RoomCategory = rgp.RoomCategory;
                    model.IsActive = rgp.IsActive;
                    model.RoomNo = rgp.RoomNo;
                    model.RoomPrice = rgp.RoomPrice;
                    model.Hotel_Id = rgp.Hotel_Id;
                    model.Hotel = new Hotel()
                    {

                        City = rgp.Hotel.City,
                        Address = rgp.Hotel.Address,
                        Pincode = rgp.Hotel.pincode,
                        ContactNumber = rgp.Hotel.ContactNumber,
                        Name = rgp.Hotel.name,
                        Id = rgp.Hotel.Id,
                        ContactPerson = rgp.Hotel.ContactPerson,
                        Website = rgp.Hotel.Website,
                        Facebook = rgp.Hotel.Facebook,
                        Twitter = rgp.Hotel.Twitter,
                        ISActive = rgp.Hotel.IsActive,
                        CreatedDate = rgp.Hotel.CreatedDate,
                        CreatedBy = rgp.Hotel.CreatedBy,
                        UpdatedDate = rgp.Hotel.UpdatedDate,
                        UpdatedBy = rgp.Hotel.UpdatedBy
                    };
                    rooms.Add(model);

                }
                return rooms.OrderBy(m => m.RoomPrice).ToList();
            }

            else
            {
                return null;
            }
        }

    }
}
