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
    //[RoutePrefix("api/Hotel")]
    public class HotelController : ApiController
    {
        private readonly IHotelDetail _hotelDetail;
        public HotelController(IHotelDetail hotelDetail)
        {
            _hotelDetail = hotelDetail;
        }

        // GET : Get all hotels sort by alphabetic order. 
        [HttpGet, Route("api/Hotel")]
        public IHttpActionResult Get()
        {
            return Ok(_hotelDetail.GetAllHotelDetail());
        }

        // POST:Adding hotel details 
        [HttpPost, Route("api/Hotel/AddHotel")]
        public IHttpActionResult Post([FromBody] Hotel model)
        {
            return Ok(_hotelDetail.AddHotelDetail(model));
        }

    }
}
