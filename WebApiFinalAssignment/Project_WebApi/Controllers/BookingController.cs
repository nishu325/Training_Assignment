using BAL.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_WebApi.Controllers
{
    //[RoutePrefix("api/Booking")]
    public class BookingController : ApiController
    {
        private readonly IBookingDetail _bookingDetail;
        public BookingController(IBookingDetail bookingDetail)
        {
            _bookingDetail = bookingDetail;
        }

        // POST: Add new booking.
        [HttpPost, Route("api/Booking/AddBooking")]
        public IHttpActionResult Post([FromBody] Booking model)
        {
            return Ok(_bookingDetail.AddBooking(model));
        }

        // PUT:update booking date for any room by Id
        [HttpPut, Route("api/Booking/UpdateBookingDateById")]
        public IHttpActionResult Put([FromBody] Booking model)
        {
            return Ok(_bookingDetail.UpdateBookingDateById(model));
        }

        // PUT: update booking status by booking Id (optional status to Definitive or Cancelled)
        [HttpPut, Route("api/Booking/UpdateBookingStatus")]
        public IHttpActionResult Put([FromBody] Booking model, int id)
        {
            return Ok(_bookingDetail.UpdateBookingStatus(model, id));
        }

        // DELETE: DELETE delete booking by booking Id (change status Deleted – soft delete)
        [HttpDelete, Route("api/Booking/DeleteBooking")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_bookingDetail.DeleteBooking(id));
        }
    }
}
