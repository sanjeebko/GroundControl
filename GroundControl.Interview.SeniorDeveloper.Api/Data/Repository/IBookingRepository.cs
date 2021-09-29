using GroundControl.Interview.SeniorDeveloper.Model;
using System.Collections.Generic;

namespace GroundControl.Interview.SeniorDeveloper.Api.Data.Repository
{
    public interface IBookingRepository
    {
         
        IEnumerable<Booking> GetBookings();
        bool SaveBookings(int bookingType, int makeid, int model, string registrationNumber);

    }
}
