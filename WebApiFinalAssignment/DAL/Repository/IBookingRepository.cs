using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IBookingRepository
    {
        string AddBooking(Booking model);
        string UpdateBookingDateById(Booking model);
        string UpdateBookingStatus(Booking model, int id);
        string DeleteBooking(int id);
    }
}
