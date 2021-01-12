using BAL.Interface;
using Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BookingDetail : IBookingDetail
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingDetail(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public string AddBooking(Booking model)
        {
            return _bookingRepository.AddBooking(model);
        }

        public string DeleteBooking(int id)
        {
            return _bookingRepository.DeleteBooking(id);
        }

        public string UpdateBookingDateById(Booking model)
        {
            return _bookingRepository.UpdateBookingDateById(model);
        }

        public string UpdateBookingStatus(Booking model, int id)
        {
            return _bookingRepository.UpdateBookingStatus(model, id);
        }
    }
}
