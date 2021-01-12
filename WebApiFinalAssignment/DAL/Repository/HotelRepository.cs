using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.WebApiProjectEntities _dbContext;

        public HotelRepository()
        {
            _dbContext = new Database.WebApiProjectEntities();
        }
        public string AddHotelDetail(Hotel model)
        {
            try
            {
                Database.Hotel hotel = new Database.Hotel();
                if (model != null)
                {
                    hotel.name = model.Name;
                    hotel.Address = model.Address;
                    hotel.City = model.City;
                    hotel.pincode = model.Pincode;
                    hotel.ContactNumber = model.ContactNumber;
                    hotel.ContactPerson = model.ContactPerson;
                    hotel.Website = model.Website;
                    hotel.Facebook = model.Facebook;
                    hotel.Twitter = model.Twitter;
                    hotel.IsActive = model.ISActive;
                    hotel.CreatedDate = DateTime.Now;
                    hotel.CreatedBy = model.CreatedBy;

                    _dbContext.Hotels.Add(hotel);
                    _dbContext.SaveChanges();

                    return "New Hotel added !";
                }
                return "Model is empty !";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Hotel> GetAllHotelDetail()
        {
            var entities = _dbContext.Hotels.ToList();
            List<Hotel> list = new List<Hotel>();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Hotel hotel = new Hotel();
                    hotel.Id = item.Id;
                    hotel.Name = item.name;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.pincode;
                    hotel.ContactNumber = item.ContactNumber;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.ISActive = item.IsActive;
                    hotel.CreatedDate = item.CreatedDate;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.UpdatedBy = item.UpdatedBy;
                    hotel.UpdatedDate = item.UpdatedDate;

                    list.Add(hotel);
                }
            }
            return list.OrderBy(m => m.Name).ToList();
        }

    }
}
