using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IBookingDetail
    {
        string AddBooking(Booking model);

        string UpdateBookingDateById(Booking model);

        string UpdateBookingStatus(Booking model, int id);

        string DeleteBooking(int id);
    }
}
