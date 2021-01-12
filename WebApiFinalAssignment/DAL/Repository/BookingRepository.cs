using Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Database.WebApiProjectEntities _dbContext;

        public BookingRepository()
        {
            _dbContext = new Database.WebApiProjectEntities();
        }
        public string AddBooking(Booking model)
        {
            try
            {
                Database.Booking booking = new Database.Booking();
                if (model != null)
                {
                    booking.RoomId = model.RoomId;
                    booking.BookingDate = model.BookingDate;
                    booking.StatusOfBooking = "Optional";

                    _dbContext.Bookings.Add(booking);
                    _dbContext.SaveChanges();

                    return "Booking done !";
                }

                return "Model is empty !";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBooking(int id)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(id);
                if (entity != null)
                {
                    entity.StatusOfBooking = "Deleted";
                    _dbContext.SaveChanges();
                    return "deleted done !";
                }
                return "Model is empty !";
            }
            catch (Exception ex)

            {
                return ex.Message;
            }
        }

        public string UpdateBookingDateById(Booking model)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(model.Id);
                if (entity != null)
                {
                    entity.BookingDate = model.BookingDate;

                    _dbContext.SaveChanges();

                    return "Update done !";
                }

                return "Model is empty !";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string UpdateBookingStatus(Booking model, int id)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(id);
                if (entity != null)
                {
                    entity.StatusOfBooking = model.StatusOfBooking;
                    _dbContext.SaveChanges();
                    return "Status Updated !";
                }
                return "Model is empty !";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
