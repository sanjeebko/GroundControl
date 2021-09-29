using GroundControl.Interview.SeniorDeveloper.Api.Data.Repository;
using GroundControl.Interview.SeniorDeveloper.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroundControl.Interview.SeniorDeveloper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingTypeRepository _bookingTypeRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingTypeRepository bookingTypeRepository,IBookingRepository bookingRepository)
        {
            this._bookingTypeRepository = bookingTypeRepository;
            this._bookingRepository = bookingRepository;
        }

        [HttpGet]
        [Route("BookingTypes")]
        public IActionResult GetBookingTypes()
        {
            IEnumerable<BookingType> result = _bookingTypeRepository.GetBookingTypes();
            if (result == null) BadRequest("ERROR: No Vehicle Makes found in the database.");


            return Ok(result);
        }

        [HttpGet]
        [Route("Booking")]
        public IActionResult GetBooking()
        {
            IEnumerable<Booking> result = _bookingRepository.GetBookings();
            if (result == null) BadRequest("ERROR: No Vehicle Makes found in the database.");


            return Ok(result);
        }
        [HttpGet]
        [Route("SaveBooking/{bookingType}/{makeid}/{model}/{registrationNumber}")]
        public IActionResult SaveBooking(int bookingType, int makeid, int model, string registrationNumber)
        {
            bool result = _bookingRepository.SaveBookings(bookingType,makeid,model,registrationNumber);
            if (result == false) BadRequest("ERROR: Could not save the booking.");


            return Ok(result);
        }



    }
}
