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
    //  [RoutePrefix("api/Room")]
    public class RoomController : ApiController
    {
        private readonly IRoomDetail _roomDetail;
        public RoomController(IRoomDetail roomDetail)
        {
            _roomDetail = roomDetail;
        }

        //GET : GET all rooms of hotels with optional parameter by hotel city, pin code, Price, Category. 
        //(Default sort by price of room low to high)
        [HttpGet, Route("api/Room/GetRoomDetail")]
        public IHttpActionResult Get(string city, int? pincode, int? price, string category)
        {
            var room = _roomDetail.GetroomDetailByParam(city, pincode, price, category);
            return Ok(room);
        }

        //GET: GET availability of room on some particular date (parameter)
        [HttpGet, Route("api/Room/GetRoomAvailability")]
        public IHttpActionResult Get(int id, DateTime date)
        {
            return Ok(_roomDetail.GetRoomAvailability(id, date));
        }

        // POST: Add new room information.
        [HttpPost, Route("api/Room/AddRoom")]
        public IHttpActionResult Post([FromBody] Room model)
        {
            return Ok(_roomDetail.AddRoomDetail(model));
        }
    }
}
